using Librar.Modules;
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

namespace Librar.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookCatalogPage.xaml
    /// </summary>
    public partial class BookCatalogPage : Page
    {
        int pageNum = 1;
        public BookCatalogPage()
        {
            InitializeComponent();
            BookLb.ItemsSource = LibrEntities.GetContext().Books.ToList();
            List<Author> authors = LibrEntities.GetContext().Authors.ToList();
            authors.Insert(0, new Author
            {
                Surname = "Все"
            }) ;
            FiltCb.ItemsSource = authors;
            FiltCb.DisplayMemberPath = "Surname";
            FiltCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Book> books = LibrEntities.GetContext().Books.OrderBy(p => p.Name).ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                books = books.Where(p => p.AuthorID == (FiltCb.SelectedItem as Author).AuthorID).ToList();
            }
            books = books.Where(p => p.Name.ToLower().Contains(SearchTb.Text.ToLower())).ToList();

            if (SortCb.SelectedIndex >= 0)
            {
                if (SortCb.SelectedIndex == 0)
                {
                    books = books.OrderBy(p => p.PubDate).ToList();
                }
                if (SortCb.SelectedIndex == 1)
                {
                    books = books.OrderByDescending(p => p.PubDate).ToList();
                }
            }

            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<Book> pageBook = new List<Book>();
                currentPage = currentPage <= 0 || currentPage > books.Count || !canParse ? 1 : currentPage;
                int itemsPerPage = 10;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < books.Count)
                    {
                        pageBook.Add(books[i]);
                    }
                }
                BookLb.ItemsSource = pageBook;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void ExtBtn_Click(object sender, RoutedEventArgs e)
        {
            Book book = (Book)(sender as Button).DataContext;
            NavigationService.Navigate(new Pages.ExtradationListPage(book));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Book book = (Book)(sender as Button).DataContext;
            NavigationService.Navigate(new Pages.BookInfoPage(book));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookLb.SelectedItems.Cast<Book>().ToList();

            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedBook.Count()} записей???",
            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Book x = selectedBook[0];

                    LibrEntities.GetContext().Books.Remove(x);

                    LibrEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Book> books = LibrEntities.GetContext().Books.OrderBy(p => p.Name).ToList();
                    BookLb.ItemsSource = null;
                    BookLb.ItemsSource = books;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void prevPage_Click(object sender, RoutedEventArgs e)
        {
            List<Book> books = LibrEntities.GetContext().Books.OrderBy(p => p.Name).ToList();
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
            List<Book> books = LibrEntities.GetContext().Books.OrderBy(p => p.Name).ToList();
            if (pageNum < books.Count / 10)
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
                LibrEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                BookLb.ItemsSource = LibrEntities.GetContext().Books.OrderBy(p => p.Name).ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.BookInfoPage(null));
        }
    }
}
