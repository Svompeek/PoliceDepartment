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
    /// Логика взаимодействия для Drivers.xaml
    /// </summary>
    public partial class Drivers : Page
    {
        public Drivers()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TrafficPoliceEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
            DriversList.ItemsSource = TrafficPoliceEntities.GetContext().Driver.ToList();
        } // Обновление страницы
        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditDriver(null));
        } // Переход на страницу добавления

        private void BtnEdit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditDriver((sender as Button).DataContext as Driver));
        } // Переход на страницу добавления с данными о выделенном объекте
        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            var a = DriversList.SelectedItems.Cast<Driver>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TrafficPoliceEntities.GetContext().Driver.RemoveRange(a);
                    TrafficPoliceEntities.GetContext().SaveChanges();
                    DriversList.ItemsSource = TrafficPoliceEntities.GetContext().Driver.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        } // Удаление
    }
}
