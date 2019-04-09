﻿using System;
using System.Linq;
using GradeBook.Enums;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading reqires at least 5 students");

            var trashold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[trashold - 1] <= averageGrade)
                return 'A';
            else if (grades[(trashold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(trashold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(trashold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 studens");
                return;
            }

            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 studens");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}