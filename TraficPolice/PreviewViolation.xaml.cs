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
    /// Логика взаимодействия для PreviewViolation.xaml
    /// </summary>
    public partial class PreviewViolation : Page
    {
        private Violation _currentViolation = new Violation();
        public PreviewViolation(Violation selectedViolation)
        {
            InitializeComponent();
            if (selectedViolation != null)
                _currentViolation = selectedViolation;

            DataContext = _currentViolation;
        }
    }
}
