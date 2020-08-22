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


            var Document = new Document
            {
                DateOfIssue = DateTime.Now,
                Series = "AB",
                Number = "4455",
                IssuingAuthority = new VMs.IssuingAuthority { Value = "hhh" },
                DocumentType = new DocumentType { Value = "rrr" }
            };



            var Visitor = new Visitor
            {
                Document = Document,
                LastName = "Василий",
                Name = "Пупкин",
                PlaceOfWork = "ooo monreal",
                Position = "директор",
                Patronymic = "Васильевич"

            };

            var Employee = new Employee
            {
                Department = new Department { Value = "Отдел продаж" },
                Name = "Георгий",
                LastName = "Тестовой",
                Patronymic = "Васильевич",
                Position = "Инженер"
            };

            var Employee2 = new Employee
            {
                Department = new Department { Value = "Отдел сбыта" },
                Name = "дима",
                LastName = "П",
                Patronymic = "Васильевич",
                Position = "Исм"
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

            context.SinglePasses.Add(new SinglePass
            {
                PurposeOfIssuance = "Пр",
                DateOfIssue = DateTime.Now,
                ValidUntil = DateTime.Now,
                Visitor = Visitor,
                Accompanying = Employee2,
                SinglePassIssued = Employee2
            });

            for (int i = 0; i < 100; i++)
            {
                context.DocumentTypes.Add(new DocumentType { Value = i.ToString() }); ;
            }

            context.TemporaryPasses.Add(new VMs.TemporaryPass
            {
                PurposeOfIssuance = "Посабирать грибы",
                ValidWith = DateTime.Now,
                ValitUntil = DateTime.Now,
                TemporaryPassIssued = Employee2,
                Visitor = Visitor

            }) ;

            context.TemporaryPasses.Add(new VMs.TemporaryPass
            {
                PurposeOfIssuance = "Выгул собак",
                ValidWith = DateTime.Now,
                ValitUntil = DateTime.Now,
                TemporaryPassIssued = Employee,
                Visitor = Visitor
            });


            context.DocumentTypes.Add(new DocumentType { Value = "Паспорт" });
            context.SaveChanges();

        }


    }
}
