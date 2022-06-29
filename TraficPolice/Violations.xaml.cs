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
    /// Логика взаимодействия для Violations.xaml
    /// </summary>
    public partial class Violations : Page
    {
        public Violations()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TrafficPoliceEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
            ViolationsList.ItemsSource = TrafficPoliceEntities.GetContext().Violation.ToList();
        } // Обновление таблицы при появлении страницы Нарушений
        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditViolation(null));
        } // Переход на страницу добавления
        private void Btn_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditViolation((sender as Button).DataContext as Violation));
        } // Переход на страницу добавления с данными о выделенном объекте
        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            var a = ViolationsList.SelectedItems.Cast<Violation>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {a.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TrafficPoliceEntities.GetContext().Violation.RemoveRange(a);
                    TrafficPoliceEntities.GetContext().SaveChanges();
                    ViolationsList.ItemsSource = TrafficPoliceEntities.GetContext().Violation.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        } // Удалить выделенное кол-во объектов
        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = txt_search.Text;
            if (s == "")
            {
                ViolationsList.ItemsSource = TrafficPoliceEntities.GetContext().Violation.ToList();
            }
            else
            {
                ViolationsList.ItemsSource = TrafficPoliceEntities.GetContext().Violation.Where(x=> x.ViolationTitle.StartsWith(s)).ToList();
            }
        } // Живой поиск

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Manager.MainFrame.Navigate(new PreviewViolation((sender as Grid).DataContext as Violation));
            }
        }
    }
}
