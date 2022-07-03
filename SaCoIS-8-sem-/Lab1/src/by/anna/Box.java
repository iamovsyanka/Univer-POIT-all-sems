/*
 * Box
 * 1.10
 * Copyright notice
 */
package by.anna;

import java.time.LocalDate;

/**
 * Class description goes here.
 *
 * @author Anna Kostyukova
 * @version 1.10 01 Feb 2022
 */
public class Box {
    private int width, height;

    public Box(int width, int height) {
        this.width = width;
        this.height = height;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    @Override
    public String toString() {
        return "Box{" +
                "width=" + width +
                ", height=" + height +
                ", date=" + LocalDate.now() +
                '}';
    }
}
