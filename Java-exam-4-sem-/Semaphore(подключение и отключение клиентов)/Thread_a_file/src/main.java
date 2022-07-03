import java.util.concurrent.Semaphore;

public class main  {
    public static void main(String[] args) throws InterruptedException {
        Semaphore semaphore1=new Semaphore(5);
        Thread2 t1= new Thread2("1",semaphore1);
        Thread2 t2= new Thread2("2",semaphore1);
        Thread2 t3= new Thread2("3",semaphore1);
        Thread2 t4= new Thread2("4",semaphore1);
        Thread2 t5= new Thread2("5",semaphore1);
        Thread2 t6= new Thread2("6",semaphore1);
        Thread2 t7= new Thread2("7",semaphore1);
        Thread2 t8= new Thread2("8",semaphore1);
        Thread2 t9= new Thread2("9",semaphore1);
        Thread2 t10= new Thread2("10",semaphore1);
        t1.start();
        t2.start();
        t3.start();
        t4.start();
        t5.start();
        t6.start();
        t7.start();
        t8.start();
        t9.start();
        t10.start();

    }

}
