﻿using Demo3_CRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace Demo3_CRUD.Repository
{
    public class StudentRepository
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1,FName="Mostafa",LName="Mahmoud",Age=26,Email="mmr16rady@yahoo.com"},
            new Student(){Id=2,FName="Alaa",LName="Mahmoud",Age=30,Email="mmnear16@gmail.com"},
            new Student(){Id=3,FName="Ahmed",LName="Mahmoud",Age=34,Email="abc@g.com"},
            new Student(){Id=4,FName="Asmaa",LName="Mahmoud",Age=24,Email="efg@e.net"}

        };

        public static List<Student> GetStudents()
        {
            return students;
        }
        public static void AddStudent(Student student)
        {
            students.Add(student);
        }

        public static Student GetStudentDetails(int id)
        {
            var std = students.FirstOrDefault(q => q.Id == id);
            return std;
        }

        public static void DelStudent(int id)
        {
            var Std = students.FirstOrDefault(w => w.Id == id);
            if (Std != null)
                students.Remove(Std);
        }

        public static void UpdateStudent(Student student)
        {
            var Std = students.FirstOrDefault(w => w.Id == student.Id);
            if (Std != null)
            {
                Std.FName = student.FName;
                Std.LName = student.LName;
                Std.Age = student.Age;
                Std.Email = student.Email;
            }
        }
    }
}