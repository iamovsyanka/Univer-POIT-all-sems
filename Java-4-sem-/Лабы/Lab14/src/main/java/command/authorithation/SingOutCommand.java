package command.authorithation;


import command.Command;
import command.CommandResult;
import command.session.SessionAttribute;
import exception.IncorrectDataException;
import exception.ServiceException;
import org.apache.log4j.Logger;
import pages.Page;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class SingOutCommand implements Command {
    private static final Logger LOGGER = Logger.getLogger(SingOutCommand.class.getName());

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) {
        HttpSession session = request.getSession();
        String username = (String) session.getAttribute(SessionAttribute.NAME);
        LOGGER.info("user was above: name:" + username);
        session.removeAttribute(SessionAttribute.NAME);
        return new CommandResult(Page.LOGIN_PAGE.getPage(), false);
    }
}
