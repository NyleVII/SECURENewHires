using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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

namespace New_Hires_Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Counter counter = new Counter();
        private EmailBuilder emailBuilder = new EmailBuilder();
        public MainWindow()
        {
            InitializeComponent();
            this.Button_Run.Click += Button_Run_Click; //Associates clicking the button named Button_Run with the method Button_Run_Click

            //Prints config values to debug window
            Debug.WriteLine(string.Format("'{0}' test", ConfigurationManager.AppSettings["test"]));
            Debug.WriteLine("POP_Server: " + ConfigurationManager.AppSettings["POP_Server"]);
            Debug.WriteLine("POP_Port: " + ConfigurationManager.AppSettings["POP_Port"]);
            Debug.WriteLine("POP_Encryption: " + ConfigurationManager.AppSettings["POP_Encryption"]);
            Debug.WriteLine("IMAP_Server: " + ConfigurationManager.AppSettings["IMAP_Server"]);
            Debug.WriteLine("IMAP_Port: " + ConfigurationManager.AppSettings["IMAP_Port"]);
            Debug.WriteLine("IMAP_Encryption: " + ConfigurationManager.AppSettings["IMAP_Encryption"]);
            Debug.WriteLine("SMTP_Server: " + ConfigurationManager.AppSettings["SMTP_Server"]);
            Debug.WriteLine("SMTP_Port: " + ConfigurationManager.AppSettings["SMTP_Port"]);
            Debug.WriteLine("SMTP_Encryption: " + ConfigurationManager.AppSettings["SMTP_Encryption"]);
            Debug.WriteLine("Test Address: " + ConfigurationManager.AppSettings["TestAddress"]);
            Debug.WriteLine(Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]) * 2); //Converts value from string to Int for testing
        }

        

        #region Auto-Generated
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion

        #region Methods
        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {
            this.counter.incrementCount();
            UpdateCounterVisual();
            Debug.WriteLine("Calling Email Builder");
            EmailBuilder.createMessage();
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            this.counter.incrementCount();
            UpdateCounterVisual();
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.counter.decrementCount();
            UpdateCounterVisual();
        }
        private void Button_Run_Click()
        {
            //this.counter.incrementCount();
            //UpdateCounterVisual();
            //subjectTextLabel.Content = emailBuilder.certifyEmailSubject(firstNameTextBox.Text, lastNameTextBox.Text);
            //this.bodyTextLabel.Content = emailBuilder.certifyEmailBody(firstNameTextBox.Text, lastNameTextBox.Text);
            //Debug.WriteLine("Calling Email Builder");
            //EmailBuilder.createMessage();
            
        }

        private void UpdateCounterVisual()
        {
            this.countLabel.Content = this.counter.Count.ToString() + "/3";
            //Test code below
            bodyTextLabel.Content = emailBuilder.certifyEmailBody(firstNameTextBox.Text, lastNameTextBox.Text);
            subjectTextLabel.Content = emailBuilder.certifyEmailSubject(firstNameTextBox.Text, lastNameTextBox.Text);
        }
        #endregion
       

    }
}
