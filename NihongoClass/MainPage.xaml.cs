using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NihongoClass.Resources;

namespace NihongoClass
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<CardsResource> Decks
        {
            get
            {
                return new List<CardsResource>
                {
                    new KanjiCards(),
                    new VerbsCards(),
                    new FormalVerbsCards(),
                    new KeiyoushiCards()
                };
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = Decks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context.Deck = (sender as FrameworkElement).DataContext as CardsResource;
            NavigationService.Navigate(new Uri("/CardsPage.xaml", UriKind.Relative));
        }

    }
}