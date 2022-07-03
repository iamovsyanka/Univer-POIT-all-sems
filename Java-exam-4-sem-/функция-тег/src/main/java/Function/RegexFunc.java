package Function;

import java.util.regex.Pattern;

public class RegexFunc {
    public  static String checkPassport(String text) {
        boolean found = Pattern.matches("[A-z]{2}[0-9]{4,6}/20", text);
        if(found) {
            return "correct";
        }
        else {
            return "no correct";
        }
    }

}
