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

namespace stay.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogStay.xaml
    /// </summary>
    public partial class CatalogStay : Page
    {
        int _itemcount = 0;
        public CatalogStay()
        {
            InitializeComponent();

            ListoxViewStay.ItemsSource = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
            var directions = stayEntities.GetContext().directions.OrderBy(p => p.name_directions).ToList();
            directions.Insert(0, new direction
            {
                name_directions = "Все названия "
            }
            );

            Cmbnapravlenie.ItemsSource = directions;
            Cmbnapravlenie.SelectedIndex = 0;
            //вывод данных из БД в ListBox
            ListoxViewStay.ItemsSource = stayEntities.GetContext().directions.OrderBy(p => p.name_directions).ToList();
            _itemcount = ListoxViewStay.Items.Count;


            //stayEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            //List<specialization> specializations = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
            //ListoxViewStay.ItemsSource = specializations;
        }

        private void TBoxSerach_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Cmbnapravlenie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var currentspecialization = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
            if (Cmbnapravlenie.SelectedIndex > 0)
                //выбор только тех товаров, которые принадлежат данному поставщику
                currentspecialization = currentspecialization.Where(p => p.id_directions ==
                (Cmbnapravlenie.SelectedItem as direction).id_directions).ToList();
            // выбор тех товаров, в названии которых есть поисковая строка
            currentspecialization = currentspecialization.Where(p =>
            p.name_specialization.ToLower().Contains(TBoxSerach.Text.ToLower())).ToList();
            // сортировка
            if (CmbSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (CmbSort.SelectedIndex == 0)
                    currentspecialization = currentspecialization.OrderBy(p => p.price).ToList();
                // сортировка по убыванию цены
                if (CmbSort.SelectedIndex == 1)
                    currentspecialization = currentspecialization.OrderByDescending(p => p.price).ToList();
            }
            // В качестве источника данных присваиваем список данных
            ListoxViewStay.ItemsSource = currentspecialization;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                stayEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ListoxViewStay.ItemsSource = stayEntities.GetContext().specializations.OrderBy(p => p.name_specialization).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddStayPage1());
        }
    }
}
