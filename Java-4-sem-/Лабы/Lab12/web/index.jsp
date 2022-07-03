<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
  <head>
    <title>Lab12</title>
    <style>
      .horizontal {
        display: inline-block;
        margin-right: 100px;
      }
    </style>
  </head>
  <body>
    <div>
      <form method="POST" action="GoToLogin">
        <input type="submit" value="Окно авторизации"/>
      </form>
    </div>

    <fieldset>
      <legend>Применение тегов</legend>
        <form action="Tags/core.jsp">
          <input type="submit" value="Теги core">
        </form>
      <form action="Tags/formatting.jsp">
        <input type="submit" value="Теги formatting">
      </form>
      <form action="Tags/sql.jsp">
        <input type="submit" value="Теги sql">
      </form>
      <form action="Tags/xml.jsp">
        <input type="submit" value="Теги xml">
      </form>
      <form action="Tags/functions.jsp">
        <input type="submit" value="Теги functions">
      </form>
    </fieldset>
  </body>
</html>
