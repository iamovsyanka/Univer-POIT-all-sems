package by.belstu.it.Company.Factory;

public interface Factory<T> {
    void addEmployee(Manager manager, T employee);

    void removeEmployee(Manager manager, T employee);
}
