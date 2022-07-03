import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

public class Thread2 extends Thread {

    public Thread2(String string, Semaphore semaphore) {
        this.string = string;
        this.semaphore = semaphore;
}

    String string;
    Semaphore  semaphore;
    @Override
    public void run() {
        try {
            semaphore.acquire();

            if(!semaphore.tryAcquire(3000, TimeUnit.MILLISECONDS)) {
                System.out.println("Client " + string + " time out");
                this.interrupt();
            }
            else{

            System.out.println("Client "+string+" get connection");
            }
            semaphore.release();
            System.out.println("Client "+string+" relesed connection");
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
