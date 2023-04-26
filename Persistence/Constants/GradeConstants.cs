using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Constants
{
    public static class EmployeeGradeConstants
    {

        public static string MOZAF = "موظف";
        public static string KABIR = "كبير";
        public static string AWLA = "درجة اولى";
        public static string TANIA = "درجة الثانيه";

        public static string TALTA = "درجة الثالثه";
        public static string RABAA = "درجة الرابعه";
        public static string KHAMSA = "درجة الخامسه";
        public static string SADSA = "درجة السادسه";

        public static List<string> GetEmAll()
        {
            List<string> results = new List<string>();
            results.Add(MOZAF);
            results.Add(KABIR);
            results.Add(AWLA);
            results.Add(TANIA);
            results.Add(TALTA);
            results.Add(RABAA);
            results.Add(KHAMSA);
            results.Add(SADSA);

            return results;
        }
    }

    public static class EmployeeSubGradeConstants
    {

        public static string A = "أ";
        public static string B = "ب ";
        public static string C = "ج ";

        public static List<string> GetEmAll()
        {
            List<string> results = new List<string>();
            results.Add(A);
            results.Add(B);
            results.Add(C);

            return results;
        }
    }


    public static class FacultyMemberGradeConstants
    {
        public static string FACULTY_MEMBERS = "هيئة تدريس";
        public static string OSTAZ_MOTFAR5 = "أستاذ متفرغ";
        public static string OSTAZ = "أستاذ ";
        public static string OSTAZ_MOSAAD = "أستاذ مساعد";
        public static string MODARAS = "مدرس";
        public static string MODARAS_MOSAAD = "مدرس مساعد";
        public static string MOAAID = "معيد";

        public static List<string> GetEmAll()
        {
            List<string> results = new List<string>();
            results.Add(FACULTY_MEMBERS);
            results.Add(OSTAZ_MOTFAR5);
            results.Add(OSTAZ);
            results.Add(OSTAZ_MOSAAD);
            results.Add(MODARAS);
            results.Add(MODARAS_MOSAAD);
            results.Add(MOAAID);
            return results;
        }
    }
}