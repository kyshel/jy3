using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.Text;  // for class Encoding
using System.IO;    // for StreamReader

namespace jy3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            t1.Text = "http://192.168.200.195/api/getconf.json?mid=4279e31b57df41f882062b1c5fff5ed7";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            


            var request = (HttpWebRequest)WebRequest.Create(t1.Text);

            var postData = "[]";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            t2.Text = responseString;
        }
    }
}
