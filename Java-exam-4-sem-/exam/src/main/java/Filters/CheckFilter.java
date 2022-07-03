package Filters;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Enumeration;

@WebFilter(filterName = "CheckFilter")
public class CheckFilter implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        int number = Integer.parseInt(req.getParameter("text"));
        if(number < 100) {
            req.setAttribute("check100", "true");
        }
        else {
            req.setAttribute("check100", "false");
        }
        chain.doFilter(req, resp);
    }

    public void init(FilterConfig config) throws ServletException {

    }

}
