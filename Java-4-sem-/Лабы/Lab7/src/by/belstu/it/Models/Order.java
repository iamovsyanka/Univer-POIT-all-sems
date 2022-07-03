package by.belstu.it.Models;

import java.util.Date;

public class Order {
    private int id;
    private Date DateOfReceipt;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Date getDateOfReceipt() {
        return DateOfReceipt;
    }

    public void setDateOfReceipt(Date dateOfReceipt) {
        DateOfReceipt = dateOfReceipt;
    }

    @Override
    public String toString() {
        return "Order{" +
                "id=" + id +
                ", DateOfReceipt=" + DateOfReceipt +
                '}';
    }
}
