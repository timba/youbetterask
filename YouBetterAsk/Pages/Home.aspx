<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="YouBetterAsk.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<script type="text/javascript" src="../Scripts/jquery-1.9.1.js"></script>
<script type="text/javascript" src="../Scripts/buzzlr.js"></script>
<link rel="stylesheet" href="../Content/styles.css" />
<link rel="stylesheet" href="../Content/bootstrap.css" />
<link rel="stylesheet" href="../Content/bootstrap-responsive.css" />
<script type="text/javascript">
    $(document).ready(function () {
        var options = {
            addQuestionUrl: '<%: Model.AddPostUrl %>',
            getQuestionUrl: '<%: Model.GetPostUrl %>',
            getQuestionsUrl: '<%: Model.GetPostsUrl %>',
            addAnswerUrl: '<%: Model.AddCommentUrl %>'
        };

        buzzlr.init(options);
    });        
</script>

<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="navbar-inner">
    <div class="container">
        <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        </button>
        <a class="brand" href="#">you better ask</a>
        <div class="nav-collapse collapse">
        <ul class="nav">
            <li class="active"><a href="#" class="menuitem" data-do="questions">Questions</a></li>
            <li><a class="menuitem" href="#" data-do="ask">Ask</a></li>
        </ul>
        </div>
    </div>
    </div>
</div>

<div class="container content">

</div>

</body>
</html>
