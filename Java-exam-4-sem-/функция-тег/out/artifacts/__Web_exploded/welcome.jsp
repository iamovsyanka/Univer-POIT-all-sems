<%@ taglib prefix="func" uri="func" %>
<%--
  Created by IntelliJ IDEA.
  User: Onya
  Date: 23.06.2020
  Time: 22:52
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>welcome</title>
</head>
<body>
    <form action="Servlet" method="get">
        <input type="text" name="str">
        <input type="submit" value="check">
    </form>
    ${str}
    ${func:checkPassport(str)}
</body>
</html>
