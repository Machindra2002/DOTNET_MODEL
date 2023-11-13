using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramWork_CURD
{
    internal class Program
    {
        ADOEntities1 db;
        public Program()
        {
            db = new ADOEntities1 ();
        }

        public List<Student> FetchStudent()
        {
            List<Student> lst =new List<Student>();
            foreach(Student s in db.Students.ToList())
            {
                Console.WriteLine(s.rno + " " + s.sname + " " + s.qualification + " " + s.percentage);
                lst.Add(s);
            }
            return lst;
        }

        public void addStudent()
        {
            Student s = new Student()
            {
                sname = "Suraj",
                qualification="BCS",
                percentage=84
            };
            db.Students.Add(s);
            db.SaveChanges();
            Console.WriteLine("added successfully");
        }
        public void getStudentById(int id)
        {
            Student s = db.Students.Find(id);
            Console.WriteLine(s.rno + " " + s.sname + " " + s.qualification + " " + s.percentage);
        }

        public void getStudentByParameter()
        {
            //Student s = db.Students.FirstOrDefault(e => e.rno.Equals(2));
            List<Student> st = db.Students.ToList().Where(e => e.percentage > 79).ToList();
            foreach (Student s in st)
            {
                Console.WriteLine(s.rno + " " + s.sname + " " + s.qualification + " " + s.percentage);
            }
        }

        public void updateStudent()
        {
            Student s = db.Students.Find(1004);
            s.sname = "Tejas";
            s.qualification = "Bcom";
            s.percentage = 71;
            
            db.SaveChanges();
            Console.WriteLine("update successfully");
        }

        public void deleteStudent(int id)
        {
            Student st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            Console.WriteLine("deleted student");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            // p.addStudent();
            // p.getStudentById(1003);
            // p.getStudentByParameter();
            p.deleteStudent(1004);
             p.FetchStudent();
           // p.updateStudent();
            Console.ReadLine();
        }
    }
}
