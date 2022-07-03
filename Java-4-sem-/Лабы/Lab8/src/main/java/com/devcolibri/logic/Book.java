package com.devcolibri.logic;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Book {
    private static Map<Integer, Book> allBooks;
    private static int countId = 0;
    private String title;
    private String author;
    private int age;
    private int id;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public Book(String title, String author, int age) {
        if (allBooks == null) {
            allBooks = new HashMap<>();
        }
        this.title = title;
        this.author = author;
        this.age = age;

        if (!hasBook()) {
            countId++;
            this.id = countId;
            allBooks.put(id, this);
        }
    }

    public static List<Book> getAllBooks() {
        return new ArrayList<Book>(allBooks.values());
    }

    private boolean hasBook() {
        return allBooks.containsValue(this);
    }

    @Override
    public String toString() {
        return "Book{" +
                "title='" + title + '\'' +
                ", author='" + author + '\'' +
                ", age=" + age +
                ", id=" + id +
                '}';
    }
}
