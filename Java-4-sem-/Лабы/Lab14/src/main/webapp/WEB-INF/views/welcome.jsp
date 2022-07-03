<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Welcome</title>
</head>
<body>
    <h3>Контакты:</h3>
    <table style="background: cornflowerblue">
        <c:forEach items="${group}" var="Contact">
            <tr>
                <td>${Contact.name}</td>
                <td>${Contact.surname}</td>
                <td>${Contact.phone}</td>
            </tr>
        </c:forEach>
    </table>
    <div>
        <p style="background: red">${errorMessage}</p>
        <form method="POST" action="${pageContext.servletContext.contextPath}/controller?command=add_new_contact">
            Добавить новый контакт:
            <p>Имя<input name="nname" type="text"/></p>
            <p>Фамилия<input name="nsurname" type="text"/></p>
            <p>Телефон<input name="nphone" type="text"/></p>
            <input class ="button-main-page" value="Add" type="submit" />
        </form>
    </div>
    <div>
        <p style="background: red">${errorMessage}</p>
        <form method="POST" action="${pageContext.servletContext.contextPath}/controller?command=delete_contact">
            Удалить контакт по имени:
            <p>Имя<input name="dname" type="text"/></p>
            <input class ="button-main-page" value="Add" type="submit" />
        </form>
    </div>
</body>
</html>
