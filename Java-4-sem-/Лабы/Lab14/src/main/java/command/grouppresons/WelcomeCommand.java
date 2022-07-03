package command.grouppresons;

import services.ContactService;
import command.Command;
import command.CommandResult;
import exception.ServiceException;
import models.Contact;
import pages.Page;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.List;

import static command.grouppresons.constant.GroupConstant.LISTGROUP;

public class WelcomeCommand implements Command {
    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response)
            throws ServiceException {

        ContactService contactService = new ContactService();
        List<Contact> contacts = contactService.findAll();
        if (!contacts.isEmpty()) {
            request.setAttribute(LISTGROUP, contacts);
        }
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
}

