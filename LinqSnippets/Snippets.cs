﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace LinqSnippets
{

    public class Snippets
    {

        static public void BasicLinQ()
        {
            string[] cars = { "VW Golf", "VW California", "Audi A5", "Audi A3", "Fiat Punto", "Seat Ibiza", "Sear León" };

            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT AUDI'S)
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList) { Console.WriteLine(audi); }


            Console.Read();
        }

        // Number Examples

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiplied by 3
            // take all numbers, but 9
            // Order numbers  by ascending value

            var processNumberList = numbers. // {3,6,9, etc.}
                Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string> {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all Elements
            var first = textList.First();

            // 2. First elemente that is "C"
            var ctext = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jtext = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // "" or element that contains "z"

            // 5. Last element that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // "" or element that contains "z"

            // 6. Single values
            var uniqueTexts = textList.Single();
            var uniqueDefaultTexts = textList.SingleOrDefault();

            int[] evenNumber = { 0, 2, 4, 6, 8 };
            int[] othenEvenNumber = { 0, 2, 6 };

            // Obtain { 4, 8 }
            var evenNumberList = evenNumber.Except(othenEvenNumber);
        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[] {
                new Enterprise()
                {
                    Id= 1,
                    Name = "Enterprise 1",
                    Employees = new []
                    {
                        new Employee{
                            Id= 1,
                            Name = "Sebastian",
                            Email = "sebas@gmail.com",
                            Salary = 1700
                        },
                        new Employee{
                            Id= 2,
                            Name = "Pepe",
                            Email = "Pepe@gmail.com",
                            Salary = 1700
                        },
                        new Employee{
                            Id= 3,
                            Name = "Juan",
                            Email = "Juan@gmail.com",
                            Salary = 1700
                        }
                    }
                },
                new Enterprise()
                {
                    Id= 2,
                    Name = "Enterprise 2",
                    Employees = new []
                    {
                        new Employee{
                            Id= 4,
                            Name = "Ana",
                            Email = "Ana@gmail.com",
                            Salary = 1700
                        },
                        new Employee{
                            Id= 5,
                            Name = "Pepe",
                            Email = "Pepe@gmail.com",
                            Salary = 1500
                        },
                        new Employee{
                            Id= 6,
                            Name = "Juan",
                            Email = "Juan@gmail.com",
                            Salary = 2000
                        }
                    }
                }

            };



            // Obtain all Employees of all Enterprises

            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if a list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at least has an employee with more than 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(
                        employeee => employeee.Salary >= 1000));
        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,
            };

            // SKIP

            var skipTwoFirstValues = myList.Skip(2);

            var skipTwoLasttValues = myList.SkipLast(2);

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // {4,5,6,7}

            // TAKE
            var takeFirstTwoValues = myList.Take(2); //{1,2}
            var takeTwoLasttValues = myList.SkipLast(2); // {9,10}
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // {1,2,3}

        }

        // Paging with Skip & Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from num in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(num, 2)
                               where nSquared > average
                               select num;

            Console.WriteLine($"Average: {numbers.Average()}");

            foreach (int num in aboveAverage)
            {
                Console.WriteLine($"Query: {num} Square: {Math.Pow(num, 2)}");
            }

        }

        // ZIP 
        static public void Ziplinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // { "1=one", "3=two", ... }
        }

        // Repeat & Range
        static public void repeatRangeLinq()
        {
            // Generate collection from 1 - 1000
            IEnumerable<int> first100 = Enumerable.Range(1, 1000);
            // Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"} 

        }

        static public void studentsLinq()
        {
            var classRoom = new Student[]
            {
                new Student{ Id = 1, Name = "Sebastian", Grade = 90, Certified = true },
                new Student{ Id = 2, Name = "Luis", Grade = 50, Certified = true },
                new Student{ Id = 3, Name = "Martin", Grade = 60, Certified = false },
                new Student{ Id = 4, Name = "Ana", Grade = 20, Certified = true },
                new Student{ Id = 5, Name = "Pedro", Grade = 50, Certified = true },
            };



            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where !student.Certified
                                       select student;

            var appovedStudentsNames = from student in classRoom
                                       where student.Grade >= 50
                                       &&
                                       student.Certified
                                       select student.Name;

        }

        // ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        // Aggregate
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 4 => 7
            // etc.

            string[] words = { "hello", "my", "name", "is", "Sebastian" }; // Hello my name is Sebastian
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

        }

        // Distinct
        static public void distincValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        // GroupBy
        static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doenst fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)
            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 .... 2,4,6,8 (first the odds and then the even)
                }
            }

            // Another example

            var classRoom = new Student[]
            {
                new Student{ Id = 1, Name = "Sebastian", Grade = 90, Certified = true },
                new Student{ Id = 2, Name = "Luis", Grade = 50, Certified = true },
                new Student{ Id = 3, Name = "Martin", Grade = 60, Certified = false },
                new Student{ Id = 4, Name = "Ana", Grade = 20, Certified = true },
                new Student{ Id = 5, Name = "Pedro", Grade = 50, Certified = true },
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified && student.Grade >= 50);

            // We obatin two groups
            // 1.- Not certified students
            // 2.- Certified Students
            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("---------- {0} ---------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); // 1,3,5,7,9 .... 2,4,6,8 (first the odds and then the even)
                }
            }
        }

        static public void relationLinq()
        {
            IEnumerable<Post> posts = new List<Post>()
            {
                new Post{ Id = 1,
                Title = "My first post",
                Content = "My first content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                    {
                        new Comment()
                            {
                                Id = 1,
                                Created = DateTime.Now,
                                Title = "My first comment",
                                Content = "My content"
                            },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My content"
                        }
                    }
                },
                new Post{ Id = 2,
                Title = "My second post",
                Content = "My second content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                    {
                        new Comment()
                            {
                                Id = 3,
                                Created = DateTime.Now,
                                Title = "My other comment",
                                Content = "My content"
                            },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My content"
                        }
                    }
                }
            };

            var commentsContent =
                posts.SelectMany(post =>
                post.Comments, (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });

        }
    }
}