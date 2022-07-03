<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<html>
<head>
    <title>Core</title>
</head>
<body>
    <p>~~~~~~~Проверка условия</p>
        <c:set var="java" value="good" scope="page"/>
        <c:if test="${ not empty java and java eq 'good' }">
            Java is смэрц
        </c:if>
    <br/>
    <p>~~~~~~~Вычисление</p>
        <c:out value = "234 + 45 * 2 = "/><c:out value="${234 + 45 * 2}"/>
    <br/>
    <p>~~~~~~~Теги условного перехода</p>
        <c:set var="number" value="50"/>
        <c:choose>
            <c:when test="${ number > 10 }" >
                <c:out value="число ${ number } больше 10"/>
            </c:when>
            <c:when test="${ number > 40 }" >
                <c:out value="число ${ number } больше 40"/>
            </c:when>
            <c:when test="${ number > 60 }" >
                <c:out value="число ${ number } больше 60"/>
            </c:when>
            <c:otherwise>
                <c:out value="число ${ number } меньше 10"/>
            </c:otherwise>
        </c:choose>
    <br/>
    <p>~~~~~~~Обработка исключений</p>
    <c:catch var="ArithmeticException">
        <% int num = 0 / 0; %>
    </c:catch>
    The Exception is : ${ArithmeticException}
    <c:catch var="Exception">
        <% int num = 0 / 'a'; %>
    </c:catch>
    The Exception is : ${Exception}
<br/>
</body>
</html>
