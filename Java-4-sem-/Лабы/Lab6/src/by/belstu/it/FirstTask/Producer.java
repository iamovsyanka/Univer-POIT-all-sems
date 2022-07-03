package by.belstu.it.FirstTask;

public class Producer extends Thread {
    private int currentCountSki;

    public Producer(int countSki) {
        currentCountSki = countSki;
    }

    public synchronized int giveSki() {
        if (currentCountSki > 0) {
            currentCountSki--;
            System.out.println("Skis were issued, in stock " + currentCountSki + " pairs of skis");
            return 0;
        } else {
            System.out.println("Skis run out, can't be issued");
            return -1;
        }
    }

    public synchronized void getSki() {
        currentCountSki++;
        System.out.println("The skis were returned to the stock " + currentCountSki + " pairs of skis");
    }
}
