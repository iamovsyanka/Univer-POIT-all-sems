<%--
  Created by IntelliJ IDEA.
  User: Onya
  Date: 22.06.2020
  Time: 00:27
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>registration</title>
</head>
<body>
<p>${message}</p>
    <fieldset>
        <legend>Регистрация</legend>
        <form action="Registration" method="post">
            <input type="text" name="login" placeholder="login">
            <input name="password" type="text" placeholder="password">
            <input type="submit" value="ok">
        </form>
    </fieldset>
</body>
</html>
