package Server;

import java.io.*;
import java.net.*;

public class Server extends Thread
{
    private static final int port = 6666;
    private String TEMPL_MSG = "Клиент номер '%d' отправил сообщение: \n\t";
    private String TEMPL_CONN = "Клиент номер '%d' подключился к беседе";

    private Socket socket;
    private int num;

    public Server() {}
    public void setSocket(int num, Socket socket)
    {
        this.num = num;
        this.socket = socket;

        setDaemon(true);
        setPriority(NORM_PRIORITY);
        start();
    }

    public void run()
    {
        try {
            InputStream  sin  = socket.getInputStream();
            OutputStream sout = socket.getOutputStream();

            DataInputStream  dis = new DataInputStream (sin );
            DataOutputStream dos = new DataOutputStream(sout);

            String line = null;
            while(true) {
                line = dis.readUTF();
                System.out.println(String.format(TEMPL_MSG, num) + line);
                dos.writeUTF("Сервер отправил сообщение: " + line +"          "+ num);
                dos.flush();
                System.out.println();
                if (line.equalsIgnoreCase("quit")) {
                    socket.close();
                    System.out.println(
                            String.format(TEMPL_CONN, num));
                    break;
                }
            }
        } catch(Exception e) {
            System.out.println("Exception: " + e);
        }
    }

    public static void main(String[] ar)
    {
        ServerSocket srvSocket = null;
        try {
            try {
                int i = 0;
                InetAddress ia;
                ia = InetAddress.getByName("localhost");
                srvSocket = new ServerSocket(port, 0, ia);

                System.out.println("Сервер запущен!\n");

                while(true) {
                    Socket socket = srvSocket.accept();
                    System.err.println("Клиент подключился");
                    new Server().setSocket(i++, socket);
                }
            } catch(Exception e) {
                System.out.println("Exception: " + e);
            }
        } finally {
            try {
                if (srvSocket != null)
                    srvSocket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        System.exit(0);
    }
}