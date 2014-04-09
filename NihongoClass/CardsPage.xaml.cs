using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace NihongoClass
{
    public partial class CardsPage : PhoneApplicationPage
    {

        public List<String> Cards { get; set; }
        public int Index { get; set; }

        public CardsPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Cards = Context.Deck.Shuffle();
            Index = -1;

            NextCard();
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            NextCard();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            PreviousCard();
        }

        public void NextCard()
        {
            if (Cards.Count > (Index + 1))
            {
                tbCard.Text = Cards[++Index];
                Count();
            }
            else
            {
                NavigationService.GoBack();
            }
        }

        public void PreviousCard()
        {
            if (Index > 0)
            {
                tbCard.Text = Cards[--Index];
                Count();
            }
            else
            {
                NavigationService.GoBack();
            }
        }

        public void Count()
        {
            tbCount.Text = ((Cards.Count - Index - 1) / 2).ToString();
        }

    }
}