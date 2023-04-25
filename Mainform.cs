using MaimaiNetCrawler.Commands;
using MaimaiNetCrawler.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MaimaiNetCrawler
{
    public partial class Form1 : Form
    {
        
        Commands.Functions function = new Commands.Functions();
        

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            ChromeDriver driver = function.StartChromeDriver();
            //Disable button while loading songs.
            btStart.Enabled = false;
            Dictionary<string, string> maimaiSongPages = new Dictionary<string, string>
            {
                { "POPS & ANIME" , "https://maimai.sega.com/song/pops_anime/"},
                { "niconico & Vocaloid" , "https://maimai.sega.com/song/niconico/"},
                { "Toho project","https://maimai.sega.com/song/toho/" },
                { "Game & Variety", "https://maimai.sega.com/song/variety/"},
                { "maimai", "https://maimai.sega.com/song/maimai/" },
                { "ONGEKI & CHUNITHM", "https://maimai.sega.com/song/gekichu/"}
            };

            foreach(var page in maimaiSongPages)
            {
                await Task.Delay(5000);
                lbStatus.Text = "Loading songs of " + page.Key + "...";
                await LoadSongsAsync(page.Value, driver);
                lbStatus.Text = "Loading songs of " + page.Key + " done";
                await Task.Delay(5000);
            }

            MessageBox.Show("Loading songs done!");
            driver.Quit();
            btStart.Enabled = true;
            pgBar.Value = 0;
        }

        private async Task LoadSongsAsync(string url, ChromeDriver driver)
        {

            IList<IWebElement> songItems = function.GetSongBox(url, driver);
            Song song = new Song();
            pgBar.Maximum = songItems.Count;
            pgBar.Value = 0;

            foreach (IWebElement songItem in songItems)
            {
                song = function.GetSong(songItem);
                string[] songStrSet = new string[16]
                {
                    song.Genre,
                    song.Name,
                    song.Artist,
                    song.Tabtype.Standard != null ? "Standard" : null,
                    song.Tabtype.Standard?.Difficulty?.Basic,
                    song.Tabtype.Standard?.Difficulty?.Normal,
                    song.Tabtype.Standard?.Difficulty?.Expert,
                    song.Tabtype.Standard?.Difficulty?.Master,
                    song.Tabtype.Standard?.Difficulty?.ReMaster,
                    song.Tabtype.Deluxe != null ? "Deluxe" : null,
                    song.Tabtype.Deluxe?.Difficulty?.Basic,
                    song.Tabtype.Deluxe?.Difficulty?.Normal,
                    song.Tabtype.Deluxe?.Difficulty?.Expert,
                    song.Tabtype.Deluxe?.Difficulty?.Master,
                    song.Tabtype.Deluxe?.Difficulty?.ReMaster,
                    song.Lock == true ? "Lock" : "Unlock"
                };
                

                ListViewItem lvi = new ListViewItem(songStrSet);
                SetRowColor(lvi);
                ListViewSongs.Items.Add(lvi);

                pgBar.Value++;
                await Task.Delay(10); // Add a small delay to allow UI updates, you can adjust the value as needed.
            }

        }

        private void SetRowColor(ListViewItem lvi)
        {
            if(lvi.SubItems[0].Text == "POPS & ANIME")
            {
                //#ff972a Color
                Color colorBack = Color.FromArgb(255, 151, 42);
                lvi.BackColor = colorBack;
            }
            else if(lvi.SubItems[0].Text == "niconico & Vocaloid")
            {
                //##02c8d3 Color
                Color colorBack = Color.FromArgb(2, 200, 211);
                lvi.BackColor = colorBack;
                Color colorText = Color.White;
                lvi.ForeColor = colorText;
            }
            else if(lvi.SubItems[0].Text == "Toho project")
            {
                //#ad59ee Color
                Color colorBack = Color.FromArgb(173, 89, 238);
                lvi.BackColor = colorBack;
                Color colorText = Color.White;
                lvi.ForeColor = colorText;
            }
            else if(lvi.SubItems[0].Text == "Game & Variety")
            {
                //#4be070 Color
                Color colorBack = Color.FromArgb(75, 224, 112);
                lvi.BackColor = colorBack;
            }
            else if(lvi.SubItems[0].Text == "maimai")
            {
                //#f64849 Color
                Color colorBack = Color.FromArgb(246, 72, 73);
                lvi.BackColor = colorBack;
                Color colorText = Color.White;
                lvi.ForeColor = colorText;
            }
            else if(lvi.SubItems[0].Text == "ONGEKI & CHUNITHM")
            {
                //#3584fe Color
                Color colorBack = Color.FromArgb(53, 132, 254);
                lvi.BackColor = colorBack;
                Color colorText = Color.White;
                lvi.ForeColor = colorText;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Delete all songs?", "Delete All", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                ListViewSongs.Items.Clear();
            }
        }

        private void btnDropDuplicated_Click(object sender, EventArgs e)
        {
            HashSet<string[]> uniqueItems = new HashSet<string[]>();

            var itemCollection = ListViewSongs.Items;
            foreach(ListViewItem item in itemCollection)
            {
                string[] strArray = new string[2]
                {
                    item.SubItems[1].Text,
                    item.SubItems[2].Text
                };
            }
        }
    }
}