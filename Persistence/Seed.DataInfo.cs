using Domain;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Http;
using Persistence.Constants;

namespace Persistence
{
    public partial class Seed
    {
        public static class DataInfo
        {

            public static List<BankModel> BanksData(AppUser authUser)
            {

                return new List<BankModel> {
                new BankModel(){Id=1,Name="البنك الاهلى المصرى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=2,Name="البنك التجارى الدولى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=3,Name=" بنك مصر",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=4,Name=" بنك قطر الوطنى الاهلى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=5,Name=" بنك HSBC",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    };
            }

            public static List<BankBranchModel> BankBranchData(AppUser authUser)
            {

                return new List<BankBranchModel> {
                new BankBranchModel(){Id=1,Name="باكوس", BankId=1,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=2,Name="فلمنج", BankId=1,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=3,Name=" باكوس", BankId=3,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=4,Name=" بولكلى", BankId=2,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=5,Name="سيدى جابر", BankId=2,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    };
            }
            public static List<DepartmentModel> DepartmentData(AppUser authUser)
            {

                return new List<DepartmentModel> {
                new DepartmentModel(){Id=1,Name="حسابات",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new DepartmentModel(){Id=2,Name="البرنامج الدولى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new DepartmentModel(){Id=3,Name=" مركز المؤتمرات",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new DepartmentModel(){Id=4,Name=" شئون العاملين",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new DepartmentModel(){Id=5,Name="شئون عامه",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    };
            }


            public static List<GradeModel> GradeData(AppUser authUser)
            {
                List<GradeModel> grades = new List<GradeModel>()
                {
                   new GradeModel() { Id = 1, Name = EmployeeGradeConstants.MOZAF, ParentId = null,Qanon= Domain.Constants.QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 2, Name = EmployeeGradeConstants.KABIR, ParentId = 1,Qanon= Domain.Constants.QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 3, Name = EmployeeGradeConstants.AWLA_A, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 4, Name = EmployeeGradeConstants.AWLA_B, ParentId = 1,Qanon= Domain.Constants.QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 5, Name = EmployeeGradeConstants.TANIA_A, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 6, Name = EmployeeGradeConstants.TANIA_B, ParentId = 1,Qanon= Domain.Constants.QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 7, Name = EmployeeGradeConstants.TALTA_A, ParentId = 1,Qanon= Domain.Constants.QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 8, Name = EmployeeGradeConstants.TALTA_B, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 9, Name = EmployeeGradeConstants.TALTA_C, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 10, Name = EmployeeGradeConstants.RABAA_A, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 11, Name = EmployeeGradeConstants.RABAA_B, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 12, Name = EmployeeGradeConstants.KHAMSA_A, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 13, Name = EmployeeGradeConstants.KHAMSA_B, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 14, Name = EmployeeGradeConstants.SADSA_A, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 15, Name = EmployeeGradeConstants.SADSA_B, ParentId = 1, Qanon= Domain.Constants.QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },

                    new GradeModel() { Id = 16, Name = FacultyMemberGradeConstants.FACULTY_MEMBERS, ParentId = null,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 17, Name = FacultyMemberGradeConstants.OSTAZ_MOTFAR5, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 18, Name = FacultyMemberGradeConstants.OSTAZ, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 19, Name = FacultyMemberGradeConstants.OSTAZ_MOSAAD, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 20, Name = FacultyMemberGradeConstants.MODARAS, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 21, Name = FacultyMemberGradeConstants.MODARAS_MOSAAD, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 22, Name = FacultyMemberGradeConstants.MOAAID, ParentId = 16,Qanon= Domain.Constants.QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                 };

                return grades;

            }
        }

    }


}