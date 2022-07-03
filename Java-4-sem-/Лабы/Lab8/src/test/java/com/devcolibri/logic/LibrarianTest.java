package com.devcolibri.logic;

import org.testng.Assert;
import org.testng.annotations.*;

import java.util.List;

public class LibrarianTest extends Assert {
    Book firstBook = new Book("Kolobok", "Ded", 1641);
    Book secondBook = new Book("Ded Moroz", "Ded", 1271);

    @BeforeMethod
    public void setUp() {
        System.out.println("@BeforeMethod – аннотированный метод будет выполняться перед каждым тестовым методом.");
    }

    @AfterMethod
    public void tearDown() {
        System.out.println("@AfterMethod – аннотированный метод будет запускаться после каждого тестового метода.");
    }

    @BeforeGroups
    public void beforeGroups() {
        System.out.println("BeforeGroups – аннотирует методы, которые будут выполняться перед первым методом в любой из указанных групп.");
    }

    @AfterGroups
    public void afterGroups() {
        System.out.println("@AfterGroups – аннотируется методы, которые будут выполняться после всех методом в любом из указанных групп.");
    }

    @BeforeClass
    public void beforeClass() {
        System.out.println("@BeforeClass – указывает, что метод будет выполнен до всех тестовых методов тестового класса.");
    }

    @BeforeTest
    public void beforeTest() {
        System.out.println("@BeforeTest - аннотированный метод будет запускаться до всех тестовых методов.");
    }

    @AfterTest
    public void afterTest() {
        System.out.println("@AfterTest – аннотированный метод будет запущен после всех тестовых методов, принадлежащих классам внутри тега <test>.");
    }

    @AfterClass
    public void afterClass() {
        System.out.println("@AfterClass  – аннотированный метод будет запущен после всех тестовых методов в текущем классе.");
    }

    @BeforeSuite
    public void beforeSuite() {
        System.out.println("@BeforeSuite – указывает, что данный метод будет запускаться перед любым методом тестового класса.");
    }

    @AfterSuite
    public void afterSuite() {
        System.out.println("@AfterSuite – указывает, что данный метод, будет запускаться после всех методов тестового класса.");
    }

    @Test(groups = {"unit"})
    public void testAddBooks() {
        List<Book> books = Book.getAllBooks();
        books.forEach(System.out::println);

        Assert.assertNotNull(books);
    }

    @Test(timeOut = 1000)
    public void testCompareBooks() {
        List<Book> books = Book.getAllBooks();

        Librarian librarian = new Librarian();
        librarian.addBook(firstBook);
        librarian.addBook(secondBook);

        Assert.assertEquals(books, librarian.getAllBooks());
    }

    @Test(groups = {"unit"})
    public void testRemoveBook() throws NullPointerException {
        Librarian librarian = new Librarian();
        librarian.addBook(firstBook);
        librarian.removeBook(firstBook);
        Assert.assertNotNull(librarian.getAllBooks());
    }

    @Test(enabled = false)
    public void testAddBooksIgnor() {
        List<Book> books = Book.getAllBooks();
        books.forEach(System.out::println);

        Assert.assertNotNull(books);
    }
}
