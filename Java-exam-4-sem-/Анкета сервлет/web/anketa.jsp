<%--
  Created by IntelliJ IDEA.
  User: Onya
  Date: 22.06.2020
  Time: 17:18
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>anketa</title>
</head>
<body>
    <form action="Check" method="post">
        <label>Сейчас 2020 год?</label>
        <input type="radio" name="year" value="yes">Yes
        <input type="radio" name="year" value="no">No
        <br>
        <label>Сейчас июнь?</label>
        <input type="radio" name="month" value="yes">Yes
        <input type="radio" name="month" value="no">No
        <br>
        <input type="submit" value="check">
    </form>
</body>
</html>
