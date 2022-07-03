package by.belstu.it.FirstTask;

public class Main {
    public static void main(String[] args) {
        var producer = new Producer(2);
        var clientOne = new Client(producer);
        var clientTwo = new Client(producer);
        var clientThree = new Client(producer);
        clientOne.start();
        clientTwo.start();
        clientThree.start();
    }
}
