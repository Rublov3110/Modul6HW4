namespace WebAppMVC.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(int id, string model, int year, int price)
        {
            Id = id;
            Model = model;
            Year = year;
            Price = price;
        }

        public int Id { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public int Price { get; init; }
    }
}
