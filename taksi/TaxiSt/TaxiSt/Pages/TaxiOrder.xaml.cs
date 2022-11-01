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
using System.Windows.Threading;
using TaxiSt.Modules;

namespace TaxiSt.Pages
{
    /// <summary>
    /// Логика взаимодействия для TaxiOrder.xaml
    /// </summary>
    public partial class TaxiOrder : Page
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        string[] driver = { "Алексей", "Ашот", "Мухамед", "Николай", "Артур", "Александр","Никита","Арсентий","Иван","Илья"};
        string[] cars = { "Лада Калина", "Рено Логан","Камри 3.5", "ВАЗ 2114","Кио Рио","Ниссан Альмера","Форд Фокус", "Лада Гранта","Лада Приора","Хондай Солярис"};
        string[] reiting = {"5", "4", "4.5", "1", "4.9" };
        public TaxiOrder()
        {
            InitializeComponent();
            List<Vodila> vodilas = TaxiEntities.GetContext().Vodilas.OrderBy(p => p.Name).ToList();
            
        }

        private void TaxiBtn_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            tbRider.Text = driver[rand.Next(driver.Length)];
            tbCar.Text = cars[rand.Next(cars.Length)];
            tbReit.Text = reiting[rand.Next(reiting.Length)];
            Random random = new Random();
            int RandomNumber = random.Next(0, 10);
            _time = TimeSpan.FromMinutes(RandomNumber);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();
        }
    }
}
