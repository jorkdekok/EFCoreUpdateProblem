using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            string connectionString = @"Data Source=GRAYSON-X1YOGA\sqlexpress;Initial Catalog=MyDatabase;Integrated Security=True";
            optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60));

            return new TestContext(optionsBuilder.Options);
        }
    }
}
