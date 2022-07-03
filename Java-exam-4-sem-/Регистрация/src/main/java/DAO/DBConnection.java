package DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class DBConnection {
    private String url;
    private String user;
    private String password;

    public DBConnection() {
        url = "jdbc:mysql://localhost:3306/java?useUnicode=true&serverTimezone=UTC&useSSL=false";
        user = "Java";
        password = "MySQLforJava!";
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
