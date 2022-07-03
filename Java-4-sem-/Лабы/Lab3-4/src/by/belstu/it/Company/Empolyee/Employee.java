package by.belstu.it.Company.Empolyee;

abstract public class Employee {
    private String name;
    private int age;
    private int experience;
    private int salary;
    private Qualification qualification;

    public Qualification getQualification() {
        return qualification;
    }

    public void setQualification(Qualification qualification) {
        this.qualification = qualification;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public int getExperience() {
        return experience;
    }

    public int getSalary() {
        return salary;
    }

    public abstract int setSalary(Qualification qualifi);

    public Employee(String name, int age, int experience, Qualification qualification) {
        this.name = name;
        this.age = age;
        this.experience = experience;
        this.qualification = qualification;
    }

    @Override
    public String toString() {
        String emplr = null;
        if (this instanceof Engineer) emplr = "Engineer";
        else if (this instanceof Sysadmin) emplr = "SysAdmin";
        else if (this instanceof Programmer) emplr = "Programmer";
        return emplr +
                "name='" + name + '\'' +
                ", age=" + age +
                ", experience=" + experience +
                ", salary=" + salary +
                ", qualification=" + qualification +
                '}';
    }
}
