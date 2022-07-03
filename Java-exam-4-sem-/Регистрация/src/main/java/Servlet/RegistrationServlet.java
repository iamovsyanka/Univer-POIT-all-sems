package Servlet;

import DAO.User;

import javax.servlet.annotation.WebServlet;
import java.io.IOException;
import java.sql.SQLException;

@WebServlet(name = "Registration", urlPatterns = "/Registration")
public class RegistrationServlet extends javax.servlet.http.HttpServlet {
    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        String login = request.getParameter("login");
        String password = request.getParameter("password");

        User user = new User();
        try {
            if(user.checkUser(login, password)) {
                request.setAttribute("message", "Такой пользователь существует");
                request.getRequestDispatcher("registration.jsp").forward(request, response);
            }
            else{
                user.addUser(login, password);
                response.sendRedirect("welcome.jsp");
            }
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
    }
}
