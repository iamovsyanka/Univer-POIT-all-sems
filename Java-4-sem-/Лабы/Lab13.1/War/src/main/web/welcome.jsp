<%@ page import="DBConnection.Contacts" %>
<%@ page import="Models.Contact" %>
<%@ page import="java.util.ArrayList" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Welcome</title>
    <style>
        .horizontal {
            display: inline-block;
            margin-right: 100px;
        }
    </style>
</head>
<body>
    <%@include file="header.jsp"%><br>
    <h3>Контакты:</h3>
    <%

        Contacts contacts = new Contacts();
        try {
            ArrayList<Contact> contactArrayList = contacts.selectContacts();
            for (Contact con : contactArrayList) {
    %>
    <table>
        <tr>
            <td> <%= con.getName() %> </td>
            <td><%= con.getSurname()%></td>
            <td><%= con.getPhoneNumber()%></td>
        </tr>
    </table>
    <%
            }
        }catch (Exception e){
            System.out.println(e);
        }
    %>

    <form action="addContact.jsp" method="POST" class="horizontal">
        <input type="submit" value="Добавить"/>
    </form>
    <form action="deleteServlet.jsp" method="POST" class="horizontal">
        <input type="submit" value="Удалить"/>
    </form>
    <form action="updateContact.jsp" method="POST" class="horizontal">
        <input type="submit" value="Изменить"/>
    </form>
</body>
</html>
