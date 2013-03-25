var buzzlr = function () {

    var optionsInternal;

    var initInternal = function (options) {
        optionsInternal = options;
        initUI();
        loadQuestions();
    }

    var selectors = {
        container: '.content',
        areaItem: '.multi',
        menuItem: '.menuitem',
        questions: '.questions',
        questionsList: '.questions > div',
        answersList: '.answers',
        question: '.question',
        ask: '.ask',
        askForm: {
            button: '#questionpost',
            title: '#qtitle',
            text: '#qtext',
            user: '#quser',
        },
        questionDetail: {
            title: '#qdtitle',
            text: '#qdtext',
            user: '#qduser'
        },
        answerForm: {
            text: '#atext',
            user: '#auser',
            button: '#answerpost'
        }
    };

    var layout = {
        questions:
            '<div class="questions multi">\
                <h1>Questions</h1>\
                <div class="container-fluid">\
                </div>\
            </div>',

        question:
            '<div class="question multi">\
                <h3 id="qdtitle">Question title</h3>\
                <p id="qdtext">Question text</p>\
                <p class="text-right">By:</p>\
                <p class="text-right text-info" id="qduser">User 1</p>\
                <hr />\
                <h3>Answers</h3>\
                <div class="answers">\
                    <p>Answer 1</p>\
                    <p class="text-right">User 1</p>\
                    <hr />\
                </div>\
                <form>\
                    <fieldset>\
                        <legend>Answer your own</legend>\
                        <label>Answer</label>\
                        <textarea rows="3" id="atext" />\
                        <label>User</label>\
                        <input type="text" id="auser" /><br />\
                        <button type="submit" class="btn" id="answerpost">Answer</button>\
                    </fieldset>\
                </form>\
            </div>',

        ask:
            '<div class="ask multi">\
                <form id="newquestion">\
                    <fieldset>\
                        <legend>Ask your question</legend>\
                        <label>Title</label>\
                        <input type="text" id="qtitle" placeholder="Not very long please…" />\
                        <span class="help-block">Be brief and concise.</span>\
                        <label>Question text</label>\
                        <textarea rows="3" id="qtext"></textarea>\
                        <label>Your name</label>\
                        <input type="text" id="quser" /><br />\
                        <button type="submit" class="btn" id="questionpost">Ask</button>\
                    </fieldset>\
                </form>\
            </div>'
    };

    var initUI = function () {
        $(layout.questions).appendTo(selectors.container);
        $(layout.question).appendTo(selectors.container);
        $(layout.ask).appendTo(selectors.container);
        $(selectors.menuItem).click(menuClick);
        $(selectors.askForm.button).click(askClick);
        $(selectors.answerForm.button).click(ansClick);
        openArea(selectors.questions);
    }

    var ansClick = function () {
        createNewAnswer(createAnswer);
        return false;
    }

    var askClick = function () {
        createNewQuestion(function () {
            loadQuestions();
            openArea(selectors.questions);
        });
        return false;
    }

    var menuClick = function () {
        var action = $(this).data('do');
        deselectMenu();
        $(this).parent('li').addClass('active');
        openArea('.' + action);
    }

    var deselectMenu = function () {
        $(selectors.menuItem).parent('li').removeClass('active');
    }

    var openArea = function (name) {
        hideAll();
        $(name).show("fast");
    }

    var loadQuestions = function () {
        $.ajax({
            url: optionsInternal.getQuestionsUrl,
            dataType: 'json',
            type: 'GET',
            async: true,
            success: function (data) {
                createQuestions(data);
            }
        });
    }

    var hideAll = function () {
        $(selectors.areaItem).hide();
    }

    var createQuestions = function (questions) {
        $(selectors.questionsList).empty();
        $.each(questions, function (index, value) {
            createQuestion(value);
        });
    }

    var createAnswers = function (answers) {
        $(selectors.answersList).empty();
        $.each(answers, function (index, value) {
            createAnswer(value);
        });
    }

    var createQuestion = function (question) {
        $('<a href="#">' + question.Title + '</a>')
            .data('id', question.Id)
            .click(function () {
                var id = $(this).data('id');
                openQuestion(id, openQuestionDetail);
            })
            .appendTo($('<h3>')
                .appendTo($('<div class="row-fluid">')
                    .appendTo(selectors.questionsList))).append($('<hr>'));
    }

    var createAnswer = function (answer) {
        $('<p>').text(answer.Content)
            .append($('<p class="text-right">').text(answer.User.Nickname)
            .append('<hr>'))
            .appendTo(selectors.answersList);
    }

    var openQuestionDetail = function (question) {
        $(selectors.questionDetail.title).text(question.Title);
        $(selectors.questionDetail.text).text(question.Content);
        $(selectors.questionDetail.user).text(question.User.Nickname);
        $(selectors.answerForm.button).data('id', question.Id);
        createAnswers(question.Answers);
        deselectMenu();
        openArea(selectors.question);
    }

    var openQuestion = function (id, callback) {
        $.ajax({
            url: optionsInternal.getQuestionUrl+id,
            dataType: 'json',
            type: 'GET',
            async: true,
            success: callback
        });
    }

    var createNewQuestion = function (callback) {
        $.ajax({
            url: optionsInternal.addQuestionUrl,
            dataType: 'json',
            type: 'POST',
            async: true,
            data: getQuestionFromForm(),
            success: callback
        });
    }

    var createNewAnswer = function (callback) {
        var answer = getAnswerFromForm();
        $.ajax({
            url: optionsInternal.addAnswerUrl,
            dataType: 'json',
            type: 'POST',
            async: true,
            data: answer,
            success: function () { callback(answer.answer) }
        });
    }

    var getQuestionFromForm = function () {
        var data = {
            title: $(selectors.askForm.title).val(),
            content: $(selectors.askForm.text).val(),
            user: { nickName: $(selectors.askForm.user).val() }
        };

        return data;
    }

    var getAnswerFromForm = function () {
        var data = {
            questionid: $(selectors.answerForm.button).data('id'),
            answer: {
                Content: $(selectors.answerForm.text).val(),
                User: { Nickname: $(selectors.answerForm.user).val() }
            }
        };

        return data;
    }

    return {
        init: initInternal
    };

}();