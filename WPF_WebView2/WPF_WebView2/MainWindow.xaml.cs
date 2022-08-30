using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace WebView2_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Url { get; set; }
        public string SendString { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            webView.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
            webView.CoreWebView2.ContentLoading += CoreWebView2_ContentLoading;
            webView.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
            webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            webView.CoreWebView2.AddHostObjectToScript("bridge", new Bridge());

            await webView.CoreWebView2.ExecuteScriptAsync("test()");
        }

        private void CoreWebView2_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_ContentLoading(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_HistoryChanged(object sender, object e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_DOMContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DOMContentLoadedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            Console.WriteLine("CoreWebView2_WebMessageReceived: " + e.Source);
        }

        private void Button_Navigate(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.Navigate(Url);

            //webView.Source = new Uri(Url);
        }

        private async void Button_SendData(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.PostWebMessageAsString(SendString);
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class Bridge
    {
        public string Func(string param)
        {
            return JsonConvert.SerializeObject(new
            {
                result = param + " ended",
                success = true
            });
        }
    }
}
