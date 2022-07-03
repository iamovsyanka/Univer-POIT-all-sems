package Servlet;

import DAO.User;

import java.io.IOException;
import java.sql.SQLException;
import javax.servlet.annotation.WebServlet;

@WebServlet(name = "Login", urlPatterns = "/Login")
public class LoginServlet extends javax.servlet.http.HttpServlet {
    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        String login = request.getParameter("login");
        String password = request.getParameter("password");

        User user = new User();
        try {
            if(user.checkUser(login, password)) {
                response.sendRedirect("welcome.jsp");
            }
            else{
                response.sendRedirect("error.jsp");
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
}
