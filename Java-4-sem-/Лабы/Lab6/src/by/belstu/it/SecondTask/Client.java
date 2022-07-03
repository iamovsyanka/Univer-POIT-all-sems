package by.belstu.it.SecondTask;

import java.util.Random;
import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

public class Client extends Thread {
    private final String name;
    private final McDonalds mcDonalds;
    private final Semaphore semaphore;

    public Client(McDonalds pMcDonalds, Semaphore pSemaphore, int pName) {
        this.name = String.valueOf(pName);
        this.semaphore = pSemaphore;
        this.mcDonalds = pMcDonalds;
    }

    public String getClientName() {
        return this.name;
    }

    @Override
    public void run() {
        var rand = new Random();
        System.out.println("Client " + this.getName() + " entered!");
        var key = false;
        var waitingTime = rand.nextInt(300) + 100;
        while (!key) {
            try {
                if (semaphore.tryAcquire(waitingTime, TimeUnit.MICROSECONDS)) {
                    System.out.println("Client " + this.getClientName() + " have a dialog");
                    mcDonalds.connect(this);
                    mcDonalds.showLines();
                    Thread.sleep(rand.nextInt(1000) + 500);
                    mcDonalds.disconnect(this);
                    semaphore.release();
                    System.out.println("Client " + this.getClientName() + " receive the order");
                    key = true;
                } else {
                    System.out.println("Client " + this.getClientName() + " wait");
                    Thread.sleep(5000);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}
