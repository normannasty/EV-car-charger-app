using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using Newtonsoft.Json;
namespace YourNamespace
{
    public partial class MainForm : Form
    {
        private HttpClient _httpClient;
        private Label leftTimeLabel;
        private Label rightTimeLabel;
        private TextBox leftResponseTextBox;
        private TextBox rightResponseTextBox;
        private bool _leftCountdownStopped = true;
        public bool LeftCountdownStopped
        {
            get { return _leftCountdownStopped; }
            set { _leftCountdownStopped = value; }
        }

        private bool _rightCountdownStopped = true;
        public bool RightCountdownStopped
        {
            get { return _rightCountdownStopped; }
            set { _rightCountdownStopped = value; }
        }

        private PictureBox[] leftIndicators;
        private PictureBox[] rightIndicators;
        private CancellationTokenSource _statusCheckTokenSource;

        public MainForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            InitializeTimeDropdowns();
            leftStartButton.Click += async (sender, e) => await StartCountdown(leftTimeDropdown, leftStopButton, leftTimeLabel, true);
            rightStartButton.Click += async (sender, e) => await StartCountdown(rightTimeDropdown, rightStopButton, rightTimeLabel, false);

            leftResponseTextBox = new TextBox();
            leftResponseTextBox.Multiline = true;
            leftResponseTextBox.ScrollBars = ScrollBars.Vertical;
            leftResponseTextBox.Location = new Point(109, 350); // Az elhelyezést az Ön igényeihez igazíthatja
            leftResponseTextBox.Size = new Size(121, 50); // Az méretet az Ön igényeihez igazíthatja
            leftResponseTextBox.ReadOnly = true;
            this.Controls.Add(leftResponseTextBox);

            rightResponseTextBox = new TextBox();
            rightResponseTextBox.Multiline = true;
            rightResponseTextBox.ScrollBars = ScrollBars.Vertical;
            rightResponseTextBox.Location = new Point(414, 350); // Az elhelyezést az Ön igényeihez igazíthatja
            rightResponseTextBox.Size = new Size(121, 50); // Az méretet az Ön igényeihez igazíthatja
            rightResponseTextBox.ReadOnly = true;
            this.Controls.Add(rightResponseTextBox);

            InitializeIndicators();
            StartStatusCheck();
        }
        private void InitializeIndicators()
        {
            leftIndicators = new PictureBox[] { leftIndicator1, leftIndicator2, leftIndicator3 };
            rightIndicators = new PictureBox[] { rightIndicator1, rightIndicator2, rightIndicator3 };
        }

        private void StartStatusCheck()
        {
            _statusCheckTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _statusCheckTokenSource.Token;
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(5000); // Check status every 5 seconds
                    await UpdateIndicators();
                }
            }, cancellationToken);
        }

        private async Task UpdateIndicators()
        {
            string leftIP = ConfigurationManager.AppSettings["LeftButtonIP"];
            string rightIP = ConfigurationManager.AppSettings["RightButtonIP"];

            await UpdateIndicator(leftIP, true);
            await UpdateIndicator(rightIP, false);
        }

        private async Task UpdateIndicator(string ip, bool isLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                string apiUrl = $"http://{ip}/rpc/Switch.GetStatus?id={i}";
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse response to check output status
                    dynamic status = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                    bool outputStatus = status.output;

                    // Update indicator color based on output status
                    if (isLeft)
                        leftIndicators[i].BackColor = outputStatus ? Color.SpringGreen : Color.Crimson;
                    else
                        rightIndicators[i].BackColor = outputStatus ? Color.SpringGreen : Color.Crimson;
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., network error)
                    MessageBox.Show($"Error occurred while updating indicators: {ex.Message}");
                }
            }
        }


        private void InitializeTimeDropdowns()
        {
            List<string> timeOptions = new List<string>
            {
                "10 másodperc",
                "30 perc",
                "1 óra",
                "1,5 óra",
                "2 óra",
                "2,5 óra",
                "3 óra"
            };

            foreach (string timeOption in timeOptions)
            {
                leftTimeDropdown.Items.Add(timeOption);
                rightTimeDropdown.Items.Add(timeOption);
            }

            leftTimeDropdown.SelectedIndex = 0;
            rightTimeDropdown.SelectedIndex = 0;

            leftTimeLabel = new Label();
            leftTimeLabel.AutoSize = true;
            leftTimeLabel.Location = new System.Drawing.Point(140, 100); // Az elhelyezést az Ön igényeihez igazíthatja
            this.Controls.Add(leftTimeLabel);

            rightTimeLabel = new Label();
            rightTimeLabel.AutoSize = true;
            rightTimeLabel.Location = new System.Drawing.Point(450, 100); // Az elhelyezést az Ön igényeihez igazíthatja
            this.Controls.Add(rightTimeLabel);
        }

        private CancellationTokenSource _cancellationTokenSource;

        private async Task StartCountdown(ComboBox timeDropdown, Button stopButton, Label timeLabel, bool isLeftTimer)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _cancellationTokenSource.Token;

            string selectedTime = timeDropdown.SelectedItem.ToString();
            int seconds = ParseTime(selectedTime);
            timeLabel.Text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");

            while (seconds > 0 && !cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                seconds--;
                timeLabel.Text = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                // Az időzítő lejárt és nem volt manuálisan megállítva
                if (isLeftTimer)
                {
                    // Megállítja a bal időzítőt és hívja a kapcsolódó API végpontokat
                    LeftCountdownStopped = true;
                    string leftIP = ConfigurationManager.AppSettings["LeftButtonIP"];
                    await PerformSequentialStopCalls(leftIP, true);
                }
                else
                {
                    // Megállítja a jobb időzítőt és hívja a kapcsolódó API végpontokat
                    RightCountdownStopped = true;
                    string rightIP = ConfigurationManager.AppSettings["RightButtonIP"];
                    await PerformSequentialStopCalls(rightIP, false);
                }
            }
        }




        private int ParseTime(string selectedTime)
        {
            switch (selectedTime)
            {
                case "10 másodperc":
                    return 10;
                case "30 perc":
                    return 30 * 60;
                case "1 óra":
                    return 60 * 60;
                case "1,5 óra":
                    return (int)(1.5 * 60 * 60);
                case "2 óra":
                    return 2 * 60 * 60;
                case "2,5 óra":
                    return (int)(2.5 * 60 * 60);
                case "3 óra":
                    return 3 * 60 * 60;
                default:
                    return 0;
            }
        }

        private async void leftStartButton_Click(object sender, EventArgs e)
        {
            string leftIP = ConfigurationManager.AppSettings["LeftButtonIP"];
            await PerformSequentialStartCalls(leftIP, true);
        }

        private async void rightStartButton_Click(object sender, EventArgs e)
        {
            string rightIP = ConfigurationManager.AppSettings["RightButtonIP"];
            await PerformSequentialStartCalls(rightIP, false);
        }

        private async Task PerformSequentialStartCalls(string ip, bool isLeftTimer)
        {
            string[] apiUrls = new string[]
            {
        $"http://{ip}/rpc/Switch.Set?id=0&on=true",
        $"http://{ip}/rpc/Switch.Set?id=1&on=true",
        $"http://{ip}/rpc/Switch.Set?id=2&on=true"
            };

            bool allWasOff = true; // Feltételezzük, hogy minden kikapcsolt állapotban volt

            foreach (var apiUrl in apiUrls)
            {
                string response = await CallApi(apiUrl);
                if (response != null && response.Contains("\"was_on\":true"))
                {
                    allWasOff = false; // Ha bármelyik válaszban "was_on": true, akkor nem minden volt kikapcsolt állapotban
                    break; // Nincs értelme tovább folytatni
                }
            }

            string message = allWasOff ? "A töltés elindult." : "Nem minden kapcsoló volt kiindulási állapotban.";
            if (isLeftTimer)
            {
                leftResponseTextBox.Text = message;
            }
            else
            {
                rightResponseTextBox.Text = message;
            }
        }

        private void leftStopButton_Click(object sender, EventArgs e)
        {
            string leftIP = ConfigurationManager.AppSettings["LeftButtonIP"];
            StopCountdown(_cancellationTokenSource);
            LeftCountdownStopped = true;
            PerformSequentialStopCalls(leftIP, true);
        }

        private void rightStopButton_Click(object sender, EventArgs e)
        {
            string rightIP = ConfigurationManager.AppSettings["RightButtonIP"];
            StopCountdown(_cancellationTokenSource);
            RightCountdownStopped = true;
            PerformSequentialStopCalls(rightIP, false);
        }

        private void StopCountdown(CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource?.Cancel();
        }



        private async Task PerformSequentialStopCalls(string ip, bool isLeftTimer)
        {
            string[] apiUrls = new string[]
            {
        $"http://{ip}/rpc/Switch.Set?id=0&on=false",
        $"http://{ip}/rpc/Switch.Set?id=1&on=false",
        $"http://{ip}/rpc/Switch.Set?id=2&on=false"
            };

            bool allWasOn = true; // Feltételezzük, hogy minden bekapcsolt állapotban volt

            foreach (var apiUrl in apiUrls)
            {
                string response = await CallApi(apiUrl);
                if (response != null && response.Contains("\"was_on\":false"))
                {
                    allWasOn = false; // Ha bármelyik válaszban "was_on": false, akkor nem minden volt bekapcsolt állapotban
                    break; // Nincs értelme tovább folytatni
                }
            }

            string message = allWasOn ? "A töltés leállt." : "Nem minden kapcsoló volt bekapcsolva a leállításkor.";
            if (isLeftTimer)
            {
                leftResponseTextBox.Text = message;
            }
            else
            {
                rightResponseTextBox.Text = message;
            }
        }




        private async Task<string> CallApi(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return null;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
