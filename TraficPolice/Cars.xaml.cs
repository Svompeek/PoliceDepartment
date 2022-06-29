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
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        public Cars()
        {
            InitializeComponent();
            
        }

        private void cmb_mark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TrafficPoliceEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
            var markList = TrafficPoliceEntities.GetContext().Car.ToList();
            markList.Insert(0, new Car() { mark = "Все" });
            cmb_mark.ItemsSource = markList;
            RefreshData();
        }
        public void RefreshData()
        {
            var result = TrafficPoliceEntities.GetContext().DriversCars.Select(p => new
            {
                p.dateEndDrive,
                p.idDriver,
                StateNumber = p.Car.StateNumber,
                mark = p.Car.mark,
                model = p.Car.model,
                color = p.Car.color,
                madeYear = p.Car.madeYear,
                driverName = p.Driver.name,
            }).ToList().Where(p => p.dateEndDrive == null); //Выбор данных из двух таблиц по связной таблице DriversCars

            if (cmb_mark.SelectedIndex > 0)
            {
                Car car = cmb_mark.SelectedItem as Car;
                result = result.Where(x => x.mark == car.mark).ToList();
            }
            if(!string.IsNullOrWhiteSpace(txt_search.Text))
            {
                result = result.Where(x => x.StateNumber.ToLower().Contains(txt_search.Text.ToLower())).ToList();
            }
            CarsList.ItemsSource = result.ToList();
        }
    }
}
