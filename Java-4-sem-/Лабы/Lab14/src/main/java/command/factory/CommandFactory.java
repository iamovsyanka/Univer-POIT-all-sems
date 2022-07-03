package command.factory;

import command.Command;
import command.LoginPageCommand;
import command.RegisterPageCommand;
import command.authorithation.LoginCommand;
import command.authorithation.RegisterNewUserCommand;
import command.authorithation.SingOutCommand;
import command.grouppresons.AddNewContactCommand;
import command.grouppresons.DeleteContactCommand;
import command.grouppresons.WelcomeCommand;

public class CommandFactory {
    public static Command create(String command) {
        command = command.toUpperCase();
        System.out.println(command);
        CommandType commandEnum = CommandType.valueOf(command);
        Command resultCommand;
        switch (commandEnum) {
            case LOGIN: {
                resultCommand = new LoginCommand();
                break;
            }
            case REGISTER_NEW_USER: {
                resultCommand = new RegisterNewUserCommand();
                break;
            }
            case SIGN_OUT: {
                resultCommand = new SingOutCommand();
                break;
            }
            case LOGIN_PAGE: {
                resultCommand = new LoginPageCommand();
                break;
            }
            case WELCOME: {
                resultCommand = new WelcomeCommand();
                break;
            }
            case REGISTRATION_PAGE: {
                resultCommand = new RegisterPageCommand();
                break;
            }
            case ADD_NEW_CONTACT: {
                resultCommand = new AddNewContactCommand();
                break;
            }
            case DELETE_CONTACT: {
                resultCommand = new DeleteContactCommand();
                break;
            }
            default: {
                throw new IllegalArgumentException("Invalid command" + commandEnum);
            }
        }
        return resultCommand;
    }
}