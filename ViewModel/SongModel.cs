using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P4_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace P4_MVVM.ViewModel
{
    public partial class SongModel : BaseModel
    {
        public ICommand deleteSongCommand { get; set; }
        public ICommand addSongCommand { get; set; }
        public ICommand updateSongCommand { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
        public SongModel()
        {
            Songs = new ObservableCollection<Song>(context.Songs.ToList());

            deleteSongCommand = new RelayCommand<Song>((param) => deleteSong(param));
            updateSongCommand = new RelayCommand<Song>((param) => updateSong(param));
            addSongCommand = new RelayCommand(addSong);
        }

        private string _songName;
        public string SongName
        {
            get { return _songName; }
            set
            {
                _songName = value;
                onPropertyChanged(nameof(_songName));
            }
        }

        private string _songDuration;
        public string SongDuration
        {
            get { return _songDuration; }
            set
            {
                _songDuration = value;
                onPropertyChanged(nameof(_songDuration));
            }
        }

        private string _songLink;
        public string SongLink
        {
            get { return _songLink; }
            set
            {
                _songLink= value;
                onPropertyChanged(nameof(_songLink));
            }
        }

        private int _albumID;

        public int AlbumID
        {
            get { return _albumID; }
            set
            {
                _albumID= value;
                onPropertyChanged(nameof(_albumID));
            }
        }

        private void deleteSong(Song param)
        {
            Song song = context.Songs.Where(x => x.SongID==param.SongID).FirstOrDefault();
            context.Songs.Remove(song);
            context.SaveChanges();

            MessageBox.Show("Song deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void addSong()
        {
            if (!string.IsNullOrEmpty(SongName) && !string.IsNullOrEmpty(SongDuration) && !string.IsNullOrEmpty(SongLink))
            {
                var song = new Song()
                {
                    SongName = _songName,
                    SongDuration = _songDuration,
                    SongLink = _songLink,
                    AlbumID = _albumID
                };

                context.Songs.Add(song);
                context.SaveChanges();

                SongName = string.Empty;
                SongDuration = string.Empty;
                SongLink = string.Empty;

                MessageBox.Show("Song added.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void updateSong(Song param)
        {

            if (!string.IsNullOrEmpty(SongName) && !string.IsNullOrEmpty(SongDuration) && !string.IsNullOrEmpty(SongLink))
            {

                Song song = context.Songs.Where(x => x.SongID==param.SongID).FirstOrDefault();
                song.SongName = _songName;
                song.SongDuration = _songDuration;
                song.SongLink = _songLink;
                song.AlbumID = _albumID;

                context.SaveChanges();

                SongName = string.Empty;
                SongDuration = string.Empty;
                SongLink = string.Empty;
                MessageBox.Show("Song updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
