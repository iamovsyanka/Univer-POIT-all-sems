package Servlet;

import javax.servlet.http.Cookie;
import java.io.IOException;

public class CookieServlet extends javax.servlet.http.HttpServlet {
    int numberCookie = 0;

    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        String text =  request.getParameter("text");
        Cookie cookie = new Cookie(String.valueOf(numberCookie++), text);
        response.addCookie(cookie);
        request.getRequestDispatcher("cookie.jsp").forward(request, response);
    }

    protected void doGet(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {

    }
}
