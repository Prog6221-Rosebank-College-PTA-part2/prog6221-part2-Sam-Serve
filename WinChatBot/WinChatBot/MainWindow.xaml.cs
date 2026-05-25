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
 

namespace WinChatBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
         
      
        private void addUserMessage(string message)
        {
            string text = txtMessage.Text;
            ListBoxItem item = new ListBoxItem();
            item.Content = "user: " + text;
            item.Background = Brushes.Transparent;
            item.Foreground = Brushes.GhostWhite;
            item.HorizontalAlignment = HorizontalAlignment.Left;
            listChat.Items.Add(item);
        }
        private void addBotMessage(string message)
        {
            string text = txtMessage.Text;
            ListBoxItem item = new ListBoxItem();
            item.Content = "Bot: " + reply;
            item.Background = Brushes.GhostWhite;
            item.Foreground = Brushes.YellowGreen;
            item.HorizontalAlignment = HorizontalAlignment.Right;
            listChat.Items.Add(item);
          
        }
        Dictionary<string, List<string>> chats = new Dictionary<string, List<string>>(){
    {"hello",new List<string>(){"hi","hey","hello to you too","morning"}},
    {"how are you?",new List<string>(){"i am good","i am fine","i am well"}},
    {"what can i ask about you?",new List<string>(){"You can ask me about information related to Cybersecurity Awareness example being phishing, password safety, and safe browsing practices."}},
    {"what is your purpose?",new List<string>(){"My purpose is to assist you with information related to Cybersecurity Awareness example being phishing, password safety, and safe browsing practices."}},
    {"phishing",new List<string>(){"Phishing is a type of cyber attack where attackers attempt to trick individuals into providing sensitive information such as usernames, passwords, and credit card details by pretending to be a trustworthy entity in electronic communications."}},
    {"password safety",new List<string>(){"Password safety involves creating strong, unique passwords for each account, using a combination of letters, numbers, and special characters, and regularly updating passwords to protect against unauthorized access."}},
    {"safe browsing",new List<string>(){"Safe browsing practices involve being cautious while navigating the internet, avoiding suspicious websites, not clicking on unknown links, and keeping software up to date to protect against cyber threats."}}
};
        List<string> response;
        string reply;
        Random random = new Random();

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            string text = txtMessage.Text.ToLower();
            addUserMessage(text);
            if (chats.ContainsKey(text))
            {
                response = chats[text];
                reply = response[random.Next(response.Count)];
                addBotMessage(reply);
            }

             
        }

        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            txtMessage.Clear();
        }
    }
}
