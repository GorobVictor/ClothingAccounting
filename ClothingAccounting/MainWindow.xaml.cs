using ClothingAccounting.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClothingAccounting {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static ConnectedBase _connectedBase { get; } =
            new ConnectedBase(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gorob\source\repos\GorobVictor\ClothingAccounting\ClothingAccounting\DataBase\Base.mdf;Integrated Security=True");
        public MainWindow() {
            InitializeComponent();
            /*Получение остатка товаров*/
            listView_Balance.ItemsSource = _connectedBase.GetBalance();
        }

        private void btn_DownloadBalance_Click(object sender, RoutedEventArgs e) {
            /*Сохранение товара*/
            MessageBox.Show(_connectedBase.SaveBalance("Save"));
        }

        private void btn_OpenTable_Click(object sender, RoutedEventArgs e) =>
            new Table().Show();
    }
}
