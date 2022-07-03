<%@ page import="java.io.PrintWriter" %><%--
  Created by IntelliJ IDEA.
  User: Onya
  Date: 23.06.2020
  Time: 18:17
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>cookie</title>
</head>
<body>
    <form action="Cookie" method="post">
        <input type="text" name="text">
        <input type="submit" value="ok">
    </form>
    <%
        PrintWriter printWriter = response.getWriter();
        Cookie[] cookies = request.getCookies();
        if(cookies != null) {
            for (Cookie cookie : cookies) {
                if(!cookie.getName().equals("JSESSIONID")) {
                    printWriter.println(cookie.getName() + " " + cookie.getValue());
                    printWriter.println("<br>");
                }
            }
        }
    %>
</body>
</html>
