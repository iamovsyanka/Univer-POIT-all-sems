<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Register</title>
</head>
<body>
    <h3 style="color: red">${message}</h3>
    <fieldset>
        <legend>Registration</legend>
        <form method="POST" action="Registration">
            <input name="login" type="text" placeholder="login"/>
            <input name="password" type="text" placeholder="password"/>
            <input type="submit" value="Регистрация"/>
        </form>
    </fieldset>
    <form method="POST" action="GoToLogin">
        <input type="submit" value="Войти"/>
    </form>
</body>
</html>
