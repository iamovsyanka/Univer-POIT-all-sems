package DBConnection;

import Models.Contact;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class Contacts {
    private final DBConnection connectionCreator = new DBConnection();

    public List<Contact> selectContacts() {
        List<Contact> contacts = new ArrayList<Contact>();
        try {
            Connection connection = connectionCreator.createConnection();
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery("SELECT * FROM contacts");
            while (resultSet.next()) {
                String name = resultSet.getString("Name");
                String surname = resultSet.getString("Surname");
                String phoneNumber = resultSet.getString("PhoneNumber");
                Contact contact = new Contact(name, surname, phoneNumber);
                contacts.add(contact);
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }

        return contacts;
    }

    public void addContact(String name,String surname, String phoneNumber) throws SQLException {
        String query = "INSERT INTO contacts (Name, Surname, PhoneNumber) VALUES (?, ?, ?); ";
        Connection connection = connectionCreator.createConnection();
        PreparedStatement statement = connection.prepareStatement(query);
        statement.setString(1, name);
        statement.setString(2, surname);
        statement.setString(3, phoneNumber);
        statement.executeUpdate();
        statement.close();
    }

    public void updateContact(String name, String phoneNumber) throws SQLException {
        String query = "UPDATE java.contacts SET PhoneNumber = ? WHERE (Name = ?);";
        Connection connection = connectionCreator.createConnection();
        PreparedStatement statement = connection.prepareStatement(query);
        statement.setString(1, phoneNumber);
        statement.setString(2, name);
        statement.executeUpdate();
        statement.close();
    }

    public void deleteContact(String name) throws SQLException {
        String query = "DELETE FROM contacts WHERE (Name = ?);";
        Connection connection = connectionCreator.createConnection();
        PreparedStatement statement = connection.prepareStatement(query);
        statement.setString(1, name);
        statement.executeUpdate();
        statement.close();
    }
}

