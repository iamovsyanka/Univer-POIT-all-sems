package Client;

import java.io.*;
import java.net.Socket;
import java.time.LocalDateTime;

public class ClientThread {

    private Socket socket;
    private BufferedReader reader;
    private BufferedWriter writer;
    private BufferedReader inputUser;
    private final String address;
    private final int port;
    private String name;

    public ClientThread(String address, int port) {
        this.address = address;
        this.port = port;

        try {
            this.socket = new Socket(address, port);
        } catch (IOException e) {
            System.err.println("Socket failed");
        }

        try {
            inputUser = new BufferedReader(new InputStreamReader(System.in));
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
            this.pressName();
            new ReadMessage().start();
            new WriteMessage().start();
        } catch (IOException e) {
            ClientThread.this.downService();
        }
    }

    private void pressName() {
        System.out.print("Введите имя: ");
        try {
            name = inputUser.readLine();
            writer.write("Приветствуем " + name + "!\n");
            writer.flush();
        } catch (IOException ignored) { }
    }

    private void downService() {
        try {
            if (!socket.isClosed()) {
                socket.close();
                reader.close();
                writer.close();
            }
        } catch (IOException ignored) {}
    }

    private class ReadMessage extends Thread {
        @Override
        public void run() {
            try {
                while (true) {
                    String message = reader.readLine();
                    System.out.println(message);
                }
            } catch (IOException e) {
                ClientThread.this.downService();
            }
        }
    }

    public class WriteMessage extends Thread {
        @Override
        public void run() {
            while (true) {
                try {
                    String message = inputUser.readLine();
                    if (message.equals("end")) {
                        writer.write("end" + "\n");
                        ClientThread.this.downService();
                        break;
                    }
                    if (message.equals("time")) {
                        writer.write("time " + LocalDateTime.now() + "\n");
                    }
                    else {
                        writer.write( name + ": " + message + "\n");
                    }
                    writer.flush();
                } catch (IOException e) {
                    ClientThread.this.downService();
                }
            }
        }
    }
}
