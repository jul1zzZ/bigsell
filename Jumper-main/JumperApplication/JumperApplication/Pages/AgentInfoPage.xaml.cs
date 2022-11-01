using JumperApplication.Entities;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JumperApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentInfoPage.xaml
    /// </summary>
    public partial class AgentInfoPage : Page
    {
        public Agent Agent { get; set; }

        public string _photoDirectory = $@"{Directory.GetCurrentDirectory()}\Images\";

        private string _photoPath;
        private string _photoName;
        public AgentInfoPage(Agent agent)
        {
            InitializeComponent();

            Agent = agent ?? new Agent();

            AgentTypesCb.ItemsSource = JumperEntities.GetContext().AgentTypes.ToList();

            DataContext = Agent;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Agent.AgentTypeId = (AgentTypesCb.SelectedItem as AgentType).AgentTypeId;
                if (_photoPath != null)
                {
                    Agent.Photo = _photoName;
                    File.Copy(_photoPath, _photoDirectory + _photoName);
                }
                if (Agent.AgentId == 0)
                {
                    Agent.OrderAmount = 0;
                    Agent.OrderSumm = 0;
                    JumperEntities.GetContext().Agents.Add(Agent);
                }
                JumperEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        //private string GeneratePhotoName(string photoName = "agent.png")
        //{

        //    if (!File.Exists(_photoDirectory+photoName))
        //    {
        //        return photoName;
        //    }

        //    int x = 0;
        //    while (File.Exists(_photoDirectory + photoName))
        //    {

        //        if (!File.Exists(_photoDirectory + photoName))
        //        {
        //            Guid.NewGuid
        //        }
        //        x++;
        //    }

        //    return;
        //}

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

            if (fileInfo.Length > 8 * 1024 * 1024 * 6)
            {
                MessageBox.Show("Размер фото не должен превышать 6 мб");
                return;
            }

            _photoName = Guid.NewGuid().ToString();
            _photoPath = fileInfo.FullName;
        }
    }
}
