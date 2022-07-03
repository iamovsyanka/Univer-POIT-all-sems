package by.belstu.it.Company.Factory;

import by.belstu.it.Company.Empolyee.Programmer;

public class ProgrammerFactory implements Factory<Programmer> {
    @Override
    public void addEmployee(Manager manager, Programmer employee) {
        manager.add(employee);
    }

    @Override
    public void removeEmployee(Manager manager, Programmer employee) {
        manager.remove(employee);
    }
}
