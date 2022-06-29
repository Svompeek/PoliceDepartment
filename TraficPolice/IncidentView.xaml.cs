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
    /// Логика взаимодействия для IncidentView.xaml
    /// </summary>
    public partial class IncidentView : Page
    {
        public IncidentView()
        {
            InitializeComponent();
            IncidentGrid.ItemsSource = TrafficPoliceEntities.GetContext().IncidentsVolations.Select(p => new
            {
                IDINSPECTOR = p.Incident.Inspector.tabNum,
                DRIVER = p.Incident.Driver.numDriverDocument,
                CAR = p.Incident.Car.StateNumber,
                LICENSE = p.Incident.deprivationLicense,
                VIOL = p.Violation.ViolationTitle,
            }).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddIncident());
        }
    }
}
