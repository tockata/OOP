using System;
using System.Collections.Generic;

namespace MyTunesShop
{
    public class Album : Media, IAlbum
    {
        private string genre;
        private IList<ISong> songs = new List<ISong>();

        public Album(string title, decimal price, IPerformer performer, string genre, int year) 
            : base(title, price)
        {
            this.Genre = genre;
            this.Performer = performer;
            this.Year = year;
        }

        public IPerformer Performer { get; private set; }

        public string Genre
        {
            get
            {
                return this.genre;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Genre can not be null or empty.");
                }

                this.genre = value;
            }
        }

        public int Year { get; private set; }

        public IList<ISong> Songs
        {
            get { return new List<ISong>(this.songs); }
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }
    }
}
