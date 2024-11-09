using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
namespace HotelManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8" }, // Замените на ваш хеш
            { "cos", "5f4dcc3b5aa765d61d8327deb882cf99" } // Замените на ваш хеш
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            if (users.ContainsKey(username) && VerifyPassword(password, users[username]))
            {
                UserWindow userWindow = new UserWindow(username);
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool VerifyPassword(string password, string hash)
        {
            string hashedPassword = ComputeMd5Hash(password);
            return hashedPassword.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
        private string ComputeMd5Hash(string rawData)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}