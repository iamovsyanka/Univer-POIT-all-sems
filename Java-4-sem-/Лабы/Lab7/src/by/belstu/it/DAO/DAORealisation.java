package by.belstu.it.DAO;

import by.belstu.it.Models.Order;
import by.belstu.it.Models.Product;

import java.sql.*;
import java.util.*;

public class DAORealisation {
    private final Connection connection;

    public DAORealisation(Connection connection) {
        this.connection = connection;
    }

    public List<Order> getAllOrders() throws SQLException {
        var sql = "SELECT  * From Orders";
        var statement = connection.prepareStatement(sql);
        var resultSet = statement.executeQuery();
        List<Order> orders = new ArrayList<>();
        while (resultSet.next()) {
            var order = new Order();
            order.setId(resultSet.getInt("Id"));
            order.setDateOfReceipt(resultSet.getDate("DateOfReceipt"));
            orders.add(order);
        }

        return orders;
    }

    public int getOrderByProduct() throws SQLException {
        var sql = "select * from Orders inner join ProductsInOrders\n" +
                "on Orders.Id = ProductsInOrders.OrderId\n" +
                "where ProductsInOrders.OrderId = 1";
        var statement = connection.prepareStatement(sql);
        var resultSet = statement.executeQuery();
        var order = new Order();
        while (resultSet.next()) {
            order.setId(resultSet.getInt("Id"));
        }

        return order.getId();
    }

    public List<Integer> getOrdersByCount() throws SQLException {
        var sql = "select Orders.Id\n" +
                "from Orders inner join ProductsInOrders\n" +
                "on Orders.Id = ProductsInOrders.OrderId\n" +
                "where ProductsInOrders.Count < 25";
        var statement = connection.prepareStatement(sql);
        var resultSet = statement.executeQuery();
        List<Integer> orders = new ArrayList<>();
        while (resultSet.next()) {
            orders.add(resultSet.getInt("Id"));
        }

        return orders;
    }

    public void addProduct() throws SQLException {
        var sql = "insert into Product(Id, Name, Description, Price)\n" +
                "values(7, 'Tea', 'Eat', 15);";
        var statement = connection.prepareStatement(sql);
        statement.executeUpdate();
        statement.close();
    }

    public List<Product> getAllProducts() throws SQLException {
        var sql = "SELECT  * From Product";
        var statement = connection.prepareStatement(sql);
        var resultSet = statement.executeQuery();
        List<Product> products = new ArrayList<>();
        while (resultSet.next()) {
            var product = new Product();
            product.setId(resultSet.getInt(1));
            product.setDescription(resultSet.getString(3));
            product.setName(resultSet.getString(2));
            product.setPrice(resultSet.getInt(4));
            products.add(product);
        }

        return products;
    }

    public void deleteProduct() throws SQLException {
        var sql = "delete from Product where id = 7";
        var statement = connection.prepareStatement(sql);
        statement.executeUpdate();
        statement.close();
    }
}
