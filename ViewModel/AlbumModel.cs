using CommunityToolkit.Mvvm.ComponentModel;
using P4_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.ViewModel
{
    public partial class AlbumModel : ObservableObject
    {
        private MusicContext context = new MusicContext();

        private string _albumTitle;
        public string AlbumTitle { get => _albumTitle; set => SetProperty(ref _albumTitle, value); }

        private DateTime _relaseDate;
        public DateTime RelaseDate { get => _relaseDate; set => SetProperty(ref _relaseDate, value); }

        private string _coverArtLink;
        public string CoverArtLink { get => _coverArtLink; set => SetProperty(ref _coverArtLink, value); }

        private int _artistID;
        public int ArtistID { get => _artistID; set => SetProperty(ref _artistID, value); }
    }
}
