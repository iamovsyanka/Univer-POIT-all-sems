package Client;

import java.io.*;

public class Client {
    private static final int serverPort = 6666;
    private static final String localhost = "127.0.0.1";

    public static void main(String[] ar) throws IOException {
        new ThreadClient(localhost,serverPort).start();
    }
}

