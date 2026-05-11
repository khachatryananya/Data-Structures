using System;

namespace MySetWpf
{
    public class Student : IComparable<Student>
    {
        public Student(int id, string name, Gender gender)
        {
            this.studentId = id;
            this.name = name;
            this.Gender = gender;
        }

        public int studentId { get; private set; }

        public string name { get; private set; }

        public Gender Gender { get; private set; }

        public int CompareTo(Student other)
        {
            return studentId.CompareTo(other.studentId);
        }

        public override string ToString()
        {
            return $"{studentId} - {name} - {Gender}";
        }
    }

   
}