using Labb_2_Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb_2_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using Labb2LinqDbContext context = new Labb2LinqDbContext();

            var Teachers = from t in context._Lärare
                           join ämn in context._Ämne on t.Id equals ämn.LärareId
                           where ämn.Name == "Matematik"
                           select t;

            Console.WriteLine("Skriver ut alla lärare som lär ut Matematik.");


            Console.WriteLine("__________________________________");
            foreach (var item in Teachers)
            {
                Console.WriteLine("Id: {0}\nName: {1}",item.Id,item.Name);
            }

            var students = from st in context._Student
                           join kur in context._Kurs
                           on st.KursId equals kur.Id
                           join lär in context._Lärare
                           on kur.LärareId equals lär.Id
                           select new
                           {
                               studentname = st.Name,
                               teachername = lär.Name,
                               kursname = kur.Name
                           };

            Console.WriteLine("__________________________________");


            Console.WriteLine("Student Med sina Lärare");

            Console.WriteLine("\nStudent\tTeacher\tKurs");
            foreach (var item in students)
            {
                Console.WriteLine($"\n{item.studentname}\t{item.teachername}\t{item.kursname}");
            }


            bool SC = (from sub in context._Ämne
                       select sub.Name).ToList().Contains("Programmering 1");

            Console.WriteLine("__________________________________");

            Console.WriteLine("Kollar om Programmering 1 finns i Ämnes Tabell.");

            Console.WriteLine(SC);

            Console.WriteLine();

            Console.WriteLine("Byter ett ämne till OOP");


            Console.WriteLine("__________________________________");

            var change = context._Ämne.SingleOrDefault(p => p.Name == "Programmering 2");
            foreach (var item in context._Ämne)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("__________________________________");

            if (change != null)
            {
                change.Name = "OOP";
                context.SaveChanges();
            }

            Console.WriteLine("__________________________________");

            foreach (var item in context._Ämne)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("__________________________________");

            Console.WriteLine("Uppdatera en Student om sin lärare från Anas till Reidar");

            var changeStudent = context._Student.SingleOrDefault(p => p.Name == "Lucas");
            changeStudent.KursId = 3;
            context.SaveChanges();

            Console.WriteLine("__________________________________");
            Console.WriteLine();

            foreach (var item in students)
            {
                Console.WriteLine($"\n{item.studentname}\t{item.teachername}\t{item.kursname}");
            }

            Console.ReadKey();
            
        }
    }
}
