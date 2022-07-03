package DBConnection;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Users {

    private final DBConnection connectionCreator = new DBConnection();

    public Users() throws SQLException {
    }

    public void addUser(String login, String password) throws SQLException {
        String query = " INSERT INTO users(Name, Password) VALUES (?, ?)";
        Connection connection = connectionCreator.createConnection();
        PreparedStatement statement = connection.prepareStatement(query);
        statement.setString(1, login);
        statement.setInt(2, password.hashCode());
        statement.executeUpdate();
    }

    public boolean checkUser(String login, String password) throws SQLException {
        Connection connection = connectionCreator.createConnection();
        PreparedStatement statement = connection.prepareStatement("SELECT Password FROM users WHERE Name='" + login + "'");
        ResultSet resultSet = statement.executeQuery();
        if (resultSet.next()) {
            int retrievedPassword = resultSet.getInt(1);
            if (retrievedPassword == password.hashCode()) {
                return true;
            }
        }
        return false;
    }
}
