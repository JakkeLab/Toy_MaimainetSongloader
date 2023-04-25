using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using MaimaiNetCrawler.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Immutable;

namespace MaimaiNetCrawler.Commands
{
    public class Functions
    {
        protected ChromeDriverService driverService = null;
        protected ChromeOptions options = null;
        protected ChromeDriver driver = null;

        //Create ChromeDriver object
        public ChromeDriver StartChromeDriver()
        {
            //Start chromedrier
            driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            options = new ChromeOptions();
            options.AddArguments("headless");
            options.AddArgument("ignore-certificate-errors");
            options.PageLoadStrategy = PageLoadStrategy.Default;

            return new ChromeDriver(driverService, options);
        }

        //Get song box IWebElement
        public IList<IWebElement> GetSongBox(string url, ChromeDriver driver)
        {
            //Start chromedrier

            driver.Navigate().GoToUrl(url);
            var songlist = driver.FindElement(By.XPath("//*[@id=\'song--list\']"));

            return songlist.FindElements(By.ClassName("song--item__box")).ToImmutableList();
        }
        public Song GetSong(IWebElement songItem)
        {
            Song song = new Song();

            //1. Check whether lock or not and genre.
            if (IsSongLock(songItem))
            {
                song.Lock = true;
                string[] topBarArr = GetTopBar(songItem).FindElement(By.TagName("p")).GetAttribute("class").Split(" ");
                song.Genre = GetGenre(topBarArr);
            }
            else
            {
                song.Lock = false;
                string[] topBarArr = GetTopBar(songItem).FindElement(By.TagName("p")).GetAttribute("class").Split(" ");
                song.Genre = GetGenre(topBarArr);
            }

            //2. Get song name
            song.Name = GetSongName(songItem);

            //3. Get artist name
            song.Artist = GetArtistName(songItem);

            //4. Get tabtype and difficulty
            IWebElement bottomBar = songItem.FindElements(By.ClassName("song--item__bottom")).FirstOrDefault();
            int tabTypeNum = GetTabType(bottomBar);
            IList<IWebElement> filteredBottombar = GetDistinctedElements(bottomBar);
            IWebElement standardTabBar = filteredBottombar.FirstOrDefault(x => x.GetAttribute("class") == "song--item__lv st");
            IWebElement deluxeTabBar = filteredBottombar.FirstOrDefault(x => x.GetAttribute("class") == "song--item__lv dx");
            song.Tabtype = new Song().Tabtype;
            if (tabTypeNum == 3)
            {
                List<string> standardDifficulty = GetDifficultyList(standardTabBar);
                song.Tabtype.Standard = new Song.TabType.TabStandard();
                song.Tabtype.Standard.Difficulty.Basic = standardDifficulty[0];
                song.Tabtype.Standard.Difficulty.Normal = standardDifficulty[1];
                song.Tabtype.Standard.Difficulty.Expert = standardDifficulty[2];
                song.Tabtype.Standard.Difficulty.Master = standardDifficulty[3];
                song.Tabtype.Standard.Difficulty.ReMaster = standardDifficulty.Count > 4 ? standardDifficulty[4] : null;

                List<string> deluxeDifficulty = GetDifficultyList(deluxeTabBar);
                song.Tabtype.Deluxe = new Song.TabType.TabDeluxe();
                song.Tabtype.Deluxe.Difficulty.Basic = deluxeDifficulty[0];
                song.Tabtype.Deluxe.Difficulty.Normal = deluxeDifficulty[1];
                song.Tabtype.Deluxe.Difficulty.Expert = deluxeDifficulty[2];
                song.Tabtype.Deluxe.Difficulty.Master = deluxeDifficulty[3];
                song.Tabtype.Deluxe.Difficulty.ReMaster = deluxeDifficulty.Count > 4 ? deluxeDifficulty[4] : null;

            }
            else if (tabTypeNum == 2)
            {
                List<string> standardDifficulty = GetDifficultyList(standardTabBar);
                song.Tabtype.Standard = new Song.TabType.TabStandard();
                song.Tabtype.Standard.Difficulty.Basic = standardDifficulty[0];
                song.Tabtype.Standard.Difficulty.Normal = standardDifficulty[1];
                song.Tabtype.Standard.Difficulty.Expert = standardDifficulty[2];
                song.Tabtype.Standard.Difficulty.Master = standardDifficulty[3];
                song.Tabtype.Standard.Difficulty.ReMaster = standardDifficulty.Count > 4 ? standardDifficulty[4] : null;

            }
            else if (tabTypeNum == 1)
            {
                List<string> deluxeDifficulty = GetDifficultyList(deluxeTabBar);
                song.Tabtype.Deluxe = new Song.TabType.TabDeluxe();
                song.Tabtype.Deluxe.Difficulty.Basic = deluxeDifficulty[0];
                song.Tabtype.Deluxe.Difficulty.Normal = deluxeDifficulty[1];
                song.Tabtype.Deluxe.Difficulty.Expert = deluxeDifficulty[2];
                song.Tabtype.Deluxe.Difficulty.Master = deluxeDifficulty[3];
                song.Tabtype.Deluxe.Difficulty.ReMaster = deluxeDifficulty.Count > 4 ? deluxeDifficulty[4] : null;
            }

            return song;
        }

        #region Methods for crawling
        //Check whether the song is lock or not
        public bool IsSongLock(IWebElement webElement)
        { 

            if(webElement.FindElements(By.ClassName("song--item__top")) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IWebElement GetTopBar(IWebElement webElement)
        {
            if(IsSongLock(webElement))
            {
                return webElement.FindElements(By.ClassName("song--item__top lock")).FirstOrDefault();
            }
            else
            {
                return webElement.FindElements(By.ClassName("song--item__top")).FirstOrDefault();
            }
        }

        //Check genre
        public string GetGenre(string[] classNameSplitted)
        {
            if (classNameSplitted.Contains("pops_anime"))
            {
                return "POPS & ANIME";
            }
            else if(classNameSplitted.Contains("niconico"))
            {
                return "niconico & Vocaloid";
            }
            else if(classNameSplitted.Contains("toho"))
            {
                return "Toho project";
            }
            else if (classNameSplitted.Contains("variety"))
            {
                return "Game & Variety";
            }
            else if(classNameSplitted.Contains("maimai"))
            {
                return "maimai";
            }
            else if (classNameSplitted.Contains("gekichu"))
            {
                return "ONGEKI & CHUNITHM";
            }
            else
            {
                return "Not defined";
            }
        }

        public string GetSongName(IWebElement webElement)
        {
            IWebElement songElement = webElement.FindElement(By.ClassName("song--item__tit"));
            return songElement.Text;
        }

        public string GetArtistName(IWebElement webElement)
        {
            IWebElement songElement = webElement.FindElement(By.ClassName("song--item__artistName"));
            return songElement.Text;
        }

        public int GetTabType(IWebElement webElement)
        {
            IList<IWebElement> bottomBarFiltered = GetDistinctedElements(webElement);
            List<string> strs = bottomBarFiltered.Select(x => x.GetAttribute("class")).ToList();
            //Check the case. 3 : Both Standard and Deluxe, 2 : Standard Only, 1 : Deluxe Only, 0 : None
            if (bottomBarFiltered.Count == 2)
            {
                return 3;
            }
            else if (bottomBarFiltered.Count == 1)
            {
                if(strs.Contains("song--item__lv st"))
                    return 2;
                else
                    return 1;
            }
            else
            {
                return 0;
            }
        }

        //Use for only getting difficulty data.
        public IList<IWebElement> GetDistinctedElements(IWebElement webElement)
        {
            IList<IWebElement> bottomBar = webElement.FindElements(By.TagName("div"));
            List<string> attrList = bottomBar.Select(element => element.GetAttribute("class")).ToList();

            string target1 = "song--item__lv st";
            string target2 = "song--item__lv dx";

            List<IWebElement> filteredBottomBar = bottomBar.Where((element, index) => attrList[index] == target1 || attrList[index] == target2).ToList();

            return filteredBottomBar.ToImmutableList();
        }

        public List<string> GetDifficultyList(IWebElement webElement)
        {
            IWebElement webElementList = webElement.FindElements(By.ClassName("song--item__lv__inner")).FirstOrDefault();
            List<string> difficultyList = webElementList.FindElements(By.TagName("p")).ToList().Select(x => x.Text).ToList();
            return difficultyList;
        }

        #endregion
    }
}
