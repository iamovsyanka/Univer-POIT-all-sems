package by.belstu.it.Company.Factory;

import by.belstu.it.Company.Empolyee.Employee;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Manager implements Comparator<Employee> {
    private List<Employee> employees;

    public Manager() {
        employees = new ArrayList<>();
    }

    public List<Employee> getEmployees() {
        return employees;
    }

    public void setEmployees(List<Employee> employees) {
        this.employees = employees;
    }

    public void add(Employee employee) {
        this.employees.add(employee);
    }

    public void remove(Employee employee) {
        this.employees.remove(employee);
    }

    @Override
    public int compare(Employee o1, Employee o2) {
        return Integer.compare(o1.getExperience(), o2.getExperience());
    }
}
