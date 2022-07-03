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

@WebServlet(name = "Login", urlPatterns = {"/Login"})
public class LoginServlet extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html;charset=UTF-8");
        String login = request.getParameter("login");
        String password = request.getParameter("password");
        PrintWriter writer = response.getWriter();
        try {
            Users users = new Users();
            if (users.checkUser(login, password)) {
                request.getRequestDispatcher("/welcome.jsp").forward(request, response);
            } else {
                request.setAttribute("message", "Ошибка в введенных данных");
                request.getRequestDispatcher("/login.jsp").forward(request, response);
            }
        } catch (SQLException | ServletException ex) {
            request.setAttribute("ErrorCode", ex.fillInStackTrace());
            request.setAttribute("ErrorMessage", ex.getMessage());
            request.getRequestDispatcher("/error.jsp").forward(request, response);
        } finally {
            writer.close();
        }
    }

}
