using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace HotelManagementApp
{
    public partial class UserWindow : Window
    {
        public UserWindow(string username)
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Title = $"Добро пожаловать, {username}!";
            WelcomeTextBlock.Text = $"Добро пожаловать, {username}!";
        }
        private void LoadExcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileSelectionComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string filePath = selectedItem.Tag.ToString();
                DataImporter importer = new DataImporter();
                List<Guest> guests = importer.ImportData(filePath);
                GuestsDataGrid.ItemsSource = guests; // Привязка данных к DataGrid
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите файл для загрузки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}