
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
                new BankModel(){Id=1,Name="البنك العربى الأفريقى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=2,Name="البنك الاهلى المصرى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=3,Name="بنك القاهرة",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=4,Name=" بنك مصر",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=5,Name=" بنك قطر الوطنى الاهلى",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankModel(){Id=6,Name=" بنك HSBC",CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                };
            }

            public static List<BankBranchModel> BankBranchData(AppUser authUser)
            {

                return new List<BankBranchModel> {
                new BankBranchModel(){Id=1,Name="مركز البطاقات", BankId=1,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=2,Name="مركز البطاقات", BankId=2,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new BankBranchModel(){Id=3,Name=" باكوس", BankId=2,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
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
                   new GradeModel() { Id = 1, Name = EmployeeGradeConstants.MOZAF, ParentId = null,Qanon= QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 2, Name = EmployeeGradeConstants.KABIR, ParentId = 1,Qanon=QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 3, Name = EmployeeGradeConstants.AWLA_A, ParentId = 1, Qanon=QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 4, Name = EmployeeGradeConstants.AWLA_B, ParentId = 1,Qanon= QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 5, Name = EmployeeGradeConstants.TANIA_A, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 6, Name = EmployeeGradeConstants.TANIA_B, ParentId = 1,Qanon=  QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 7, Name = EmployeeGradeConstants.TALTA_A, ParentId = 1,Qanon=  QanonEnum.Qanon81, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 8, Name = EmployeeGradeConstants.TALTA_B, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 9, Name = EmployeeGradeConstants.TALTA_C, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 10, Name = EmployeeGradeConstants.RABAA_A, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 11, Name = EmployeeGradeConstants.RABAA_B, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 12, Name = EmployeeGradeConstants.KHAMSA_A, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 13, Name = EmployeeGradeConstants.KHAMSA_B, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 14, Name = EmployeeGradeConstants.SADSA_A, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 15, Name = EmployeeGradeConstants.SADSA_B, ParentId = 1, Qanon=  QanonEnum.Qanon81,CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },

                    new GradeModel() { Id = 16, Name = FacultyMemberGradeConstants.FACULTY_MEMBERS, ParentId = null,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 17, Name = FacultyMemberGradeConstants.OSTAZ_MOTFAR5, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 18, Name = FacultyMemberGradeConstants.OSTAZ, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 19, Name = FacultyMemberGradeConstants.OSTAZ_MOSAAD, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 20, Name = FacultyMemberGradeConstants.MODARAS, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 21, Name = FacultyMemberGradeConstants.MODARAS_MOSAAD, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                    new GradeModel() { Id = 22, Name = FacultyMemberGradeConstants.MOAAID, ParentId = 16,Qanon=  QanonEnum.Qanon49, CreatedBy = authUser?.Id, CteaedAt = DateTime.Now },
                 };

                return grades;

            }

            public static List<AccountTreeModel> AccountTreeModels(AppUser authUser)
            {

                return new List<AccountTreeModel> {

                //21110000
                new AccountTreeModel(){Id=21110000,Name="اجور و البدلات النقديه و العينيه",AccountParentId=null,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                //21110100
                new AccountTreeModel(){Id=21110100,Name="الوظائف الدائمه",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110101,Name=AccountsTreeConstants.MORATABAT_ASASIA,AccountParentId=21110100,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110105,Name=AccountsTreeConstants.WAZIFI,AccountParentId=21110100,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},

                //21110200
                new AccountTreeModel(){Id=21110200,Name="الوظائف المؤقته",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},


                //21110300
                new AccountTreeModel(){Id=21110300,Name="المكافات",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110321,Name=AccountsTreeConstants.HAFEZ_OKHRA,AccountParentId=21110300,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110326,Name=AccountsTreeConstants.HAFEZ_TAWIDI,AccountParentId=21110300,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110328,Name=AccountsTreeConstants.HAFEZ_ADAFI,AccountParentId=21110300,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},


                //21110400
                new AccountTreeModel(){Id=21110400,Name="بدلات نوعيه",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},


                //21110500
                new AccountTreeModel(){Id=21110500,Name="مزايا نقديه",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110511,Name=AccountsTreeConstants.ALAWA_KHALAA_M3ISHA,AccountParentId=21110500,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21110512,Name=AccountsTreeConstants.ALWAA_ALHAD_ALADNA_HEZMA_AGTMA3IA,AccountParentId=21110500,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},


                //21110600
                new AccountTreeModel(){Id=21110600,Name="مزايا عينيه",AccountParentId=21110000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},

                ////مزايا تأمينيه

                new AccountTreeModel(){Id=21120000,Name="المزايا التأمينيه",AccountParentId=null,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                //21120100    
                new AccountTreeModel(){Id=21120100,Name="حصة الحكومه فى صتدوق التأمين الاجتماعى",AccountParentId=21120000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21120101,Name=AccountsTreeConstants.T2MINAT_12_PERCENT,AccountParentId=21120100,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21120102,Name=AccountsTreeConstants.T2MINAT_1_PERCENT,AccountParentId=21120100,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                //21120200
                new AccountTreeModel(){Id=21120200,Name="مزايا تأمينيه اخرى",AccountParentId=21120000,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21120201,Name=AccountsTreeConstants.T2MINAT_3_PERCENT,AccountParentId=21120200,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new AccountTreeModel(){Id=21120202,Name=AccountsTreeConstants.T2MINAT_125_PERCENT,AccountParentId=21120200,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},

                };
            }


            public static List<AccountTreeDetailsModel> AccountTreeDataModels(AppUser authUser)
            {


                return new List<AccountTreeDetailsModel> {
                    // 21110105 الاجر الوظيفى
                    new AccountTreeDetailsModel(){Id=1002,Name=AccountTreeDataConstants.WAZIFI_ASASI,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1003,Name=AccountTreeDataConstants.WAZIFI_ASASI_100,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1004,Name=AccountTreeDataConstants.WAZIFI_HAD_ADNA,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1005,Name=AccountTreeDataConstants.WAZIFI_ALAWA_KHASA,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1006,Name=AccountTreeDataConstants.WAZIFI_BADAL_ALAWA,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1007,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2015,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1008,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2016,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1009,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2017,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1010,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2017_ASTSNAIA,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1011,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2018,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1012,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2018_ASTSNAIA,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1013,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2019,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1014,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2020,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1015,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2021,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1016,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2022,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=1017,Name=AccountTreeDataConstants.WAZIFI_ALAWAA_DAWRIA_2023,AccountTreeId=21110105,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},




                    //21110321 حافز اضافى
                    new AccountTreeDetailsModel(){Id=2001,Name=AccountTreeDataConstants.MOKAMEL_50_ASASI,AccountTreeId=21110321,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2002,Name=AccountTreeDataConstants.MOKAMEL_BADAL_GAWDA,AccountTreeId=21110321,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2004,Name=AccountTreeDataConstants.MOKAMEL_HAD_ADNA,AccountTreeId=21110321,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2003,Name=AccountTreeDataConstants.MOKAMEL_MOSTABAD,AccountTreeId=21110321,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},


                    //21110328 حافز اضافى 2019 قانون 81
                    new AccountTreeDetailsModel(){Id=2006,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_2019,AccountTreeId=21110328,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2007,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_2020,AccountTreeId=21110328,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2008,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_2021,AccountTreeId=21110328,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2009,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_2022,AccountTreeId=21110328,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    new AccountTreeDetailsModel(){Id=2010,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_2023,AccountTreeId=21110328,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},

                    //21110511  علاوة غلاء معيشه
                    new AccountTreeDetailsModel(){Id=2011,Name=AccountTreeDataConstants.MOKAMEL_HAFEZ_ALWAT_KHALAA_MA3ISHA,AccountTreeId=21110511,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    //21110512 علاوة الحد الادنى للحزمه الاجتماعيه
                    new AccountTreeDetailsModel(){Id=2012,Name=AccountTreeDataConstants.MOKAMEL_HAD_ADNA_2023,AccountTreeId=21110512,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                    // 21110326 الحافز التعويضى
                    new AccountTreeDetailsModel(){Id=4001,Name=AccountTreeDataConstants.TAWIDI_2015,AccountTreeId=21110326,CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                   };
            }
            public static List<CollectionModel> CollectionModelData(AppUser authUser)
            {

                return new List<CollectionModel> {
                new CollectionModel(){Id=1,Name="'طب -مؤقتين'", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new CollectionModel(){Id=2,Name="طب -دائمين", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new CollectionModel(){Id=3,Name=" طب -مدرس", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new CollectionModel(){Id=4,Name=" طب -أستاذ مساعد", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new CollectionModel(){Id=5,Name="طب-أستاذ", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                };
            }
            public static List<VacationTypeModel> VacationTypeData(AppUser authUser)
            {

                return new List<VacationTypeModel> {
                new VacationTypeModel(){Id=1,Name="اجازة بسبب امراض مزمنه", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=2,Name="اجازة وضع", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=3,Name="اجازة 25 فى المئه من المرتب", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=4,Name="اجازة 50 فى المئه من المرتب", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=5,Name="اجازة 75 فى المئه من المرتب", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=6,Name="اجازة بدون اجر", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=7,Name="اجازة رعاية طفل", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=8,Name="اجازة خدمة عسكريه", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=9,Name="بعثات", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                new VacationTypeModel(){Id=10,Name="غياب بدون اذن", CreatedBy = authUser?.Id,CteaedAt=DateTime.Now},
                };
            }

        }

    }


}