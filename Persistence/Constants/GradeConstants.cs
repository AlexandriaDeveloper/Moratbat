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
        public static string AWLA_A = "درجة اولى-أ";
        public static string AWLA_B = "درجة اولى-ب";
        public static string TANIA_A = "درجة الثانيه-أ";
        public static string TANIA_B = "درجة الثانيه-ب";
        public static string TALTA_A = "درجة الثالثه-أ";
        public static string TALTA_B = "درجة الثالثه-ب";
        public static string TALTA_C = "درجة الثالثه-ج";
        public static string RABAA_A = "درجة الرابعه-أ";
        public static string RABAA_B = "درجة الرابعه-ب";
        public static string KHAMSA_A = "درجة الخامسه-أ";
        public static string KHAMSA_B = "درجة الخامسه-ب";
        public static string SADSA_A = "درجة السادسه-أ";
        public static string SADSA_B = "درجة السادسه-ب";

        public static List<string> GetEmAll()
        {
            List<string> results = new List<string>();
            results.Add(MOZAF);
            results.Add(KABIR);
            results.Add(AWLA_A);
            results.Add(AWLA_B);
            results.Add(TANIA_A);
            results.Add(TANIA_B);
            results.Add(TALTA_A);
            results.Add(TALTA_B);
            results.Add(TALTA_C);
            results.Add(RABAA_A);
            results.Add(RABAA_B);
            results.Add(KHAMSA_A);
            results.Add(KHAMSA_B);
            results.Add(SADSA_A);
            results.Add(SADSA_B);


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