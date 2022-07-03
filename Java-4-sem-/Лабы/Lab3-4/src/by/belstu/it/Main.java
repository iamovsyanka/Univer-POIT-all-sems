package by.belstu.it;

import by.belstu.it.Company.Empolyee.*;
import by.belstu.it.Company.Factory.EngineerFactory;
import by.belstu.it.Company.Factory.Manager;
import by.belstu.it.Company.Factory.ProgrammerFactory;
import by.belstu.it.Company.Factory.SysadminFactory;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

public class Main {
    public static void main(String[] args) {
        try {
            var director = Director.getDirector();
            var manager = new Manager();
            var engineerFactory = new EngineerFactory();
            var programmerFactory = new ProgrammerFactory();
            var sysadminFactory = new SysadminFactory();
            var chiefEngineer = new Engineer("Lapenko", 28, 10, Qualification.senior);

            System.out.println(director);

            engineerFactory.addEmployee(manager, new Engineer("Igor", 24, 5, Qualification.junior));
            engineerFactory.addEmployee(manager, chiefEngineer);
            programmerFactory.addEmployee(manager, new Programmer("Andrey", 19, 2, Qualification.senior));
            sysadminFactory.addEmployee(manager, new Sysadmin("Kate", 25, 3, Qualification.junior));

            System.out.println(director.getCountEmployees(manager));
            engineerFactory.removeEmployee(manager, chiefEngineer);
            System.out.println(director.getCountEmployees(manager));

            director.findEmployee(manager, Qualification.junior);

            director.salarySort(manager);
            System.out.println("Sort: ");
            manager.getEmployees().forEach(System.out::println);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
