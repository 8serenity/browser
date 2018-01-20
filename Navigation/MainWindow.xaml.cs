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

//Создайте в приложении Navigation простой веб-браузер.
//Добавьте меню, которое реализует список Избранное (Favorites), и создайте контекстное меню.

namespace Navigation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> bookmarks;

        public MainWindow()
        {
            InitializeComponent();
            bookmarks = new List<string>();
            bookmarks.Add("www.google.com");
            bookmarks.Add("www.facebook.com");
            bookmarks.Add("www.sparkol.com");
            bookmarksBox.ItemsSource = bookmarks;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            browser.Source = new Uri("http://www.bing.com");
        }

        private void backPressed(object sender, RoutedEventArgs e)
        {

            try
            {
                browser.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void forwardPressed(object sender, RoutedEventArgs e)
        {

            try
            {

                browser.GoForward();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        private void chosenUrl(object sender, SelectionChangedEventArgs e)
        {
            linkUrl.Text = bookmarksBox.SelectedValue.ToString();
        }

        private void goPressed(object sender, RoutedEventArgs e)
        {
            browser.Source = new Uri("http://" + linkUrl.Text);
        }
    }
}
