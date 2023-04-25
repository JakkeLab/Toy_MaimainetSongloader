using MaimaiNetCrawler.Objects;

namespace MaimaiNetCrawler
{
    public partial class Form1 : Form
    {
        Commands.Functions function = new Commands.Functions();
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            List<Song> songs = function.songLoader(tbURL.Text);

            foreach (Song song in songs)
            {
                string[] songStrSet = new string[14]
                {
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
                };

                ListViewItem lvi = new ListViewItem(songStrSet);
                ListViewSongs.Items.Add(lvi);
            }
        }
    }
}