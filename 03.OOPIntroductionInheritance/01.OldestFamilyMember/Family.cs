using System.Collections.Generic;
using System.Linq;

public class Family
{
    private readonly List<Person> persons;

    public Family()
    {
        this.persons = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.persons.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.persons.OrderByDescending(x => x.Age).FirstOrDefault();
    }

}

