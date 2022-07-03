package builder;

public class BuilderFactory {
    private static final String USER = "user";
    private static final String CONTACTS = "contacts";
    private static final String MESSAGE = "Unknown Builder name!";

    public static Builder create(String builderName) {
        switch (builderName) {
            case USER: {
                return new UserBuilder();
            }
            case CONTACTS: {
                return new ContactBuilder();
            }
            default:
                throw new IllegalArgumentException(MESSAGE);
        }
    }
}
