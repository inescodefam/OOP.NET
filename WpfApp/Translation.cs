using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WpfApp
{
    public class Translation
    {
        private Dictionary<string, Dictionary<string, string>> translations;
        private const string PATH = "translation.json";

        public static string CurrentLanguage { get; set; } = "hr";


        public Translation()
        {
            try
            {
                LoadTranslations(PATH);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Greška prilikom učitavanja prijevoda!", "Greška", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
        }

        private void LoadTranslations(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonTranslations = File.ReadAllText(filePath);
                translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonTranslations);
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Datoteka s prijevodima nije pronađena!", "Greška", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                translations = new Dictionary<string, Dictionary<string, string>>();
            }
        }

        public void ApplyTranslationsToWpf(Window window)
        {
            if (translations == null || !translations.ContainsKey(CurrentLanguage))
                return;

            var currentTranslations = translations[CurrentLanguage];

            if (!string.IsNullOrEmpty(window.Name) && currentTranslations.ContainsKey(window.Name))
                window.Title = currentTranslations[window.Name];

            ApplyTranslationsToWpfControls(window.Content, currentTranslations);
        }

        private void ApplyTranslationsToWpfControls(object content, Dictionary<string, string> currentTranslations)
        {

            if (content is System.Windows.Controls.Panel panel)
            {
                foreach (var child in panel.Children)
                    ApplyTranslationsToWpfControls(child, currentTranslations);
            }
            else if (content is ContentControl contentControl)
            {
                if (!string.IsNullOrEmpty(contentControl.Name) && currentTranslations.ContainsKey(contentControl.Name))
                    contentControl.Content = currentTranslations[contentControl.Name];
            }
            else if (content is TextBlock textBlock)
            {
                if (!string.IsNullOrEmpty(textBlock.Name) && currentTranslations.ContainsKey(textBlock.Name))
                    textBlock.Text = currentTranslations[textBlock.Name];
            }
        }

        internal void ChangeLanguage(string language, MainWindow mainWindow)
        {
            if (translations.ContainsKey(language))
            {
                if (CurrentLanguage != language)
                    CurrentLanguage = language;
                ApplyTranslationsToWpf(mainWindow);
            }
            else
            {
                System.Windows.MessageBox.Show("Prijevod za odabrani jezik ne postoji.", "Greška", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);
            }
        }
    }
}
