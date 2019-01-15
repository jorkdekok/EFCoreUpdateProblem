using EFCoreTest1.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EFCoreTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            string connectionString = @"Data Source=GRAYSON-X1YOGA\sqlexpress;Initial Catalog=MyDatabase;Integrated Security=True";
            optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60));


            using (var context = new TestContext(optionsBuilder.Options))
            {
                //InitTaak(context);

                Taak taakOrg = context.Taken.Where(x => x.Id == 1).Include(x => x.Statussen).FirstOrDefault();

                PrintCht(context);

                taakOrg.Statussen.Clear();
                taakOrg.Statussen.Add(new StatusHistorie() { Status = 2 });

                var entryOrg = context.Entry(taakOrg);

                Taak taakEntity = context.Taken.Where(x => x.Id == 1).Include(x => x.Statussen).FirstOrDefault();
                taakEntity.Naam = taakOrg.Naam;
                taakEntity.Statussen = taakOrg.Statussen;

                PrintCht(context);
                //var entryEntity = context.Entry(taakEntity);

                //var entryOrg2 = context.Entry(taakOrg);

                var count = context.SaveChanges();
            }
        }

        private static void PrintCht(TestContext context)
        {
            foreach (var e in context.ChangeTracker.Entries())
            {
                Debug.WriteLine($"{e.Entity.ToString()} - id: {e.Member("Id").CurrentValue}");
            }
        }

        private static void InitTaak(TestContext context)
        {
            // do stuff
            var taak = new Taak()
            {
                Naam = "Taak 1",
                Statussen = new List<StatusHistorie>
                    {
                        new StatusHistorie()
                        {
                            Status = 1
                        }
                    }
            };

            context.Add(taak);
            context.SaveChanges();
        }
    }
}
