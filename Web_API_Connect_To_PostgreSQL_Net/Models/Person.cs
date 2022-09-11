using System;
namespace Web_API_Connect_To_PostgreSQL_Net.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
    }
}

