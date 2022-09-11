using System;
using Microsoft.EntityFrameworkCore;
using Web_API_Connect_To_PostgreSQL_Net.Models;

namespace Web_API_Connect_To_PostgreSQL_Net.Datas
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}
        public DbSet<Person> people { get; set; }
    }
}

