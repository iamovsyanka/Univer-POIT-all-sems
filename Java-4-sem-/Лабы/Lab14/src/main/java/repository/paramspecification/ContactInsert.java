package repository.paramspecification;

import java.util.Arrays;
import java.util.List;

public class ContactInsert implements Parameter {
    private String name;
    private String surname;
    private String phone;

    public ContactInsert(String name, String surname, String phone) {
        this.name = name;
        this.surname = surname;
        this.phone = phone;
    }

    @Override
    public List<Object> getParameters() {
        return Arrays.asList(name, surname,phone);
    }
}
