package by.belstu.it.SecondTask;

public class McDonalds {
    private final int amountOfOperators;
    private final Client[] operators;

    public McDonalds(int size) {
        this.amountOfOperators = size;
        this.operators = new Client[size];
    }

    public void showLines() {
        System.out.println("Lines:{");
        for (var i = 0; i < amountOfOperators; i++) {
            if (operators[i] != null) {
                System.out.println(i + ") " + operators[i].getClientName());
            } else {
                System.out.println(i + ") empty");
            }
        }
        System.out.println("}");
    }

    public void connect(Client client) {
        operators[this.FreeOperator()] = client;
    }

    public void disconnect(Client client) {
        for (int i = 0; i < this.amountOfOperators; i++) {
            if (operators[i] == client) {
                operators[i] = null;
            }
        }
    }

    public int FreeOperator() {
        for (int i = 0; i < this.amountOfOperators; i++) {
            if (operators[i] == null) {
                return i;
            }
        }
        return -1;
    }
}
