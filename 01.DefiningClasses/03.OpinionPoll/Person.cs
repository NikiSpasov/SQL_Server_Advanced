public class Person
{
    private string name;
    private int age;

    public Person() : this("No name", 1)
    {
    }

    public Person(int age)
    {
        this.Age = age;
        this.Name = "No name";
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }
}

