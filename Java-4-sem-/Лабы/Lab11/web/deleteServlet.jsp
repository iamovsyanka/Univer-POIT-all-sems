<%@ page import="DBConnection.Contacts" %>
<%@ page import="Models.Contact" %>
<%@ page import="java.util.ArrayList" %>
<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <title>Delete contact</title>
</head>
<body>
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
    <h3>Удалить контакт</h3>
    <form action="DeleteContactServlet" method="post">
        <label>Имя</label><br>
        <input name="name" type="text"/><br><br>
        <input type="submit" value="Удалить"/>
    </form>
</body>
</html>
