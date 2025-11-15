using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    internal class ManageStudents
    {

        class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Khoa { get; set; }
            public double DiemTB { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                int choice;

                do
                {
                    Console.WriteLine("\n===== MENU =====");
                    Console.WriteLine("1. Add student");
                    Console.WriteLine("2. Show all students");
                    Console.WriteLine("3. Students of Khoa CNTT");
                    Console.WriteLine("4. Students with DiemTB >= 5");
                    Console.WriteLine("5. Sort by DiemTB (ascending)");
                    Console.WriteLine("6. Students DiemTB >= 5 & Khoa CNTT");
                    Console.WriteLine("7. Students with highest DiemTB & Khoa CNTT");
                    Console.WriteLine("8. Count student by ranking");
                    Console.WriteLine("0. Exit");
                    Console.Write("Your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddStudent(students); break;
                        case 2: ShowAll(students); break;
                        case 3: ShowKhoaCNTT(students); break;
                        case 4: ShowDiemLonHon5(students); break;
                        case 5: SortByDiem(students); break;
                        case 6: ShowDiem5AndCNTT(students); break;
                        case 7: ShowMaxDiemCNTT(students); break;
                        case 8: CountRanking(students); break;

                        case 0:
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }

                } while (choice != 0);
            }

            // ===================== FUNCTIONS =========================

            static void AddStudent(List<Student> list)
            {
                Student s = new Student();

                Console.Write("Enter ID: ");
                s.Id = Console.ReadLine();

                Console.Write("Enter Name: ");
                s.Name = Console.ReadLine();

                Console.Write("Enter Khoa: ");
                s.Khoa = Console.ReadLine();

                Console.Write("Enter DiemTB: ");
                s.DiemTB = double.Parse(Console.ReadLine());

                list.Add(s);
                Console.WriteLine("Added successfully!");
            }

            static void ShowAll(List<Student> list)
            {
                Console.WriteLine("\n--- ALL STUDENTS ---");
                foreach (var s in list)
                    PrintStudent(s);
            }

            static void ShowKhoaCNTT(List<Student> list)
            {
                Console.WriteLine("\n--- STUDENTS FROM KHOA CNTT ---");
                var result = list.Where(s => s.Khoa.ToUpper() == "CNTT");
                foreach (var s in result) PrintStudent(s);
            }

            static void ShowDiemLonHon5(List<Student> list)
            {
                Console.WriteLine("\n--- STUDENTS DiemTB >= 5 ---");
                var result = list.Where(s => s.DiemTB >= 5);
                foreach (var s in result) PrintStudent(s);
            }

            static void SortByDiem(List<Student> list)
            {
                Console.WriteLine("\n--- SORT BY DiemTB ASC ---");
                var result = list.OrderBy(s => s.DiemTB);
                foreach (var s in result) PrintStudent(s);
            }

            static void ShowDiem5AndCNTT(List<Student> list)
            {
                Console.WriteLine("\n--- Diem >= 5 & Khoa CNTT ---");
                var result = list.Where(s => s.DiemTB >= 5 && s.Khoa.ToUpper() == "CNTT");
                foreach (var s in result) PrintStudent(s);
            }

            static void ShowMaxDiemCNTT(List<Student> list)
            {
                Console.WriteLine("\n--- HIGHEST Diem & Khoa CNTT ---");
                var cntt = list.Where(s => s.Khoa.ToUpper() == "CNTT");

                if (!cntt.Any())
                {
                    Console.WriteLine("No students in CNTT");
                    return;
                }

                double maxDiem = cntt.Max(s => s.DiemTB);
                var result = cntt.Where(s => s.DiemTB == maxDiem);

                foreach (var s in result) PrintStudent(s);
            }

            static void CountRanking(List<Student> list)
            {
                Console.WriteLine("\n--- RANKING COUNT ---");

                int xs = list.Count(s => s.DiemTB >= 9);
                int gioi = list.Count(s => s.DiemTB >= 8 && s.DiemTB < 9);
                int kha = list.Count(s => s.DiemTB >= 7 && s.DiemTB < 8);
                int tb = list.Count(s => s.DiemTB >= 5 && s.DiemTB < 7);
                int yeu = list.Count(s => s.DiemTB >= 4 && s.DiemTB < 5);
                int kem = list.Count(s => s.DiemTB < 4);

                Console.WriteLine($"Xuất sắc: {xs}");
                Console.WriteLine($"Giỏi: {gioi}");
                Console.WriteLine($"Khá: {kha}");
                Console.WriteLine($"Trung bình: {tb}");
                Console.WriteLine($"Yếu: {yeu}");
                Console.WriteLine($"Kém: {kem}");
            }

            static void PrintStudent(Student s)
            {
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Khoa: {s.Khoa} | DiemTB: {s.DiemTB}");
            }
        }
    }
}

