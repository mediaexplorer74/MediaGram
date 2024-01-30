using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using TeleSharp.TL;
using TLSharp.Core;
using TLSharp.Core.Exceptions;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

#nullable disable
namespace MediaGram
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private string NumberToSendMessage;
        private string hash;
        private TelegramClient client;


        public LoginPage()
        {
            this.InitializeComponent();

            string BasePath = ApplicationData.Current.LocalFolder.Path;

            DirectoryInfo basePath = new DirectoryInfo(BasePath);

            FileSessionStore session = new FileSessionStore(basePath);

            this.client = NewClient(session);

            this.client.ConnectAsync();

            session = (FileSessionStore)null;

            string CountriesPath = ApplicationData.Current.LocalFolder.Path + "\\" +
                "countries.json";

            this.countriesCodesList.ItemsSource = (IEnumerable)this.LoadJson(CountriesPath);

        }//LoginPage




        public static TelegramClient NewClient(FileSessionStore session)
        {
            try
            {
                 return new TelegramClient(
                    Constants.ApiId,
                    Constants.ApiHash,
                    (ISessionStore)session);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Please add your API settings to the `Constants.cs` file. " +
                    "(More info: https://github.com/sochix/TLSharp#quick-configuration)", ex);
            }
            return default;
        }

        private async void btn_setPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txt_phone_number.Text))
                    return;

                this.NumberToSendMessage =
                    this.countriesCodesList.SelectedValue.ToString() + this.txt_phone_number.Text;
                string str = await this.client.SendCodeRequestAsync(this.NumberToSendMessage);
                this.hash = str;
                str = (string)null;

                this.phone_dialog.Visibility = Visibility.Collapsed;
                this.code_dialog.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] btn_setPhoneNumber_Click error: " + ex.ToString());
            }
        }

        private async void btn_setReceivedCode_Click(object sender, RoutedEventArgs e)
        {
            string code = this.txt_received_code.Text;
            if (string.IsNullOrWhiteSpace(code))
            {
                code = (string)null;
            }
            else
            {
                try
                {
                    TLUser tlUser = await this.client.MakeAuthAsync(
                        this.NumberToSendMessage, this.hash, code);
                    
                    //MainPage mainWindow = new MainPage();
                    
                    //mainWindow.Show();
                    //this.Close();
                    //mainWindow = (MainPage)null;
                    code = (string)null;

                    Frame.Navigate(typeof(MainPage));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[ex] btn_setReceivedCode_Click error: " + ex.Message);
                    code = (string)null;
                }
            }
        }

        public List<LoginPage.Country> LoadJson(string jsonAdress)
        {
            using (StreamReader streamReader = new StreamReader(jsonAdress))
            {
                return JsonConvert.DeserializeObject<List<LoginPage.Country>>(streamReader.ReadToEnd());
            }
            /*List<LoginPage.Country> TestList = default;
            Country item = new Country() 
            {
                Name = "Russia",
                Dial_code = "+7",
                Code = "Rus"
            }; 

            TestList.Add(item);
            return TestList;*/
        }


        public class Country
        {
            public string Name { get; set; }

            public string Dial_code { get; set; }

            public string Code { get; set; }

            public string Flag { get; set; }

            public string NameAndCode
            {
                get
                {
                    return this.Name + " " + this.Dial_code;
                }
            }
        }
      }
    }//namespace end

 
