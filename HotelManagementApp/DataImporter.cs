using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
namespace HotelManagementApp
{
    public class Guest
    {
        public string Column1 { get; set; } // Имя
        public string Column2 { get; set; } // Номер комнаты
        public string Column3 { get; set; } // Дополнительная информация (если требуется)
    }
    public class DataImporter
    {
        public List<Guest> ImportData(string filePath)
        {
            List<Guest> guests = new List<Guest>();
            if (File.Exists(filePath))
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Получаем первый лист
                    int rowCount = worksheet.Dimension.Rows; // Получаем количество строк
                    for (int row = 2; row <= rowCount; row++) // Начинаем с 2, чтобы пропустить заголовок
                    {
                        var column1 = worksheet.Cells[row, 1].Text; // Значение из первого столбца
                        var column2 = worksheet.Cells[row, 2].Text; // Значение из второго столбца
                        var column3 = worksheet.Cells[row, 3].Text; // Значение из третьего столбца (если требуется)
                        guests.Add(new Guest
                        {
                            Column1 = column1,
                            Column2 = column2,
                            Column3 = column3
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл не найден: {filePath}");
            }
            return guests;
        }
    }
}