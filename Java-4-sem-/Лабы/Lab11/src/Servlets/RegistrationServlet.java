package Servlets;

import DBConnection.Users;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;

@WebServlet(name = "Registration", urlPatterns = {"/Registration"})
public class RegistrationServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        String login = request.getParameter("login");
        String password = request.getParameter("password");
        PrintWriter writer = response.getWriter();
        try {
            if (login.equals("")) {
                request.setAttribute("message", "Введите логин");
                request.getRequestDispatcher("/registration.jsp").forward(request, response);
            }

            if (password.equals("")) {
                request.setAttribute("message", "Введите пароль");
                request.getRequestDispatcher("/registration.jsp").forward(request, response);
            }

            Users users = new Users();
            if (!users.checkUser(login, password)) {
                users.addUser(login, password);
            } else {
                request.setAttribute("message", "Такой пользователь уже существует");
                request.getRequestDispatcher("/registration.jsp").forward(request, response);
            }
        } catch (SQLException ex) {
            request.setAttribute("ErrorCode", ex.getErrorCode());
            request.setAttribute("ErrorMessage", ex.getMessage());
            request.getRequestDispatcher("/error.jsp").forward(request, response);
        } finally {
            writer.close();
        }
    }
}
