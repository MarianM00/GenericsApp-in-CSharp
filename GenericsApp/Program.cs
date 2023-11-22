using GenericsApp.Data;
using GenericsApp.Entities;
using GenericsApp.Repositories;
using System;

namespace GenericsApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            var itemAdded = new ItemAdded<Employee>(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageApp(), itemAdded);
            AddEmployee(employeeRepository);
            AddManager(employeeRepository);
            GetEmployeeByID(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeAdded(Employee employee)
        {
            Console.WriteLine($"Employee added : {employee.FirstName }");
        }

        private static void AddManager(IWriteRepository<Manager> managerRepository)
        {
            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);
            if (saraManagerCopy is not null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }
            managerRepository.Add(new Manager { FirstName = "Alina" });
            managerRepository.Add(new Manager { FirstName = "Crina" });

            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntityBase> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeByID(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with id 2 is : {employee.FirstName} ");
        }

        private static void AddEmployee(IRepository<Employee> employeeRepository)
        {

            var employees = new[]
            {
                new Employee { FirstName = "Ionel" },
                new Employee { FirstName = "Marian" },
                new Employee { FirstName = "Gigel" }
            };
            employeeRepository.AddBatch(employees);
            //employeeRepository.Remove(new Employee { FirstName = "Marian" });

        }

        private static void AddOrganization(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Drx" },
                new Organization { Name = "Endava" },
                new Organization { Name = "OSF" }
            };

            organizationRepository.AddBatch(organizations);
        }

        
    }
}