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
    /// Логика взаимодействия для AddEditViolation.xaml
    /// </summary>
    public partial class AddEditViolation : Page
    {
        private Violation _currentViolation = new Violation();
        public AddEditViolation(Violation selectedViolation)
        {
            InitializeComponent();
            if (selectedViolation != null)
                _currentViolation = selectedViolation;

            DataContext = _currentViolation;
        }

        private void Btn_SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentViolation.id == 0)
                {
                    TrafficPoliceEntities.GetContext().Violation.Add(_currentViolation);
                }

                TrafficPoliceEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } // Сохранить 
    }
}
