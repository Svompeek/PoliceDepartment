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
    /// Логика взаимодействия для AddIncident.xaml
    /// </summary>
    public partial class AddIncident : Page
    {
        public AddIncident()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IDInspector = Convert.ToInt32(IDIns.Text);
                int IDDriver = Convert.ToInt32(IDDri.Text);
                string IDCar = IDC.Text;
                string Depr = depr.Text;
                int Violation = Convert.ToInt32(viol.Text);
                Incident i = new Incident();
                i.idInspector = IDInspector;
                i.idDriver = IDDriver;
                i.idCar = IDCar;
                i.deprivationLicense = Depr;
                TrafficPoliceEntities.GetContext().Incident.Add(i);
                TrafficPoliceEntities.GetContext().SaveChanges();
                IncidentsVolations incidentsVolations = new IncidentsVolations();
                incidentsVolations.idIncident++;
                incidentsVolations.idVolation = Violation;
                TrafficPoliceEntities.GetContext().IncidentsVolations.Add(incidentsVolations);
                TrafficPoliceEntities.GetContext().SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
