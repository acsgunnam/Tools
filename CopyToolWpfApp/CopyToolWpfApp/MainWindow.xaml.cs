using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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

namespace CopyToolWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            txtSource.Text = CopyToolSettings.Default.SourcePath;
            txtDestination.Text = CopyToolSettings.Default.DestinationPath;
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            CopyToolSettings.Default.SourcePath = txtSource.Text;
            CopyToolSettings.Default.DestinationPath = txtDestination.Text;

            CopyToolSettings.Default.Save();

            var sourcePath = txtSource.Text;
            var destinationPath = txtDestination.Text;

            CopyUtil copyUtil = new CopyUtil(sourcePath, destinationPath);

            copyUtil.CopyModifiedFiles();
        }
    }
}
