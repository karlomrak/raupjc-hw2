using System;

namespace Assignment1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return(student1?.Name == student2?.Name && student1?.Jmbag == student2?.Jmbag);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1?.Name == student2?.Name && student1?.Jmbag==student2?.Jmbag);
        }

        public override bool Equals(object obj)
        {
            bool rc = false;
            if (obj is Student)
            {
                Student p2 = obj as Student;
                rc = (this == p2);
            }
            return rc; ;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

    }
    public enum Gender
    {
        Male, Female
    }
}