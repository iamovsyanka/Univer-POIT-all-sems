<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Authorize</title>
    </head>
<body>
    <h3 style="color: red">${message}</h3>
    <fieldset>
        <legend>Authorize</legend>
        <form action="${pageContext.servletContext.contextPath}/controller?command=login" method="POST">
            <input name="login" type="text" placeholder="login"/>
            <input name="password" type="text" placeholder="password"/>
            <input type="submit" value="Войти"/>
        </form>
    </fieldset>

</body>
</html>
