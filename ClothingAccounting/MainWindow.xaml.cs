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
        static ConnectedBase _connectedBase { get; } =
            new ConnectedBase(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gorob\source\repos\GorobVictor\ClothingAccounting\ClothingAccounting\DataBase\Base.mdf;Integrated Security=True");
        public MainWindow() {
            InitializeComponent();
            datagrid_Balance.ItemsSource = from pos in _connectedBase.Position.ToList()
                                           join dock in _connectedBase.Document.ToList() on pos.IdDock equals dock.Id
                                           group pos by new { pos.IdProduct, pos.IdSizeProduct, pos.IdColorProduct, pos.IdStaff } into final
                                           select new { final.Key.IdProduct, final.Key.IdSizeProduct, final.Key.IdColorProduct, final.Key.IdStaff, 
                                               Quantity = final.Sum(x => x.Document.Type == true ? x.Quantity : x.Quantity * -1) };


        }
    }
}
