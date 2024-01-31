import java.util.*;
import java.time.Duration;
import java.time.Instant;


public class test {

    public static void main(String[] args){
        Human h1 = new Human("Jane", 5);
        Human h2 = h1;
        Human h3 = new Human();
        h2.name = "Chris";
        h2.age = 50;
        System.out.println(h1);
        System.out.println(h2 + "\n");

        h3.name = "Bob";
        h3.age = 500;

        int age = h1.age;
        age += 50000;
        System.out.println(h1);
        System.out.println(h3);
        System.out.println("age: "+age);
    }

    public static boolean canConststruct(String target, String[] arr){
        if (target.equals("")) return true;

        for (String str : arr) {
            if (target.length() < str.length())
                continue;

            String suffix = target.substring(0, str.length());

            if (suffix.equals(str)) {
                String tempTarget = target.substring(str.length());
                if (canConststruct(tempTarget, arr))
                    return true;
            }
        }
        return false;
    }

    public static boolean canConststructDP(String target, String[] arr, HashMap<String, Boolean> memo){
        if (memo.containsKey(target)) return memo.get(target);
        if (target.equals("")) return true;

        for (String str : arr) {
            if (target.length() < str.length())
                continue;

            String suffix = target.substring(0, str.length());

            if (suffix.equals(str)) {
                String tempTarget = target.substring(str.length());
                if (canConststruct(tempTarget, arr)){
                    memo.put(target, true);
                    return true;
                }
                    
            }
        }

        memo.put(target, false);
        return false;
    }
}