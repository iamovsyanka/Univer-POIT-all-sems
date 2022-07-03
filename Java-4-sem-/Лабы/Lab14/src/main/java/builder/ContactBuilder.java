package builder;

import exception.RepositoryException;
import models.Contact;
import repository.dbconstants.ContactsTableConstants;

import java.sql.ResultSet;
import java.sql.SQLException;

public class ContactBuilder implements Builder<Contact> {
    @Override
    public Contact build(ResultSet resultSet) throws RepositoryException {
        try {
            int id = resultSet.getInt(ContactsTableConstants.ID.getFieldName());
            String name = resultSet.getString(ContactsTableConstants.NAME.getFieldName());
            String surname = resultSet.getString(ContactsTableConstants.SURNAME.getFieldName());
            String phone = resultSet.getString(ContactsTableConstants.PHONE.getFieldName());

            return new Contact(id, name, surname, phone);
        } catch (SQLException exception) {
            throw new RepositoryException(exception.getMessage(), exception);
        }
    }
}

