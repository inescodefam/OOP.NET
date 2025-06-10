using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace OOP.NET_project_KamberInes
{
    public class Translation
    {

        private Dictionary<string, Dictionary<string, string>> translations;
        private string currentLanguage = "hr";
        private const string PATH = "translation.json";

        public Translation()
        {
            LoadTranslations(PATH);
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
                MessageBox.Show("Datoteka s prijevodima nije pronađena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                translations = new Dictionary<string, Dictionary<string, string>>();
            }
        }

        public void ApplyTranslations(Form form)
        {
            if (translations == null || !translations.ContainsKey(currentLanguage))
                return;

            Dictionary<string, string> currentTranslations = translations[currentLanguage];

            if (currentTranslations.ContainsKey(form.Name))
                form.Text = currentTranslations[form.Name];

            ApplyTranslationsToControls(form.Controls, currentTranslations);
        }

        private void ApplyTranslationsToControls(Control.ControlCollection controls, Dictionary<string, string> currentTranslations)
        {
            foreach (Control control in controls)
            {
                if (!string.IsNullOrEmpty(control.Name) && currentTranslations.ContainsKey(control.Name))
                {
                    control.Text = currentTranslations[control.Name];
                }

                if (control.Controls.Count > 0)
                {
                    ApplyTranslationsToControls(control.Controls, currentTranslations);
                }
            }
        }

        public void ChangeLanguage(string language, Form form)
        {
            if (translations.ContainsKey(language))
            {
                currentLanguage = language;
                ApplyTranslations(form);
            }
            else
            {
                MessageBox.Show("Prijevod za odabrani jezik ne postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
