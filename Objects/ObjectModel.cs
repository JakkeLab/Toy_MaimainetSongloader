using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaimaiNetCrawler.Objects
{
	//Song Object
    public class Song
    {
        //1. Genre
        private string _genre;

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        //2. Artist
        private string _artist;
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        //3. Song name
        private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

        //4. Tabtype
        public TabType Tabtype { get; set; }

        public class TabType
        {
            public TabStandard Standard { get; set; }
            public TabDeluxe Deluxe { get; set; }

            public class TabStandard
            {
                public Difficulty Difficulty { get; set; }

                public TabStandard()
                {
                    Difficulty = new Difficulty();
                }
            }

            public class TabDeluxe
            {
                public Difficulty Difficulty { get; set; }
                public TabDeluxe()
                {
                    Difficulty = new Difficulty();
                }
            }
        }

        private bool _lock;

        public bool Lock
        {
            get { return _lock; }
            set { _lock = value; }
        }

        public Song()
        {
            Tabtype = new TabType();
        }
    }
    //Sub items

    //Difficulty
    public class Difficulty
	{

		private string _basic;

		public string Basic
		{
			get { return _basic; }
			set { _basic = value; }
		}

        private string _normal;

        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }

        private string _expert;

        public string Expert
        {
            get { return _expert; }
            set { _expert = value; }
        }
        private string _master;

        public string Master
        {
            get { return _master; }
            set { _master = value; }
        }
        private string _remaster;

        public string ReMaster
        {
            get { return _remaster; }
            set { _remaster = value; }
        }
    }
}
