using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            Name = name;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("5 or more students are required for letter grades");
            var increment = Students.Count / 5;
            Console.WriteLine($"increment is {increment}");

            Students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));
            var studentIndex = Students.FindIndex(x => x.AverageGrade < averageGrade) - 1;
            Console.WriteLine($"studentIndex is {studentIndex}");

            var letterIndex = studentIndex / increment + 1;
            Console.WriteLine($"letterIndex is {letterIndex}");
            switch (letterIndex)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                default:
                    return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
