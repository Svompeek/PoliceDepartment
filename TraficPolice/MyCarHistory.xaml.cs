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
    /// Логика взаимодействия для MyCarHistory.xaml
    /// </summary>
    public partial class MyCarHistory : Page
    {
        DriversCars d;
        public MyCarHistory(DriversCars driver)
        {
            InitializeComponent();
            var list = TrafficPoliceEntities.GetContext().DriversCars.Select(p => new
            {
                idCar = p.Car.StateNumber,
                DriverName = p.Driver.name,
                idDriver = p.Driver.numDriverDocument,
                DateStart = p.dateStartDrive,
                DateEnd = p.dateEndDrive
            }).ToList().Where(x=> x.DateEnd == null && x.idDriver == driver.Driver.numDriverDocument);
            Drivers.ItemsSource = list;
            d = driver;
        }
    }
}
