using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadQuantity
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\LOG";

            // Kiểm tra xem tệp có tồn tại không
            if (File.Exists(filePath))
            {
                try
                {
                    // Đọc nội dung của tệp
                    string content = File.ReadAllText(filePath);

                    // In ra nội dung của tệp
                    Console.WriteLine("Nội dung của tệp:");
                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi xảy ra: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Tệp không tồn tại.");
            }

            Console.ReadLine();

        }
    }
}
