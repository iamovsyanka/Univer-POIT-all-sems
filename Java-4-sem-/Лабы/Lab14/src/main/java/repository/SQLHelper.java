package repository;

import repository.dbconstants.ContactsTableConstants;
import repository.dbconstants.UserTableConstants;

import java.util.Map;

public class SQLHelper {
    public static final String ID = "id";
    private static final String INSERT_QUERY = "INSERT INTO ";
    private static final String VALUES = "VALUES";
    private static final String WHERE = "WHERE ";
    private static final String SELECT = "SELECT";
    public static final String USER_TABLE = "users";
    public static final String CONTACT_TABLE = "contacts";

    public final static String SQL_GET_CONTACTS = "select * from " + CONTACT_TABLE;
    public final static String SQL_GET_USER = "SELECT " + UserTableConstants.ID.getFieldName() + ", " +
            UserTableConstants.LOGIN.getFieldName() + ", " +
            UserTableConstants.PASSWORD.getFieldName() + " from " + USER_TABLE + " WHERE " +
            UserTableConstants.LOGIN.getFieldName() + " =? and " +
            UserTableConstants.PASSWORD.getFieldName() + " =?";
    public final static String SQL_CHECK_LOGIN = "SELECT  " + UserTableConstants.LOGIN.getFieldName() + " FROM " +
            USER_TABLE + " WHERE " + UserTableConstants.LOGIN.getFieldName() + " = ?";
    public final static String SQL_INSERT_USER = "INSERT INTO " + USER_TABLE + "(" +
            UserTableConstants.LOGIN.getFieldName() + " ," +
            UserTableConstants.PASSWORD.getFieldName() + ") VALUES (? , ?)";
    public final static String SQL_INSERT_CONTACT = INSERT_QUERY + CONTACT_TABLE + "(" +
            ContactsTableConstants.NAME + " ," +
            ContactsTableConstants.SURNAME + " ," +
            ContactsTableConstants.PHONE + ") VALUES(? , ? , ?)";

    public static String makeInsertQuery(Map<String, Object> fields, String table) {
        StringBuilder columns = new StringBuilder("(");
        StringBuilder values = new StringBuilder("(");

        for (Map.Entry<String, Object> entry : fields.entrySet()) {
            String column = entry.getKey();
            if (column.equals(ID)) {
                continue;
            }
            columns.append(column).append(", ");
            values.append("?, ");
        }

        values.deleteCharAt(values.lastIndexOf(","));
        columns.deleteCharAt(columns.lastIndexOf(","));
        values.append(")");
        columns.append(")");

        return INSERT_QUERY + table + columns + VALUES + values + ";";
    }

    public static String deleteByNameQuery(String name, String table) {
        return "DELETE FROM " + table + " WHERE name = \"" + name + "\";";
    }
}
