using GosU.Modules;
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

namespace GosU.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientCatalogPage.xaml
    /// </summary>
    public partial class ClientCatalogPage : Page
    {
        int pageNum = 1;
        public ClientCatalogPage()
        {
            InitializeComponent();
            ClientLb.ItemsSource = SocialSupportEntities.GetContext().PersonalDatas.ToList();
            List<PersonalData> personalDatas = SocialSupportEntities.GetContext().PersonalDatas.ToList();
            personalDatas.Insert(0, new PersonalData
            {
                Street = "Все"
            });
            FiltCb.ItemsSource = personalDatas;
            FiltCb.DisplayMemberPath = "Street";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<PersonalData> clients = SocialSupportEntities.GetContext().PersonalDatas.OrderBy(p => p.Name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                clients = clients.Where(p => p.PersonalID == (FiltCb.SelectedItem as PersonalData).PersonalID).ToList();
            }
            clients = clients.Where(p => p.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    clients = clients.OrderBy(p => p.Age).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    clients = clients.OrderByDescending(p => p.Age).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<PersonalData> pagePersonal = new List<PersonalData>();
                currentPage = currentPage <= 0 || currentPage > clients.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 5;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < clients.Count)
                    {
                        pagePersonal.Add(clients[i]);
                    }
                }
                ClientLb.ItemsSource = pagePersonal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void prevPage_Click(object sender, RoutedEventArgs e)
        {
            List<PersonalData> personalDatas = SocialSupportEntities.GetContext().PersonalDatas.OrderBy(p => p.Name).ToList();
            if (pageNum > 2)
            {
                pageNum -= 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;

            }
        }

        private void firstPage_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = pageNum.ToString();
            Update();
        }

        private void secondPage_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum + 1).ToString();
            Update();
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            List<PersonalData> personalDatas = SocialSupportEntities.GetContext().PersonalDatas.OrderBy(p => p.Name).ToList();
            if (pageNum < personalDatas.Count / 5)
            {
                pageNum += 2;
                firstPage.Content = pageNum;
                secondPage.Content = pageNum + 1;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SocialSupportEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ClientLb.ItemsSource = SocialSupportEntities.GetContext().PersonalDatas.OrderBy(p => p.Name).ToList();
            }
        }
    }
}
