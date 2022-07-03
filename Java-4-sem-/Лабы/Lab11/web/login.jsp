<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <title>Authorize</title>
    </head>
<body>
    <%@include file="header.jsp"%><br>
    <h3 style="color: red">${message}</h3>
    <fieldset>
        <legend>Authorize</legend>
        <form action="Login" method="POST">
            <input name="login" type="text" placeholder="login"/>
            <input name="password" type="text" placeholder="password"/>
            <input type="submit" value="Войти"/>
        </form>
    </fieldset>
    <form action="GoToRegister" method="POST">
        <input type="submit" value="Регистрация"/>
    </form>
    <%@include file="footer.jsp"%><br>
</body>
</html>
