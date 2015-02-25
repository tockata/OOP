using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class ExtendedMyTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertMemberToBand(commandWords);
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        private void ExecuteInsertMemberToBand(string[] commandWords)
        {
            var band = this.performers.FirstOrDefault(b => b is Band && b.Name == commandWords[2]);
            var member = commandWords[3];

            if (band == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
                return;
            }

            int indexOfBand = this.performers.IndexOf(band);
            ((Band)this.performers[indexOfBand]).AddMember(member);
            this.Printer.PrintLine("The member {0} has been added to the band {1}.",
                member, commandWords[2]);
        }

        private void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            var song = this.media.FirstOrDefault(s => s is Song && s.Title == commandWords[3]);
            var album = this.media.FirstOrDefault(a => a is Album && a.Title == commandWords[2]);

            if (album == null)
            {
                this.Printer.PrintLine("The album does not exist in the database.");
                return;
            }

            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            int indexOfAlbum = this.media.IndexOf(album);
            ((Album)this.media[indexOfAlbum]).AddSong(song as Song);
            this.Printer.PrintLine("The song {0} has been added to the album {1}.",
                commandWords[3], commandWords[2]);
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            bool songFound = false;
            for (int i = 0; i < this.media.Count; i++)
            {
                if (this.media[i] is Song && this.media[i].Title == commandWords[2])
                {
                    (this.media[i] as Song).PlaceRating(int.Parse(commandWords[3]));
                    songFound = true;
                }
            }

            if (songFound)
            {
                this.Printer.PrintLine("The rating has been placed successfully.");
            }
            else
            {
                this.Printer.PrintLine("The song does not exist in the database.");
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(b => b is Band && b.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        private string GetBandReport(Band band)
        {
            StringBuilder bandReport = new StringBuilder();
            bandReport.AppendFormat(band.Name + ":");
            if (band.Members.Count != 0)
            {
                bandReport.AppendFormat(" ");
                int count = 0;
                for (int i = 0; i < band.Members.Count; i++)
                {
                    if (count == 0)
                    {
                        bandReport.AppendFormat(band.Members[i]);
                        count++;
                    }
                    else
                    {
                        bandReport.AppendFormat(", {0}", band.Members[i]);
                    }
                }
            }

            if (band.Songs.Count == 0)
            {
                bandReport.AppendLine().AppendFormat("no songs");
            }
            else
            {
                bandReport.AppendLine();
                int count = 0;

                var sortedSongs =
                    from currentSong in band.Songs
                    orderby currentSong.Title
                    select currentSong.Title;

                foreach (var songTitle in sortedSongs)
                {
                    if (count == 0)
                    {
                        bandReport.AppendFormat(songTitle);
                        count++;
                    }
                    else
                    {
                        bandReport.AppendFormat("; {0}", songTitle);
                    }
                }
            }

            return bandReport.ToString();
        }

        private string GetAlbumReport(IAlbum album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfo = new StringBuilder();
            albumInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold)
                .AppendLine();

            if (album.Songs.Count == 0)
            {
                albumInfo.AppendFormat("No songs");
            }
            else
            {
                albumInfo.AppendFormat("Songs:");
                foreach (var song in album.Songs)
                {
                    albumInfo.AppendLine().AppendFormat("{0} ({1})", song.Title, song.Duration);
                }
            }

            return albumInfo.ToString();
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", ((Song)song).CalculateAverageRating()).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }
    }
}
