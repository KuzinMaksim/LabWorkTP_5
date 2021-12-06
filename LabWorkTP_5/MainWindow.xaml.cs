using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LabWorkTP_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("в");
            comboBox.Items.Add("над");
            comboBox.Items.Add("под");
            comboBox.Items.Add("к");
            listBox.Items.Add("быстро");
            listBox.Items.Add("медленно");
            listBox.Items.Add("высоко");
            listBox.Items.Add("глубоко");
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = sender as ComboBox;
            label.Content +=" "+ box.SelectedItem.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stackPanel.Children.OfType<RadioButton>())
                if ((bool)item.IsChecked)
                    label.Content += " " + item.Content.ToString();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = sender as ListBox;
            label.Content += " " + box.SelectedItem.ToString();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add(textBox.Text);
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Remove(textBox.Text);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Remove(textBox.Text);
            listBox.Items.Add(editTextBox.Text);
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex (@"[А-яа-я]");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            editButton.IsEnabled = true;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            editTextBox.Opacity = 1;
        }
    }
}
