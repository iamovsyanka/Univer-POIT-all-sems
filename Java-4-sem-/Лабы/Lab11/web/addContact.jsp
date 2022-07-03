<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <title>Add Contact</title>
</head>
<body>
    <h3>Новый контакт</h3>
    <form action="AddContactServlet" method="post">
        <label>Имя</label><br>
        <input name="name" type="text"/><br><br>
        <label>Фамилия</label><br>
        <input name="surname" type="text"/><br><br>
        <label>Номер</label><br>
        <input name="phoneNumber" type="text"/><br><br>
        <input type="submit" value="Добавить"/>
    </form>
</body>
</html>
