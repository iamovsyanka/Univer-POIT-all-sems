package by.belstu.it.SecondTask;

import java.util.Random;
import java.util.concurrent.Semaphore;

public class Main {
    private static final int AMOUNT_OF_OPERATORS = 3;
    private static final int AMOUNT_OF_CLIENTS = 10;

    public static void main(String[] args) {
        var rand = new Random();
        var semaphore = new Semaphore(AMOUNT_OF_OPERATORS, true);
        var mcDonalds = new McDonalds(AMOUNT_OF_OPERATORS);
        try {
            for (var i = 0; i < AMOUNT_OF_CLIENTS; i++) {
                new Client(mcDonalds, semaphore, i).start();
                Thread.sleep(rand.nextInt(300) + 300);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}