package by.belstu.it.kostukova.basejava;

import static java.lang.Math.*;

public class JavaTest {
    public static void main(String[] args) {
        //1
        char charExample = '4';
        int intExample = 44444;
        short shortExample = 44;
        byte byteExample = 4;
        long longExample = 4444444;
        boolean bool = true;
        String str = "String";
        System.out.println(str + intExample);
        System.out.println(str + charExample);
        System.out.println(str + 5.4);
        //byteExample = byteExample + intExample; Error:(16, 14) java: incompatible types: possible lossy conversion from int to byte
        //intExample = 5.7 + longExample; Error:(17, 17) java: incompatible types: possible lossy conversion from double to int
        //longExample = intExample + 2147483647; пустая строка
        //static int sint; Error:(19, 9) java: illegal start of expression
        System.out.println(true && false);
        System.out.println(true ^ false);
        /*System.out.println(true Error:(22, 32) java: bad operand types for binary operator '+'
        first type:  boolean
        second type: boolean+false);*/
        long a1 = 9223372036854775807L, a2 = 0x7fff_ffff_fffL;
        char ch1 = 'a', ch2 = '\u0061', ch3 = 97;
        System.out.println("" + ch1 + ch2 + ch3);
        System.out.println(3.45 % 2.4);
        System.out.println(1.0 % 0.0);
        System.out.println(0.0 % 0.0);
        /*System.out.println(log(-345)); Error:(31, 28) java: cannot find symbol
                                            symbol:   method log(int)
                                            location: class by.belstu.it.kostukova.basejava.JavaTest*/
        System.out.println(Float.intBitsToFloat(0x7F800000));
        System.out.println(Float.intBitsToFloat(0xFF800000));

        //2
        //В классе Test

        //3
        System.out.println(PI);
        System.out.println(E);
        System.out.println(Math.round(PI));
        System.out.println(Math.round(E));
        System.out.println(Math.min(PI, E));
        System.out.println(Math.random());

        //4
        Boolean bo = false;
        Character cha = 'a';
        Integer num = 19; //автозапаковка
        Byte byt = 4;
        Short sho = 25;
        Long lon = 5151165L;
        Double dou = 5.1824;
        System.out.println(bo & true);
        System.out.println(byt >>> 1);
        System.out.println(~num);
        System.out.println(lon * sho);
        System.out.println(Long.MAX_VALUE + " " + Long.MIN_VALUE);
        System.out.println(Double.MAX_VALUE + " " + Double.MIN_VALUE);
        int numr = num;
        byte bytr = byt;
        System.out.println(Integer.parseInt("8466565"));
        System.out.println(Integer.toHexString(291));
        System.out.println(Integer.compare(num, 29));
        System.out.println(num.toString());
        System.out.println(Integer.bitCount(num));

        //5
        String s34 = "2345";
        int number1 = Integer.valueOf(s34);
        System.out.println(number1);
        int number2 = Integer.valueOf(s34);
        System.out.println(number2);
        System.out.println(Integer.parseInt(s34));
        byte[] mas = s34.getBytes();
        String str1 = new String(mas);

        String s1 = "True";
        System.out.println(Boolean.parseBoolean(s1));
        System.out.println(Boolean.parseBoolean(s34));
        System.out.println(Boolean.valueOf(s1));
        System.out.println(Boolean.valueOf(s34));

        String st1 = "123", st2 = "123";
        System.out.println(st1 == st2);
        System.out.println(st1.equals(st2));
        System.out.println(st1.compareTo(st2));
        st2 = null;
        System.out.println(st1 == st2);
        System.out.println(st1.equals(st2));
        //System.out.println(st1.compareTo(st2)); java.lang.NullPointerException

        String[] strmas = st1.split("2");
        System.out.println(strmas[0] + " " + strmas[1]);
        System.out.println(st1.contains("4"));
        System.out.println(st1.hashCode());
        System.out.println(st1.indexOf('3'));
        System.out.println(st1.length());
        System.out.println(st1.replace('3', '1'));

        //6
        char[][] c1;
        char[] c2[];
        char c3[][];
        c1 = new char[3][];
        System.out.println(c1.length);
        for (int i = 0; i < c1.length; i++) {
            c1[i] = new char[i + 1];
            System.out.println(c1[i].length);
        }
        c2 = new char[][]{{'1', '2', '3'}, {'2', '3', '4'}, {'3', '4', '5'}};
        c3 = new char[][]{{'1', '2', '3'}, {'2', '3', '4'}, {'3', '4', '5'}};
        boolean comres = c2 == c3;
        c2 = c3;
        for (char[] ind1 : c2) {
            for (char ind2 : ind1) {
                System.out.println(ind2);
            }
        }
        //System.out.println(c2[2][4]); java.lang.ArrayIndexOutOfBoundsException

        //7
        var wrapperString = new WrapperString("Hello java");
        wrapperString.replace('j', 'J');
        System.out.println(wrapperString.getStr());
        WrapperString wstr1 = new WrapperString("123") {

            public WrapperString delete(char newChar) {
                this.setStr(this.getStr().replace(newChar, '\0'));
                return this;
            }

            @Override
            public void replace(char oldChar, char newChar) {
                this.setStr(this.getStr().replace(oldChar, newChar));
            }
        }.delete('1');
        wstr1.replace('3', '1');
        System.out.println(wstr1.getStr());
    }
}
