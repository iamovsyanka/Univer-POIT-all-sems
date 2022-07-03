<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="my" uri="MyTag.tld" %>
<html>
<head>
    <title>Authorize</title>
    </head>
<body>
    <h3 style="color: red">${message}</h3>
    <fieldset>
        <legend>Authorize</legend>
        <form action="Login" method="POST">
            <my:KAOLabledTextField name="login" label="login"/>
            <my:KAOLabledTextField name="password" label="password"/>
            <my:KAOSubmit label="Войти"/>
        </form>
    </fieldset>
    <form action="GoToRegister" method="POST">
        <my:KAOSubmit label="Регистрация"/>
    </form>
</body>
</html>
