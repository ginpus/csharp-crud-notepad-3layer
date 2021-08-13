using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DBconn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var connectionString = "Server=localhost:3306;Uid=test;" + "Pwd=test;Database=noteapp";
            //same as above
            var connectionStringBuilder = new MySqlConnectionStringBuilder();

            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.UserID = "test";
            connectionStringBuilder.Password = "test";
            connectionStringBuilder.Database = "noteapp";

            var connectionString = connectionStringBuilder.GetConnectionString(true);

            Console.WriteLine(connectionString);

            using var connection = new MySqlConnection(connectionString); // object represents connectivity

            connection.Open();

            var query = "select * from customers";
            using var command = new MySqlCommand(query, connection);

            var reader = command.ExecuteReader();

            var customers = new List<Customer>();

            while (reader.Read()) // marker, returns tru or false (for all entries in table)
            {
                customers.Add(new Customer
                {
                    CustomerId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Street = reader.GetString(4),
                    City = reader.GetString(5),
                    State = reader.GetString(6),
                    Age = reader.GetInt32(7)
                }
                );
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
                Console.WriteLine();
            }

            connection.Close();
        }
    }
}