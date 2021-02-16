using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender,EventArgs args); 


    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        // event GradeAddedDeleagte GradeAdded;
        // void ArrayIntilizer();

    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        // public abstract void ArrayIntilizer();

        public abstract Statistics GetStatistics();
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            var result=new Statistics();
            using(var reader=File.OpenText($"{Name}.txt"))
            {
                 var line=reader.ReadLine();
                 while(line!=null)
                 {
                     var number=double.Parse(line);
                     result.Add(number);
                     line =reader.ReadLine();
                 }
            }
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string SetName) : base(SetName)
        {
            grades = new List<double>();
            Name = SetName;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($" Invalid {nameof(grade)}");
            }
        }
        public event GradeAddedDelegate GradeAdded;

        // public override void ArrayIntilizer()
        // {
        //     var array = new double[3] { 3.3, 3.4, 2.4 };
        //     var total = array[0];
        //     total += array[1];
        //     total += array[2];


        //     foreach (var i in array)
        //     {
        //         total += i;
        //     }
        //     Console.WriteLine($"The value of array :{total}");

        // }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            int dataIsAvailable = grades.Count;
            // result.Average = 0.0;
            // result.Low = double.MaxValue;
            // result.High = double.MinValue;
         
            for(var index=0;index<grades.Count;index+=1)
            {
                result.Add(grades[index]);
                // result.Low = Math.Min(grades[index], result.Low);
                // result.High = Math.Max(grades[index], result.High);
                // result.Average += grade;
            }
            // switch (result.Average)
            //     {
            //         case var d when d >= 90.0:
            //             result.Letter = 'A';
            //             break;

            //         case var d when d >= 80.0:
            //             result.Letter = 'B';
            //             break;
            //         case var d when d >= 70.0:
            //             result.Letter = 'C';
            //             break;
            //         default:
            //             result.Letter = 'F';
            //             break;


            //     }
            // result.Average = result.Average / dataIsAvailable;

            return result;
        }

        List<double> grades;

    }

}