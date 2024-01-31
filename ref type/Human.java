public class Human {
    public String name;
    public int age;

    public Human() {
    }

    public Human(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String toString(){
        return name + ", " + age;
    }
}
