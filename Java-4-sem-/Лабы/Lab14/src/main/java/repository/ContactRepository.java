package repository;

import builder.ContactBuilder;
import exception.RepositoryException;
import models.Contact;
import repository.dbconstants.ContactsTableConstants;
import repository.paramspecification.Parameter;

import java.sql.Connection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

public class ContactRepository extends AbstractRepository<Contact> {
    public ContactRepository(Connection connection) {
        super(connection);
    }

    @Override
    protected String getTableName() {
        return SQLHelper.CONTACT_TABLE;
    }

    @Override
    public List<Contact> query(String sqlString, Parameter paramater) throws RepositoryException {
        List<Contact> contacts = executeQuery(sqlString, new ContactBuilder(), paramater.getParameters());
        return contacts;
    }

    @Override
    public Optional<Contact> queryForSingleResult(String sqlString, Parameter parameter) throws RepositoryException {
        List<Contact> contacts = query(sqlString, parameter);
        return contacts.size() == 1 ?
                Optional.of(contacts.get(0)) :
                Optional.empty();
    }

    public Map<String, Object> getFields(Contact contact) {
        Map<String, Object> fields = new HashMap<>();
        fields.put(ContactsTableConstants.NAME.getFieldName(), contact.getName());
        fields.put(ContactsTableConstants.SURNAME.getFieldName(), contact.getSurname());
        fields.put(ContactsTableConstants.PHONE.getFieldName(), contact.getPhone());
        return fields;
    }
}