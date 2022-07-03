package by.belstu.it.Company.Empolyee;

public class Engineer extends Employee {

    public Engineer(String name, int age, int experince, Qualification qualification) {
        super(name, age, experince, qualification);
    }

    @Override
    public int setSalary(Qualification qualifi) {
        System.out.println("salary for Engineer");
        switch (qualifi) {
            case junior:
                return 500;
            case middle:
                return 1000;
            case senior:
                return 2500;
            default:
                return 0;
        }
    }
}
