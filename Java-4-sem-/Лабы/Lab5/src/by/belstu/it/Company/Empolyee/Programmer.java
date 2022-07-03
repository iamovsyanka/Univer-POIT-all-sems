package by.belstu.it.Company.Empolyee;

public class Programmer extends Employee {
    public Programmer(String name, int age, int experince, Qualification qualification) {
        super(name, age, experince, qualification);
    }

    @Override
    public int setSalary(Qualification qualifi) {
        System.out.println("salary for Programmer");
        switch (qualifi) {
            case junior:
                return 5000;
            case middle:
                return 10000;
            case senior:
                return 25000;
            default:
                return 0;
        }
    }
}
