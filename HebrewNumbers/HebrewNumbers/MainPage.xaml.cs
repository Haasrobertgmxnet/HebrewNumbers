using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Newtonsoft.Json;

using HebrewNumbers.Controls;

namespace HebrewNumbers
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int numberAlreadyAskedItems = 0;

        int[] intArray = new int[2] { 0,1 };
        readonly Dictionary<int, VocabularyItem> Vocabulary = new Dictionary<int, VocabularyItem>();

        string labelTextColor;

        int indexCurrentHebrewText;
        int indexAlternativeHebrewText;
        int rnd2 = 0;

        string labelText;
        string button1Text;
        string button2Text;

        Random rand;

        public MainPage()
        {
            InitializeComponent();
            IFileStorage service = DependencyService.Get<IFileStorage>();
            var jsonContent = service.ReadAsString("VocabularyItems.json");
            Vocabulary = JsonConvert.DeserializeObject<Dictionary<int, VocabularyItem>>(jsonContent);

            Label adLabel = new Label() { Text = "Anzeige" };
            (Content as StackLayout).Children.Add(adLabel);

            AdmobControl admobControl = new AdmobControl()
            {
                AdUnitId = AppConstants.BannerId
            };
            (Content as StackLayout).Children.Add(admobControl);

            BindingContext = this;

            nextItems();
        }

        public void nextItems()
        {
            rand = new Random((int)DateTime.Now.Ticks);
            if(Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime == true)
            {
                indexCurrentHebrewText = rand.Next(0, Vocabulary.Count);
            }
            
            do
            {
                indexAlternativeHebrewText = rand.Next(0, Vocabulary.Count);
            }
            while (indexAlternativeHebrewText == indexCurrentHebrewText);

            intArray[1] = indexAlternativeHebrewText;
            intArray[0] = indexCurrentHebrewText;

            int rnd1 = rand.Next(0, 2);
            if (Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime == true)
            {
                rnd2 = rand.Next(0, 2);
            }

            if (rnd1 == 0)
            {
                intArray[0] = indexAlternativeHebrewText;
                intArray[1] = indexCurrentHebrewText;
            }

            LabelText = Vocabulary[indexCurrentHebrewText].Hebrew;
            Button1Text = intArray[0].ToString();
            Button2Text = intArray[1].ToString();
            if (rnd2 == 0)
            {
                LabelText = indexCurrentHebrewText.ToString();
                Button1Text = Vocabulary[intArray[0]].Hebrew;
                Button2Text = Vocabulary[intArray[1]].Hebrew;
            }
        }

        public string LabelTextColor
        {
            get { return labelTextColor; }
            set
            {
                // OnPropertyChanged should not be called if the property value
                // does not change.
                if (labelTextColor == value)
                    return;
                labelTextColor = value;
                OnPropertyChanged(nameof(LabelTextColor)); // Notify that there was a change on this property
            }
        }
        public string LabelText
        {
            get { return labelText; }
            set
            {
                // OnPropertyChanged should not be called if the property value
                // does not change.
                if (labelText == value)
                    return;
                labelText = value;
                OnPropertyChanged(nameof(LabelText)); // Notify that there was a change on this property
            }
        }

        public string Button1Text
        {
            get { return button1Text; }
            set
            {
                // OnPropertyChanged should not be called if the property value
                // does not change.
                if (button1Text == value)
                    return;
                button1Text = value;
                OnPropertyChanged(nameof(Button1Text)); // Notify that there was a change on this property
            }
        }

        public string Button2Text
        {
            get { return button2Text; }
            set
            {
                // OnPropertyChanged should not be called if the property value
                // does not change.
                if (button2Text == value)
                    return;
                button2Text = value;
                OnPropertyChanged(nameof(Button2Text)); // Notify that there was a change on this property
            }
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Vocabulary[indexCurrentHebrewText].AlreadyAsked = true;

            if(intArray[0] == indexCurrentHebrewText)
            {
                Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime = true;
                LabelTextColor = "black";
            }
            else
            {
                Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime = false;
                LabelTextColor = "red";
            }

            nextItems();

            numberAlreadyAskedItems = (numberAlreadyAskedItems + 1) % Vocabulary.Count;

            if (numberAlreadyAskedItems == 0)
            {
                foreach(var item in Vocabulary.Values)
                {
                    item.AlreadyAsked = false;
                }
            }
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            Vocabulary[indexCurrentHebrewText].AlreadyAsked = true;

            if (intArray[1] == indexCurrentHebrewText)
            {
                Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime = true;
                LabelTextColor = "black";
            }
            else
            {
                Vocabulary[indexCurrentHebrewText].CorrectAtFirstTime = false;
                LabelTextColor = "red";
            }

            nextItems();

            numberAlreadyAskedItems = (numberAlreadyAskedItems + 1) % Vocabulary.Count;

            if (numberAlreadyAskedItems == 0)
            {
                foreach (var item in Vocabulary.Values)
                {
                    item.AlreadyAsked = false;
                }
            }
        }
    }
}
