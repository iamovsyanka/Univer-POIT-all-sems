package command.authorithation;

import services.UserService;
import command.Command;
import command.CommandResult;
import exception.ServiceException;
import models.User;
import org.apache.log4j.Logger;
import pages.Page;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.Optional;

import static command.authorithation.contants.AuthConstants.*;
import static java.util.Optional.of;
import static org.apache.logging.log4j.util.Strings.isEmpty;

public class RegisterNewUserCommand implements Command {
    private static final Logger LOGGER = Logger.getLogger(RegisterNewUserCommand.class.getName());

    private CommandResult forwardToRegisterWithError(HttpServletRequest request, String ERROR, String ERROR_MESSAGE) {
        request.setAttribute(ERROR, ERROR_MESSAGE);
        return new CommandResult(Page.REGISTER_PAGE.getPage(), false);
    }

    private CommandResult forwardToLogin(HttpServletRequest request) {
        return new CommandResult(Page.LOGIN_PAGE.getPage(), false);
    }

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response)
            throws ServiceException {
        Optional<String> login = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(NAME_FOR_REGISTER));
        Optional<String> password = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(PASSWORD_FOR_REGISTER));
        if (isEmpty(login.get()) || isEmpty(password.get())) {
            LOGGER.info("invalid login or password format was received:" + login + " " + password);
            return forwardToRegisterWithError(request, REGISTER_ERROR, ERROR_MESSAGE_TEXT);
        }
        String hashedPassword = String.valueOf(password.hashCode());
        User user = new User(login.get(), hashedPassword);
        UserService userService = new UserService();
        int userCount = userService.save(user);
        if (userCount != 0) {
            LOGGER.info("user was registered: login:" + login + " password:" + password);
            return forwardToLogin(request);
        } else {
            LOGGER.info("invalid login or password format was received:" + login + " " + password);
            return forwardToRegisterWithError(request, REGISTER_ERROR, REGISTER_ERROR_MESSAGE_IF_EXIST);
        }
    }
}
