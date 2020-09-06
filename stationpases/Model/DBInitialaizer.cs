using stationpases.VMs;
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
                Accompanying = Employee,
                SinglePassIssued = Employee
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
                TemporaryPassIssued = Employee,
                Visitor = Visitor

            });

            context.TemporaryPasses.Add(new VMs.TemporaryPass
            {
                PurposeOfIssuance = "Выгул собак",
                ValidWith = DateTime.Now,
                ValitUntil = DateTime.Now,
                TemporaryPassIssued = Employee2,
                Visitor = Visitor
            });


            context.DocumentTypes.Add(new DocumentType { Value = "Паспорт" });
            context.SaveChanges();
            InitFacilitys(context);
            InitShootingPermission(context, Visitor);

        }

        void InitFacilitys(StationDBContext context)
        {

            for (int i = 0; i < 50; i++)
            {
                context.StationFacilities.Add(new StationFacility { Value = $"Обьект {i}" });
            }

            context.SaveChanges();
        }
        List<Access> InitAccess(StationDBContext context)
        {
            List<Access> accesses = new List<Access>();
            var stationFacilities = new List<StationFacility>();
            var random = new Random();
            var quantityOfSF = random.Next(10);
            var boolList = new List<bool> { true, false };

            for (int i = 0; i < quantityOfSF; i++)
            {
                var SFNumber = random.Next(context.StationFacilities.Count() - 1);
                accesses.Add(new Access
                {
                    StationFacility = context.StationFacilities.ToList()[SFNumber],
                    AccessIsAllowed = boolList[random.Next(0, 1)]
                });
            }
            return accesses;
        }

        void InitShootingPermission(StationDBContext context, Visitor parent )
        {
            context.ShootingPermissions.Add(new ShootingPermission
            {
                CameraType = "Sony",
                DateOfIssue = DateTime.Now,
                ValidUntil = DateTime.Now,
                ShootingPurpose = "Шпионские съеки",
                ShootingAllowed = context.Employees.First(),
                Accesses = InitAccess(context),
                Visitor = parent
            }); 
            context.SaveChanges();
        }
    }
}
