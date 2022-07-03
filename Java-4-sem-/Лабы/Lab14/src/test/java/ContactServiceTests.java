import services.ContactService;
import exception.ServiceException;
import models.Contact;
import org.junit.Assert;
import org.junit.Test;

public class ContactServiceTests extends Assert {

    @Test
    public void addContactTest() throws ServiceException {
        ContactService contactService = new ContactService();
        Contact newContact = new Contact(0,"ПИТОР", "ПАРКЕР","ДОМАШНИЙ");
        contactService.save(newContact);
    }

    @Test
    public void removeContactTest() {
        ContactService contactService = new ContactService();
        contactService.deleteByName("ПИТОР");
    }
}
