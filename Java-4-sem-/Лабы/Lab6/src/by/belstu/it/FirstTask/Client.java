package by.belstu.it.FirstTask;

public class Client extends Thread {
    private final Producer producer;
    private boolean hasSki = false;

    public Client(Producer producer) {
        this.producer = producer;
    }

    @Override
    public void run() {
        try {
            while (true) {
                if (!hasSki) {
                    int errorCode = producer.giveSki();
                    if (errorCode == 0) {
                        hasSki = true;
                    }
                } else {
                    producer.getSki();
                    hasSki = false;
                }
                sleep(1000);
            }
        } catch (InterruptedException e) {
            System.out.println("Поток пользователя лыж прерван");
        }
    }
}
