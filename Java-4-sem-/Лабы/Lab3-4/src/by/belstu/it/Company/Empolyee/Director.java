package by.belstu.it.Company.Empolyee;

import by.belstu.it.Company.Factory.Manager;

import java.util.Collections;

public class Director {
    private final String name = "Alex";
    private final int salary = 1000000;
    private static Director director;

    public static Director getDirector() {
        if (director == null) {
            director = new Director();
        }

        return director;
    }

    @Override
    public String toString() {
        return "Director{" +
                "name='" + name + '\'' +
                ", salary=" + salary +
                '}';
    }

    public int getCountEmployees(Manager manager) {
        return manager.getEmployees().size();
    }

    public void salarySort(Manager manager) {
        manager.getEmployees().sort(manager);
    }

    public void findEmployee(Manager manager, Qualification qualification) {
        manager.getEmployees()
                .stream().filter(employee -> employee.getQualification().equals(qualification))
                .forEach(System.out::println);
    }

    public class deputyDirector {
        private final String name = "Olga";
        private final int salary = 100000;

        public void getCoffee() {
            System.out.println("Alex, I brought coffee!");
        }
    }
}
