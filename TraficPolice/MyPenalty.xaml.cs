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
    /// Логика взаимодействия для MyPenalty.xaml
    /// </summary>
    public partial class MyPenalty : Page
    {
        public MyPenalty(DriversCars driver)
        {
            InitializeComponent();
            var list = TrafficPoliceEntities.GetContext().IncidentsVolations.Select(p => new 
            {
                idDriver = p.Incident.idDriver,
                NameDriver = p.Incident.Driver.name,
                PenaltyName = p.penalty,
                StateP = p.State.StateTitle
            }).Where(x=> x.idDriver == driver.Driver.numDriverDocument).ToList();
            Penalty.ItemsSource = list;
        }
    }
}
