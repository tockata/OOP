using System.Linq;
using System.Text;
using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicShopManager.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles = new List<IArticle>();

        public MusicShop(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Name is required.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return new List<IArticle>(this.articles); }
        }

        public void AddArticle(IArticle article)
        {
            this.articles.Add(article);

        }

        public void RemoveArticle(IArticle article)
        {
            this.articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder musicShop = new StringBuilder();
            musicShop.AppendFormat("===== {0} =====", this.Name);

            if (this.articles.Count == 0)
            {
                musicShop.AppendFormat("\nThe shop is empty. Come back soon.");
                return musicShop.ToString();
            }

            var microphones =
                from article in this.articles
                where article is Microphone
                orderby article.Make, article.Model
                select article as Microphone;

            if (microphones.Count() != 0)
            {
                musicShop.AppendFormat("\n----- Microphones -----");

                foreach (var microphone in microphones)
                {
                    musicShop.Append("\n" + microphone);
                }
            }

            var drums =
                from article in this.articles
                where article is Drum
                orderby article.Make, article.Model
                select article as Drum;

            if (drums.Count() != 0)
            {
                musicShop.AppendFormat("\n----- Drums -----");

                foreach (var drum in drums)
                {
                    musicShop.Append("\n" + drum);
                }
            }

            var electricGuitars =
                from article in this.articles
                where article is ElectricGuitar
                orderby article.Make, article.Model
                select article as ElectricGuitar;

            if (electricGuitars.Count() != 0)
            {
                musicShop.AppendFormat("\n----- Electric guitars -----");

                foreach (var electricGuitar in electricGuitars)
                {
                    musicShop.Append("\n" + electricGuitar);
                }
            }

            var acousticGuitars =
                from article in this.articles
                where article is AcousticGuitar
                orderby article.Make, article.Model
                select article as AcousticGuitar;

            if (acousticGuitars.Count() != 0)
            {
                musicShop.AppendFormat("\n----- Acoustic guitars -----");

                foreach (var acousticGuitar in acousticGuitars)
                {
                    musicShop.Append("\n" + acousticGuitar);
                }
            }

            var bassGuitars =
                from article in this.articles
                where article is BassGuitar
                orderby article.Make, article.Model
                select article as BassGuitar;

            if (bassGuitars.Count() != 0)
            {
                musicShop.AppendFormat("\n----- Bass guitars -----");

                foreach (var bassGuitar in bassGuitars)
                {
                    musicShop.Append("\n" + bassGuitar);
                }
            }

            return musicShop.ToString();
        }
    }
}
