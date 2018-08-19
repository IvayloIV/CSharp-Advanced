using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctors = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var departmentName = tokens[0];
                var currentDoctor = $"{tokens[1]} {tokens[2]}";
                var patient = tokens[3];
                if (!doctors.ContainsKey(currentDoctor))
                {
                    doctors[currentDoctor] = new List<string>();
                }
                doctors[currentDoctor].Add(patient);
                if (!department.ContainsKey(departmentName))
                {
                    department[departmentName] = new Dictionary<int, List<string>>();
                }
                var lastRoom = 1;
                var isFill = false;
                foreach (var currentRoom in department[departmentName])
                {
                    if (currentRoom.Value.Count < 3)
                    {
                        department[departmentName][currentRoom.Key].Add(patient);
                        isFill = true;
                        break;
                    }
                    lastRoom++;
                }
                if (!isFill)
                {
                    department[departmentName][lastRoom] = new List<string>
                    {
                        patient
                    };
                }
            }
            PrintResult(department, doctors);
        }

        private static void PrintResult(Dictionary<string, Dictionary<int, List<string>>> department, 
            Dictionary<string, List<string>> doctors)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var outputCriteria = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (outputCriteria.Length == 1)
                {
                    foreach (var item in department[outputCriteria[0]])
                    {
                        foreach (var item2 in item.Value)
                        {
                            Console.WriteLine(item2);
                        }
                    }
                }
                else if (int.TryParse(outputCriteria[1], out int ignoreMe))
                {
                    var patients = new List<string>();
                    var numberRoom = int.Parse(outputCriteria[1]);
                    foreach (var item in department[outputCriteria[0]])
                    {
                        if (item.Key == numberRoom)
                        {
                            patients.AddRange(item.Value);
                            break;
                        }
                    }
                    foreach (var item in patients.OrderBy(a => a))
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    var doctor = $"{outputCriteria[0]} {outputCriteria[1]}";
                    foreach (var item in doctors[doctor].OrderBy(a => a))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
