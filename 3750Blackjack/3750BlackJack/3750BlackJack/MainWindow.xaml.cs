using System.Windows;

namespace _3750BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main Window Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hit Button Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Hit(object sender, RoutedEventArgs e)
        {
            ((GameMaster)DataContext).Hit();
        }

        /// <summary>
        /// Stay Button Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Stay(object sender, RoutedEventArgs e)
        {
            ((GameMaster)DataContext).Stay();
        }

        /// <summary>
        /// Begin Button Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((GameMaster)DataContext).Begin();
        }
    }
}
