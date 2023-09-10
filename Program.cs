using System;
using System.Data.Common;
//перегрузка операторов
namespace Lesson_5
{


    /// <summary>
    /// dgxdfsgdfgdzfg
    /// </summary>
    public class Int
    {
        protected int _number;
        public int n { get { return this._number; } set { this._number = value; } }
        public Int(int number)
        {
            this._number = number;
        }
        public static Int operator ++(Int i)
        {
            i.n++;
            return i;
        }
        public static Int operator +(Int i1, Int i2)
        {
            return new Int(i1.n + i2.n);
        }
        public static Int operator *(Int i1, Int i2)
        {
            return new Int(i1.n * i2.n);
        }
        public override bool Equals(object? a)
        {
            if (a == null) return false;
            return this.GetHashCode() == a.GetHashCode();
        }
        public override string ToString()
        {
            return this._number.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Int a, Int b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Int a, Int b)
        {
            return !a.Equals(b);
        }
        public static bool operator >(Int a, Int b)
        {
            return a.n > b.n;
        }
        public static bool operator <(Int a, Int b)
        {
            return a.n < b.n;
        }
        public static bool operator true(Int a)
        {
            return a.n != 0;
        }
        public static bool operator false(Int a)
        {
            return a.n == 0;
        }
        public static Int operator &(Int i1, Int i2)
        {
            //return ((i1.n != 0) && (i2.n != 0)) ? new Int(1) : new Int(0);
            return new Int(i1.n + i2.n);
        }
        public static implicit operator int(Int i)
        {
            return i.n;
        }

    }

    class Student
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int? age { get; set; }
        public Student(string? firstName, string? lastName, int? age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        public override string ToString()
        {
            return $"{firstName}, {lastName}, {age} лет";
        }
    }

    class Group
    {
        public string? name { get; set; }
        protected List<Student> students = new List<Student>();
        public Group(string name, params Student[] students)
        {
            this.name = name;
            foreach (Student student in students)
                this.students.Add(student);
        }
        public Group(string name, List<Student> students)
        {
            this.name = name;
            this.students = students;
        }
        public float AvgAge()
        {
            int sum = 0;
            foreach (var student in this.students)
                sum += student.age ?? 0;
            return sum / this.students.Count;
        }
        public Student this[int index]
        {
            get
            {
                return this.students[index];
            }
        }
        public Group this[string lastName]
        {
            get
            {
                List<Student> students = new();
                foreach (var student in this.students)
                {
                    if (student.lastName == lastName) students.Add(student);
                }
                return new Group(lastName, students);
            }
        }
        public override string ToString()
        {

            return this.students.ToString();
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Group g = new Group(
                "211",
                new Student("Саша", "сашин", 15),
                new Student("Петя", "Петин", 17),
                new Student("Вася", "Петин", 17)
                );
            Console.WriteLine(g.AvgAge());
            Console.WriteLine(g);
            Console.WriteLine(g["Петин"]);
        }
    }
}