package com.devcolibri.logic;

import java.util.ArrayList;
import java.util.List;

public class Librarian implements ILibrarian {
    private final List<Book> library;

    public Librarian() {
        library = new ArrayList<>();
    }

    public void addBook(Book book) {
        library.add(book);
    }

    public void removeBook(Book book) {
        library.remove(book);
    }

    public List<Book> getAllBooks() {
        return library;
    }
}
