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
import static java.util.Optional.of;
import static org.apache.logging.log4j.util.Strings.isEmpty;

public class AddNewContactCommand implements Command {
    private static final Logger LOGGER = Logger.getLogger(AddNewContactCommand.class.getName());

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response)
            throws ServiceException {

        ContactService contactService = new ContactService();
        Optional<String> newName = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(NEWNAME));
        Optional<String> newSurname = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(NEWSURNAME));
        Optional<String> newPhone = of(request)
                .map(httpServletRequest -> httpServletRequest.getParameter(NEWPHONE));

        if (isEmpty(newName.get()) || isEmpty(newSurname.get()) || isEmpty(newPhone.get())) {
            LOGGER.info("missing parameter for new person in addition mode");
            request.setAttribute(ERROR_MESSAGE, ERROR_MESSAGE_TEXT);
        } else {
            Contact newContact = new Contact(0, newName.get(), newSurname.get(), newPhone.get());
            contactService.save(newContact);
        }
        List<Contact> clients = contactService.findAll();
        if (!clients.isEmpty()) {
            request.setAttribute(LISTGROUP, clients);
        }
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
}