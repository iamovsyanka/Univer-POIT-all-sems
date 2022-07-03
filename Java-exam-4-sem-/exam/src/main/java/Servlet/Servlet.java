package Servlet;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Enumeration;

@WebServlet(name = "Servlet", urlPatterns = "/Servlet")
public class Servlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter writer = response.getWriter();
        String check10 = (String) request.getAttribute("check10");
        String check100 = (String) request.getAttribute("check100");
        PrintWriter printWriter = response.getWriter();
        if(check10.equals("true") && check100.equals("true")){
            printWriter.println(request.getParameter("text")+check10+check100);
            Enumeration<String> headerNames = request.getHeaderNames();
            while(headerNames.hasMoreElements()){
                String name = headerNames.nextElement();
                String headerValues = request.getHeader(name);
                writer.println(name + ":  " + headerValues);
            }
        }
        else {
            request.getRequestDispatcher("/welcome.jsp").forward(request, response);
        }
    }
}
