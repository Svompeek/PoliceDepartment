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
    /// Логика взаимодействия для AddEditDriver.xaml
    /// </summary>
    public partial class AddEditDriver : Page
    {
        private Driver _currentDriver = new Driver();
        public AddEditDriver(Driver selectedDriver)
        {
            InitializeComponent();
            if (selectedDriver != null)
                _currentDriver = selectedDriver;

            DataContext = _currentDriver;
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentDriver.numDriverDocument == 0)
                {
                    TrafficPoliceEntities.GetContext().Driver.Add(_currentDriver);
                }

                TrafficPoliceEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } //Сохранить водителя
    }
}
