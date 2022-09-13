
namespace WebAppMVC.Services
{
    using System.Collections.Generic;
    using WebAppMVC.Interfaces;
    using WebAppMVC.Models;

    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>();
            _employees.Add(new Employee(0, "BMW", 2018, 15000));
            _employees.Add(new Employee(1, "Mazda", 2019,10000));
            _employees.Add(new Employee(2, "Ford", 2020, 11000));
        }

        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            if (id >= 0)
            {
                return _employees.FirstOrDefault(e => e.Id == id);
            }
            else
            {
                throw new ArgumentException("Error.");
            }
        }

        public int Post(Employee employee)
        {
            if (!_employees.Contains(employee))
            {
                _employees.Add(employee);
                return _employees.FirstOrDefault(e => e.Id == employee.Id).Id;
            }
            else
            {
                throw new ArgumentException("Error.");
            }

        }

        public int Put(Employee employee)
        {
            var element = GetById(employee.Id);
            int index = -1;
            if (element == null)
            {
                _employees.Add(employee);
            }
            else
            {
                index = _employees.IndexOf(element);
                _employees[index] = employee;
            }

            return index;
        }

        public bool Delete(int id)
        {
            return _employees.Remove(GetById(id));
        }
    }
}
