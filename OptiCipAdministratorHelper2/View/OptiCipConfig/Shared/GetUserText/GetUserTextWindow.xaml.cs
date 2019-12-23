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
using System.Windows.Shapes;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Shared.GetUserText
{
    /// <summary>
    /// Interaction logic for GetUserTextWindow.xaml
    /// </summary>
    public partial class GetUserTextWindow : Window
    {
        public string InputText { get; set; }
        public bool IsSuccess { get; private set; } = false;

        public GetUserTextWindow()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            InputText = InputTextBox.Text;

            if (!string.IsNullOrEmpty(InputText))
            {
                IsSuccess = true;
            }
            this.Close();
        }
        private void CancleClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
