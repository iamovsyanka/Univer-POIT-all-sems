package command.grouppresons;

import services.ContactService;
import command.Command;
import command.CommandResult;
import exception.ServiceException;
import models.Contact;
import org.apache.log4j.Logger;
import pages.Page;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.List;
import java.util.Optional;

import static command.grouppresons.constant.GroupConstant.*;
import static command.grouppresons.constant.GroupConstant.LISTGROUP;
import static java.util.Optional.of;
import static org.apache.logging.log4j.util.Strings.isEmpty;

public class DeleteContactCommand implements Command {
    private static final Logger LOGGER = Logger.getLogger(DeleteContactCommand.class.getName());

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response)
            throws ServiceException {
        ContactService contactService = new ContactService();
        Optional<String> deleteName = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(DELETENAME));

        if (isEmpty(deleteName.get())) {
            LOGGER.info("missing parameter for new person in addition mode");
            request.setAttribute(ERROR_MESSAGE, ERROR_MESSAGE_TEXT);
        } else {
            contactService.deleteByName(deleteName.get());
        }
        List<Contact> clients = contactService.findAll();
        if (!clients.isEmpty()) {
            request.setAttribute(LISTGROUP, clients);
        }
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
}