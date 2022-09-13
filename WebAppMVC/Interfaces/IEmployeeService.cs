
namespace WebAppMVC.Interfaces
{
    using WebAppMVC.Models;
    public interface IEmployeeService
    {

        public IEnumerable<Employee> Get();

        public Employee GetById(int id);

        public int Post(Employee employee);

        public int Put(Employee employee);

        public bool Delete(int id);
    }
}
