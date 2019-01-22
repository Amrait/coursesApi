using CoursesApi.Models;
using System;

namespace CoursesApi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating entities, setting fields         
            var address1 = new Address(Guid.NewGuid());
            address1.City = "Poltava";
            address1.Country  = "Ukraine";
            var customer1 = new Customer(Guid.NewGuid(), "Andrii");
            customer1.SetLastName("Kononenko");
            // Displaying info
            address1.DisplayEntityInfo();
            customer1.DisplayEntityInfo();
            Console.ReadLine();
        }
    }
}
