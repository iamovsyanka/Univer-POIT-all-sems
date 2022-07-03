package command;

import java.util.Objects;

public class CommandResult {
    private String page;
    private boolean isRedirect;

    public CommandResult() {
    }

    public CommandResult(String page) {
        this.page = page;
    }

    public CommandResult(String page, boolean isRedirect) {
        this.page = page;
        this.isRedirect = isRedirect;
    }

    public String getPage() {
        return page;
    }

    public void setPage(String page) {
        this.page = page;
    }

    public boolean isRedirect() {
        return isRedirect;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null || getClass() != obj.getClass()) {
            return false;
        }
        CommandResult commandResult = (CommandResult) obj;
        return isRedirect() == commandResult.isRedirect() &&
                Objects.equals(getPage(), commandResult.getPage());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getPage(), isRedirect());
    }
}
