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

namespace TraficPolice
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            var list = TrafficPoliceEntities.GetContext().DriversCars.Select(p => new
            {
                p.idDriver,
                StateNumber = p.Car.StateNumber,
                mark = p.Car.mark,
                model = p.Car.model,
                color = p.Car.color,
                madeYear = p.Car.madeYear,
                driverName = p.Driver.name,
                DateStart = p.dateStartDrive,
                DateEnd = p.dateEndDrive
            }).ToList().Where(x => x.DateEnd != null); //Выбор данных из двух таблиц по связной таблице DriversCars

            if (!string.IsNullOrWhiteSpace(txt_search.Text))
            {
                list = list.Where(x => x.StateNumber.ToLower().Contains(txt_search.Text.ToLower())).ToList();
            }
            HistoryList.ItemsSource = list.ToList();

            HistoryList.ItemsSource = list;
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
    }

}
