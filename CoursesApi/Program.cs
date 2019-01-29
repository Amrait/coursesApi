using CoursesApi.Models;
using CoursesApi.Repositories;
using CoursesApi.Repositories.Updates;
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
            customer1.LastName = "Kononenko";
            customer1.AddressList.Add(address1);

            var customer2 = new Customer(Guid.NewGuid(), "Oleksii");
            customer2.LastName = "Kozak";
            customer2.AddressList.Add(address1);

            var customer3 = new Customer(Guid.NewGuid(), "Bruce");
            customer3.LastName = "Wayne";
            customer3.AddressList.Add(address1);

            var customer4 = new Customer(Guid.NewGuid(), "Ludwig");
            customer4.LastName = "Fresenburg";
            customer4.AddressList.Add(address1);

            var order1 = new Order(Guid.NewGuid(), "Andrii' order", customer1, DateTime.UtcNow.AddDays(-1), customer1.AddressList[0]);
            var order2 = new Order(Guid.NewGuid(), "Oleksii' order", customer2, DateTime.UtcNow.AddDays(-5), customer2.AddressList[0]);
            var order3 = new Order(Guid.NewGuid(), "Bruce' order", customer3, DateTime.UtcNow.AddDays(-6), customer3.AddressList[0]);
            var order4 = new Order(Guid.NewGuid(), "Ludwig' order", customer4, DateTime.UtcNow.AddDays(-8), customer4.AddressList[0]);


            JsonRepository customerRepository = new JsonRepository();
            customerRepository.Add(customer1);
            string res = customerRepository.Serialize(customer1);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
