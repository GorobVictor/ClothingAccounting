using ClothingAccounting.DataBase.Model.sqlPeople;
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
using System.Windows.Shapes;

namespace ClothingAccounting {
    /// <summary>
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window {
        public Table() {
            InitializeComponent();
            datagrid_Table.ItemsSource = MainWindow._connectedBase.GetMovementOfGoods();
        }
        public void getTable(string value) {

        }

        private void btn_DownloadBalance_Click(object sender, RoutedEventArgs e) {
            var table = datagrid_Table.Items;
            var asd = table[0].GetType().Name;
            if (table.Count != 0)
                if (table[0].GetType().Name == "MovementOfGoods")
                    MessageBox.Show(MainWindow._connectedBase.SaveMovementOfGoods("MovementOfGoods"));
                else if (table[0].GetType().Name == "UsersProxy") 
                    MessageBox.Show(MainWindow._connectedBase.SaveUsers("Users")); 
                else if (table[0].GetType().Name == "StaffProxy") 
                    MessageBox.Show(MainWindow._connectedBase.SaveStaff("Staff")); 
        }

        private void rad_MovementOfGoods_Checked(object sender, RoutedEventArgs e) =>
            datagrid_Table.ItemsSource = MainWindow._connectedBase.GetMovementOfGoods();

        private void rad_Users_Checked(object sender, RoutedEventArgs e) =>
            datagrid_Table.ItemsSource = MainWindow._connectedBase.Users.AsEnumerable().ToList();

        private void rad_staff_Checked(object sender, RoutedEventArgs e) =>
            datagrid_Table.ItemsSource = MainWindow._connectedBase.Staff.AsEnumerable().ToList();
    }
}
