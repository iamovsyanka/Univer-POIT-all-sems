package Client;

import java.io.*;
import java.net.Socket;

public class ThreadClient extends Thread {
    private static Socket socket;
    private static int port;
    private static String address;
    private InputStream inputStream;
    private String line;
    private OutputStream outputStream;
    private DataInputStream dataInputStream;
    private DataOutputStream dataOutputStream;
    private InputStreamReader inputStreamReader;
    private BufferedReader reader;

    public ThreadClient(String address, int port) throws IOException {
       this.address = address;
       this.port = port;

        System.out.println("Добро пожаловать\n");
        try {
            socket = new Socket(address, port);
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println("соединение установлено.");

        inputStream = socket.getInputStream();
        outputStream = socket.getOutputStream();

        dataInputStream = new DataInputStream(inputStream);
        dataOutputStream = new DataOutputStream(outputStream);

        inputStreamReader = new InputStreamReader(System.in);
        reader = new BufferedReader(inputStreamReader);
    }

    @Override
    public void run() {
        while (true) {
            try {
                line = reader.readLine();
                dataOutputStream.writeUTF(line);
                dataOutputStream.flush();
                line = dataInputStream.readUTF();
                System.out.println("Сервер отправил сообщение:\n\t" + line);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
