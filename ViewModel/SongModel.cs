using CommunityToolkit.Mvvm.ComponentModel;
using P4_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.ViewModel
{
    public partial class SongModel : ObservableObject
    {
        private MusicContext context = new MusicContext();

        private string _songName;
        public string SongName { get => _songName; set => SetProperty(ref _songName, value); }

        private string _songDuration;
        public string SongDuration { get => _songDuration; set => SetProperty(ref _songDuration, value); }

        private string _songLink;
        public string SongLink { get => _songLink; set => SetProperty(ref _songLink, value); }

        private int _albumID;
        public int AlbumID { get => _albumID; set => SetProperty(ref _albumID, value); }

    }
}
