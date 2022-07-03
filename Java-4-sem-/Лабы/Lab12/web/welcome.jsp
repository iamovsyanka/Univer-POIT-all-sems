<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="my" uri="MyTag.tld" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Welcome</title>
</head>
<body>
<form action="table.jsp" method="post">
    <my:KAOLabledTextField label="Номер лабы: " name="Lab"/><br/>
    <my:KAOLabledTextField label="Количество слез: " name="T_T"/><br/>
    <my:KAOSubmit label="Ok"/>
</form>
</body>
</html>
