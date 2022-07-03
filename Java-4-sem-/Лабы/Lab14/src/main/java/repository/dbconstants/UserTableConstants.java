package repository.dbconstants;

public enum UserTableConstants {
    ID("id"),
    LOGIN("login"),
    PASSWORD("password");

    private String fieldName;

    private UserTableConstants(String fieldName) {
        this.fieldName = fieldName;
    }

    public String getFieldName() {
        return fieldName;
    }
}


