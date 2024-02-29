using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace GetechnologiesMx.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //this.WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // Check if all required fields have values
            if (string.IsNullOrWhiteSpace(UserName.Text) ||
                string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Identification.Text)) {
                MessageBox.Show("Please fill in all required fields (Name, Last Name, Identification).", "Warning");
                return;
            }

            SendUser();
        }

        private async void SendUser() {
            try {
                // Define the URL of the HTTP endpoint
                string baseUrl =  ConfigurationManager.AppSettings["GetechnologiesMxAPIUrl"] ?? "";
                string url = $"{baseUrl}/directory";

                // Prepare data to be sent
                string name = UserName.Text;
                string lastName = LastName.Text;
                string maternalSurname = MaternalSurname.Text;
                string identification = Identification.Text;

                // Create a JSON string from your data
                string json = $"{{ \"name\": \"{name}\", \"lastName\": \"{lastName}\", \"maternalSurname\": \"{maternalSurname}\", \"identification\": \"{identification}\" }}";

                // Create StringContent from the JSON string
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST request to the endpoint with the JSON content
                using HttpClient client = new();
                var response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("User created successfully!");
                    UserName.Text = "";
                    LastName.Text = "";
                    MaternalSurname.Text = "";
                    Identification.Text = "";
                }
                else {
                    // Request failed, show error message
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode} - {errorMessage}", "Error");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
    }
}
