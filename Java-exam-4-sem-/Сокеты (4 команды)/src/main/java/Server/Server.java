package Server;

import Command.Command;

import java.io.*;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;

public class Server extends Thread
{
    private static final int port = 6666;
    private String TEMPL_MSG = "Клиент номер '%d' отправил сообщение: \n\t";
    private String TEMPL_CONN = "Клиент номер '%d' подключился к беседе";

    private Socket socket;
    private Command command;
    private int num;
    private int countNol;
    private int countEd;

    public Server() {}
    public void setSocket(int num, Socket socket)
    {
        this.num = num;
        this.socket = socket;
        command = new Command();

        setDaemon(true);
        setPriority(NORM_PRIORITY);
        start();
    }

    public void run()
    {
        try {
            DataInputStream  dis = new DataInputStream (socket.getInputStream());
            DataOutputStream dos = new DataOutputStream(socket.getOutputStream());

            String line = null;
            while(true) {
                line = dis.readUTF();
                if (line.equals(command.COMMAND_HELP)) {
                    dos.writeUTF(line + ": "+command.COMMAND_ED + " " + command.COMMAND_NOL + " " + command.COMMAND_GETALL);
                }
                if (line.equals(command.COMMAND_NOL)) {
                    countNol++;
                    dos.writeUTF(line + ": "+"Прибавил");
                }
                if (line.equals(command.COMMAND_ED)) {
                    countEd++;
                    dos.writeUTF(line + ": "+"Прибавил");
                }
                if (line.equals(command.COMMAND_GETALL)) {
                    dos.writeUTF(line + ": "+countEd + " " + countNol);
                }
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