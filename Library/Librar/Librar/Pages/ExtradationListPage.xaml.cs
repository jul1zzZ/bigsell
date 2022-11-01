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
    /// Логика взаимодействия для ExtradationListPage.xaml
    /// </summary>
    public partial class ExtradationListPage : Page
    {
        List<Book> Books { get; set; }
        public ExtradationListPage(Book book)
        {
            InitializeComponent();
            ExtData.ItemsSource = LibrEntities.GetContext().Extradations.Where(o => o.BookID == book.BookID).OrderBy(o => o.DateExt).ToList();
        }
    }
}
