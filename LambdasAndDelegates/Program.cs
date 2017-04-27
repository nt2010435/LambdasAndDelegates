using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4},
            };

            //'Where' filter delegate, 'OrderBy' delegate, 'predicate' is filtering type of action
            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach(var cust in phxCusts)
            {
                Console.WriteLine(cust.City + " " + cust.FirstName);
            }

            var worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
        }

        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is complete!");
        }
    }
}
