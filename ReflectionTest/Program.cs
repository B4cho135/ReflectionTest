
using ReflectionTest.Extenstions;

Name n = new Name();
n.FirstName = "John";
n.LastName = "Doe";
Person p = new Person();
p.Age = 55;
p.BankBalance = 102.2;
p.Identification = new Identification()
{
    IdentificationNumber = "11111111111",
    Name = n
};
p.Vehicle = new Vehicle() { Brand = "BMW", Model = "X5" };

p.PrintObjectStructure();
Console.ReadKey();

public class Name
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Person
{
    public int Age { get; set; }
    public double BankBalance { get; set; }
    public Identification Identification { get; set; }
    public Vehicle Vehicle { get; set; }
}

public class Vehicle
{
    public string Model { get; set; }
    public string Brand { get; set; }
}

public class Identification
{
    public string IdentificationNumber { get; set; }
    public Name Name { get; set; }
}