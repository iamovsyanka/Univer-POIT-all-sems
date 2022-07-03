package by.belstu.it;

import by.belstu.it.DAO.DAORealisation;
import by.belstu.it.DAO.MyDAO;
import by.belstu.it.Models.Order;
import by.belstu.it.Models.Product;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        var dao = new MyDAO();

        try {
            var connection = dao.getConnection();
            var daoRealisation = new DAORealisation(connection);

            var listOrders = daoRealisation.getAllOrders();
            System.out.println("All orders:");
            listOrders.forEach(System.out::println);

            System.out.println("\nId of order with productId = 1:");
            System.out.println(daoRealisation.getOrderByProduct());

            System.out.println("\nId of order with count < 25:");
            System.out.println(daoRealisation.getOrdersByCount());

            daoRealisation.deleteProduct();
            var listProducts = daoRealisation.getAllProducts();
            System.out.println("\nAll products:");
            listProducts.forEach(System.out::println);

            connection.setAutoCommit(false);

            daoRealisation.addProduct();
            listProducts = daoRealisation.getAllProducts();
            System.out.println("\nAll products:");
            listProducts.forEach(System.out::println);

            connection.rollback();
            listProducts = daoRealisation.getAllProducts();
            System.out.println("\nAll products:");
            listProducts.forEach(System.out::println);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
