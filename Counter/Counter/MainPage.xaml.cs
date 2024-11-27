using System;
using Microsoft.Maui.Controls;

namespace Counter
{
    public partial class MainPage : ContentPage
    {
        // Unikalne nazwy
        private int _counterId = 1; 

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddCounterClicked(object sender, EventArgs e)
        {
            // Unikalny identyfikator licznika
            string counterId = $"Licznik {_counterId:D3}";
            _counterId++;

            var counterFrame = new Frame
            {
                //Style licznika
                CornerRadius = 15, 
                BackgroundColor = Colors.Gray, 
                Padding = 10,
                Margin = new Thickness(0, 10),
            };

            var counterLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 5
            };

            // Nazwa licznika 
            var counterLabel = new Label
            {
                Text = counterId,
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold
            };

            // Wyświetlania aktualnej wartości
            var valueLabel = new Label
            {
                Text = "0",
                FontSize = 40, 
                HorizontalOptions = LayoutOptions.Center
            };

            var incrementButton = new Button
            {
                Text = "+",
                BackgroundColor = Colors.ForestGreen, 
                TextColor = Colors.White,
                FontSize = 32, 
                CornerRadius = 15,
                HeightRequest = 80,
                WidthRequest = 80,
                HorizontalOptions = LayoutOptions.Center
            };

            var decrementButton = new Button
            {
                Text = "-",
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                FontSize = 32, 
                CornerRadius = 15,
                HeightRequest = 80,
                WidthRequest = 80,
                HorizontalOptions = LayoutOptions.Center
            };

            // Obsługa zdarzeń przycisków
            incrementButton.Clicked += (s, args) =>
            {
                int currentValue = int.Parse(valueLabel.Text);
                valueLabel.Text = (currentValue + 1).ToString();
            };

            decrementButton.Clicked += (s, args) =>
            {
                int currentValue = int.Parse(valueLabel.Text);
                valueLabel.Text = (currentValue - 1).ToString();
            };

            var buttonsLayout = new HorizontalStackLayout
            {
                Spacing = 15,
                HorizontalOptions = LayoutOptions.Center,
                Children = { decrementButton, incrementButton }
            };

            counterLayout.Children.Add(counterLabel);
            counterLayout.Children.Add(valueLabel);
            counterLayout.Children.Add(buttonsLayout);

            counterFrame.Content = counterLayout;

            CountersContainer.Children.Add(counterFrame);
        }
    }
}
