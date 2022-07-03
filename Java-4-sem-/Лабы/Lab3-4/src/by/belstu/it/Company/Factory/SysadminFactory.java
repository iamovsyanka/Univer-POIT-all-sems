package by.belstu.it.Company.Factory;

import by.belstu.it.Company.Empolyee.Sysadmin;

public class SysadminFactory implements Factory<Sysadmin> {
    @Override
    public void addEmployee(Manager manager, Sysadmin employee) {
        manager.add(employee);
    }

    @Override
    public void removeEmployee(Manager manager, Sysadmin employee) {
        manager.remove(employee);
    }
}
