package by.belstu.it.Company.Empolyee;

public class Sysadmin extends Employee {
    public Sysadmin(String name, int age, int experince, Qualification qualification) {
        super(name, age, experince, qualification);
    }

    @Override
    public int setSalary(Qualification qualifi) {
        System.out.println("salary for Sysadmin");
        switch (qualifi) {
            case junior:
                return 50;
            case middle:
                return 100;
            case senior:
                return 250;
            default:
                return 0;
        }
    }
}
