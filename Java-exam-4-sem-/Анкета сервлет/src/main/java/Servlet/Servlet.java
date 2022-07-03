package Servlet;

import javax.servlet.annotation.WebServlet;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

@WebServlet(name = "Check", urlPatterns = "/Check")
public class Servlet extends javax.servlet.http.HttpServlet {
    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        int answer = 0;
        Calendar calendar = Calendar.getInstance();
        if(request.getParameter("year")!=null)
        {
            if(request.getParameter("year").equals("yes") && calendar.get(Calendar.YEAR) == 2020)
            {
                answer +=5;
            }
        }
        if(request.getParameter("month")!=null)
        {
            if(request.getParameter("month").equals("yes") && calendar.get(Calendar.DAY_OF_MONTH) == 5)
            {
                answer +=5;
            }
        }

        PrintWriter out = response.getWriter();
        out.println(answer);
    }
}
