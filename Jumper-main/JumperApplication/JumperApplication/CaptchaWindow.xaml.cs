using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace JumperApplication
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        string _correctCaptcha { get; set; }
        public bool _isCorrect { get; set; } = false;
        public CaptchaWindow()
        {
            InitializeComponent();

          
            _correctCaptcha = Captcha.CreateCaptcha();

            CaptchaImage.Source = new BitmapImage(new Uri($@"{Directory.GetCurrentDirectory()}\Images\{_correctCaptcha}.png"));
        }

        private void CheckCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (_correctCaptcha != CaptchaTb.Text)
            {
                MessageBox.Show("Каптча введена не верно");
                this.Close();
            }

            _isCorrect = true;
            if (_correctCaptcha == CaptchaTb.Text)
            {
                JumperWindow jumperWindow = new JumperWindow();
                jumperWindow.Show();
                this.Close();
            }
        }
    }
}
