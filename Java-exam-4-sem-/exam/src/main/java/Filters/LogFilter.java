package Filters;

import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Enumeration;
import java.util.logging.Logger;

@WebFilter(filterName = "LogFilter")
public class LogFilter implements javax.servlet.Filter {
    Logger LOGGER = Logger.getLogger(LogFilter.class.getName());

    public void destroy() {
    }

    public void doFilter(javax.servlet.ServletRequest req, javax.servlet.ServletResponse resp, javax.servlet.FilterChain chain) throws javax.servlet.ServletException, IOException {
        int number = Integer.parseInt(req.getParameter("text"));
        LOGGER.info("Current time is: " + LocalDateTime.now());
        LOGGER.info(String.valueOf(number));
        if(number > 10) {
            req.setAttribute("check10", "true");
        }
        else {
            req.setAttribute("check10", "false");
        }
        HttpServletRequest httpRequest = (HttpServletRequest)req;
        Enumeration<String> headerNames = httpRequest.getHeaderNames();

        if (headerNames != null) {
            req.setAttribute("Header", httpRequest.getHeader(headerNames.nextElement()));
        }
        chain.doFilter(req, resp);
    }

    public void init(javax.servlet.FilterConfig config) throws javax.servlet.ServletException {

    }

}
