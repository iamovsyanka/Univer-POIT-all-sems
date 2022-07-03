<%@ page import="DBConnection.Contacts" %>
<%@ page import="Models.Contact" %>
<%@ page import="java.util.ArrayList" %>
<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <title>Update contact</title>
</head>
<body>
    <h3>Изменить контакт</h3>
    <%
        Contacts contacts = new Contacts();
        try {
            ArrayList<Contact> contactArrayList = contacts.selectContacts();
            for (Contact con : contactArrayList) {
    %>
    <table>
        <tr>
            <td> <%= con.getName() %> </td>
        </tr>
    </table>
    <%
            }
        }catch (Exception e){
            System.out.println(e);
        }
    %>
    <form action="UpdateContactServlet" method="post">
        <label>Имя для изменения</label><br>
        <input name="name" type="text"/><br><br>
        <label>Новый номер</label><br>
        <input name="phoneNumber" type="text"/><br><br>
        <input type="submit" value="Изменить"/>
    </form>
</body>
</html>
