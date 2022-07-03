package Servlets;

import DBConnection.Contacts;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;

@WebServlet(name = "UpdateContactServlet", urlPatterns = "/UpdateContactServlet")
public class UpdateContactServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String name = request.getParameter("name");
        String phoneNumber = request.getParameter("phoneNumber");
        Contacts contacts = new Contacts();
        try {
            contacts.updateContact(name, phoneNumber);
            request.getRequestDispatcher("/welcome.jsp").forward(request, response);
        } catch (SQLException ex) {
            request.setAttribute("ErrorCode", ex.fillInStackTrace());
            request.setAttribute("ErrorMessage", ex.getMessage());
            request.getRequestDispatcher("/error.jsp").forward(request, response);
        }
    }
}
