package repository.dbconstants;

public enum ContactsTableConstants {
    ID("id"),
    SURNAME("surname"),
    PHONE("phone"),
    NAME("name");

    private String fieldName;

    private ContactsTableConstants(String fieldName) {
        this.fieldName = fieldName;
    }

    public String getFieldName() {
        return fieldName;
    }
}

