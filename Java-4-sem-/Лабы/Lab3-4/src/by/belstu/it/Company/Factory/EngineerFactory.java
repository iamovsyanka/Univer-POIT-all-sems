package by.belstu.it.Company.Factory;

import by.belstu.it.Company.Empolyee.Engineer;

public class EngineerFactory implements Factory<Engineer> {

    @Override
    public void addEmployee(Manager manager, Engineer employee) {
        manager.add(employee);
    }

    @Override
    public void removeEmployee(Manager manager, Engineer employee) {
        manager.remove(employee);
    }
}
