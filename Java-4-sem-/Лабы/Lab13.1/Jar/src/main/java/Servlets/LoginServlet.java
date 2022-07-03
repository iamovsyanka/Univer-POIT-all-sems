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
import java.util.logging.Logger;

@WebServlet(name = "Login", urlPatterns = "/Login")
public class LoginServlet extends HttpServlet {
    private final static Logger log = Logger.getLogger(LoginServlet.class.getName());

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html;charset=UTF-8");
        String login = request.getParameter("login");
        String password = request.getParameter("password");
        PrintWriter out = response.getWriter();
        try {
            log.info("User "+login+" try to connection");
            Users users = new Users();
            if (users.checkUser(login, password)) {
                response.sendRedirect("welcome.jsp");
            } else {
                request.setAttribute("message", "Ошибка в введенных данных");
                request.getRequestDispatcher("login.jsp").forward(request, response);
            }
        } catch (SQLException throwable) {
            out.println(throwable);
        } finally {
            out.close();
        }
    }

}
