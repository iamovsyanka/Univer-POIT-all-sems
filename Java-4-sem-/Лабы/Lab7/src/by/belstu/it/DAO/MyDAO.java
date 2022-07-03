package by.belstu.it.DAO;

import java.sql.*;
import java.util.ResourceBundle;

public class MyDAO implements DAO {
    ResourceBundle resource = ResourceBundle.getBundle("DB");
    private String user = resource.getString("DB.user");
    private String password = resource.getString("DB.password");
    private String url = resource.getString("DB.url");

    public MyDAO() {
        try {
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public Connection getConnection() throws SQLException {
        return DriverManager.getConnection(url, user, password);
    }
}
