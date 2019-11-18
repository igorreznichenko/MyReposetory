using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11_part_2
{
    static class Extension
    {
        static int i = 1;
        public static List<Student> FindStudent(this List<Student> students, StudentPredicateDelegate Check_Student)
        {
            List<Student> result = new List<Student>();
            foreach (Student l in students)
            {
                if (Check_Student(l))
                    result.Add(l);
            }
            return result;
        }
        public static void Show_List(this List<Student> Student_List)
        {
            Console.WriteLine("Result {0}", i);
            foreach (Student l in Student_List)
            {               
              Console.WriteLine("firstName : {0}", l.FirstName);
                Console.WriteLine("lastName : {0}", l.LastName);
                Console.WriteLine("Age : {0}", l.Age);
            }
            Console.WriteLine();
            i++;

        }
    }
   public class Student
    {
        string firstname;
        string lastname;
        int age;
        public Student(string firstname,string lastname, int age)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }
        public string FirstName
        {
            get {return firstname;}
           
        }
        public string LastName
        {
            get { return lastname;}
            
        }
        public int Age
        {
            get { return age;}
          
        }
        static public bool Check_Age(Student s)
        {

            return s.Age >= 18;
        }
        static public bool Check_First_Name(Student s)
        {
            return s.FirstName[0] == 'A';
        }
        static public bool Check_Last_Name(Student s)
        {
            return s.LastName.Length > 3;
        }
    }
    public delegate bool StudentPredicateDelegate(Student s);

    class Program
    {
        static void Main(string[] args)
        {
           
            List<Student> Student_List = new List<Student>();
            List<Student> Result_List = new List<Student>();
            Student_List.Add(new Student("Vania", "Petrenko", 17));
            Student_List.Add(new Student("Kiril", "Danilenko", 19));
            Student_List.Add(new Student("Vadim", "Petruk", 18));
            Student_List.Add(new Student("Anna", "Klimenuk", 18));
            Student_List.Add(new Student("Andrew", "Petrath", 16));
            Student_List.Add(new Student("Ilia", "Makosiy", 17));
            Student_List.Add(new Student("Vasia", "Petrovich", 16));
            Student_List.Add(new Student("Anton", "Berezeckiy", 20));
            Student_List.Add(new Student("Yaroslav", "Troeslen", 25));
            Student_List.Add(new Student("Yaroslav", "Tarasenko", 25));
            Student_List.Add(new Student("Petro", "Bojko", 25));

            StudentPredicateDelegate check = Student.Check_Last_Name;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

            check = Student.Check_First_Name;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

            check = Student.Check_Age;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

            check = (s)=>s.Age >= 18;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

            check = (s)=>s.FirstName[0] == 'A';
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

            check = (s)=>s.LastName.Length > 3;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();


            check = (s) => s.Age > 20 && s.Age <= 25;
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();


            check = (s) => s.FirstName == "Andrew";
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();


            check = (s) => s.LastName == "Troeslen";
            Result_List = Student_List.FindStudent(check);
            Result_List.Show_List();

        }
    }
}
