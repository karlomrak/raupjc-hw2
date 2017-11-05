using System;
using System.Data.Common;
using System.Linq;
using Assignment1;

namespace Assignment4
{
    public class HomeworkLinqQueries
    {
        public static string [] Linq1 (int [] intArray )
        {
            var query = intArray.GroupBy(n => n).OrderBy(x => x)
                .Select(s => $"Broj {s.Key} ponavlja se {s.Count()} puta.").ToArray();
            return query;
        }
        public static University [] Linq2_1 ( University [] universityArray )
        {
            var query = universityArray.Where(f=>!f.Students.Any(s=>s.Gender.Equals(Gender.Female))).ToArray();
            return query;
        }
        public static University [] Linq2_2 ( University [] universityArray )
        {
            double average = universityArray.Average(s=>s.Students.Count()) ;
            return universityArray.Where(u => u.Students.Count() < average).ToArray();
        }
        public static Student [] Linq2_3 ( University [] universityArray )
        {
            return universityArray.SelectMany(u=>u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => !u.Students.Any(s => s.Gender.Equals(Gender.Female))
                                                   || !u.Students.Any(s => s.Gender.Equals(Gender.Male)))
                .SelectMany(s=>s.Students).Distinct().ToArray();
        }

        public static Student [] Linq2_5 ( University [] universityArray )
        {
            return universityArray.SelectMany(s => s.Students).GroupBy(s=>s).Where(s=>s.Count()>=2).Select(s=>s.Key).
                ToArray() ;
        }
    }

}