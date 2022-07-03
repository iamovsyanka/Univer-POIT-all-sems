package DBConnection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;
import java.util.ResourceBundle;

public class DBConnection {
    private String url;
    private String user;
    private String password;

    public DBConnection() {
        ResourceBundle resource = ResourceBundle.getBundle("db");
        url = resource.getString("db.url");
        user = resource.getString("db.user");
        password = resource.getString("db.password");
    }

    public Connection createConnection() throws SQLException {
        Properties properties = new Properties();
        properties.put("user", user);
        properties.put("password", password);
        System.out.println("trying");
        Connection connection = DriverManager.getConnection(url, properties);
        System.out.println("connected");

        return connection;
    }
}