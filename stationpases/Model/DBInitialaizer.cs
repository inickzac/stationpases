using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.Model
{
    class DBInitialaizer : DropCreateDatabaseAlways<StationDBContext>
    {
        protected override void Seed(StationDBContext context)
        {
            var Visitor = new Visitor
            {
                Document = new Document
                {
                    DateOfIssue = DateTime.Now,
                    Series = "AB",
                    Number = "4455",
                    IssuingAuthority = "КГБ",
                    DocumentType = new DocumentType { Type = "Паспорт" }
                },
                LastName = "pool",
                Name = "dim",
                PlaceOfWork = "ooo monreal",
                Position = "директор"

            };

            var Employee = new Employee
            {
                Department = new Department { Name = "Отдел продаж" },
                Name = "Ира",
                LastName = "Попа",
                Position = "Инженер"
            };



            context.SinglePasses.Add(new SinglePass
            {
                PurposeOfIssuance = "Просто так",
                DateOfIssue = DateTime.Now,
                ValidUntil = DateTime.Now,
                Visitor = Visitor,
                Accompanying = Employee,
                SinglePassIssued = Employee
            });


            context.SaveChanges();

        }


    }
}
