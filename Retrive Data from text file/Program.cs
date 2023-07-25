using System;
using System.IO;

namespace StudentDataRetrieval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the file path:");
                string filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    Console.WriteLine("Student Data:");

                    string studentId = null;
                    string name = null;
                    int age = 0;
                    string grade = null;

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(':');
                        if (data.Length == 2)
                        {
                            string label = data[0].Trim();
                            string value = data[1].Trim();

                            if (label.Equals("Student id", StringComparison.OrdinalIgnoreCase))
                            {
                                studentId = value;
                            }
                            else if (label.Equals("Name", StringComparison.OrdinalIgnoreCase))
                            {
                                name = value;
                            }
                            else if (label.Equals("Age", StringComparison.OrdinalIgnoreCase))
                            {
                                age = int.Parse(value);
                            }
                            else if (label.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                            {
                                grade = value;
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(line))
                        {
                           
                            if (!string.IsNullOrWhiteSpace(studentId) &&
                                !string.IsNullOrWhiteSpace(name) &&
                                age > 0 &&
                                !string.IsNullOrWhiteSpace(grade))
                            {
                                Console.WriteLine($"Student ID: {studentId}");
                                Console.WriteLine($"Name: {name}");
                                Console.WriteLine($"Age: {age}");
                                Console.WriteLine($"Grade: {grade}");
                                Console.WriteLine();
                            }

                            studentId = null;
                            name = null;
                            age = 0;
                            grade = null;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(studentId) &&
                        !string.IsNullOrWhiteSpace(name) &&
                        age > 0 &&
                        !string.IsNullOrWhiteSpace(grade))
                    {
                        Console.WriteLine($"Student ID: {studentId}");
                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Age: {age}");
                        Console.WriteLine($"Grade: {grade}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}


