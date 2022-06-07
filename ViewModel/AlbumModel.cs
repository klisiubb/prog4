using P4_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace P4_MVVM.ViewModel
{
    public partial class AlbumModel : BaseModel
    {
        private MusicContext context = new MusicContext();

        public ObservableCollection<Album> Albums { get; set; }
        public ObservableCollection<Artist> Artists { get; set; }
        public ICommand addAlbumCommand { get; set; }
        public ICommand updateAlbumCommand { get; set; }
        public ICommand deleteAlbumCommand { get; set; }

        public AlbumModel()
        {
            Albums = new ObservableCollection<Album>(context.Albums.ToList());
            Artists = new ObservableCollection<Artist>(context.Artists.ToList());

            deleteAlbumCommand = new RelayCommand<Album>((param) => deleteAlbum(param));
            updateAlbumCommand = new RelayCommand<Album>((param) => updateAlbum(param));
            addAlbumCommand = new RelayCommand(addAlbum);
        }

        private string _albumTitle;
        public string AlbumTitle
        {
            get { return _albumTitle; }
            set
            {
                _albumTitle = value;
                onPropertyChanged(nameof(_albumTitle));
            }
        }

        private string _relaseDate;
        public string RelaseDate
        {
            get { return _relaseDate; }
            set
            {
                _relaseDate = value;
                onPropertyChanged(nameof(_relaseDate));
            }
        }

        private string _coverArtLink;
        public string CoverArtLink
        {
            get { return _coverArtLink; }
            set
            {
                _coverArtLink = value;
                onPropertyChanged(nameof(_coverArtLink));
            }
        }

        private int _artistID;
        public int ArtistID
        {
            get { return _artistID; }
            set
            {
                _artistID = value;
                onPropertyChanged(nameof(_artistID));
            }
        }

        void addAlbum()
        {
            if (!string.IsNullOrEmpty(AlbumTitle) && !string.IsNullOrEmpty(RelaseDate) && !string.IsNullOrEmpty(CoverArtLink))
            {
                var album = new Album()
                {
                    AlbumTitle = _albumTitle,
                    RelaseDate = _relaseDate,
                    CoverArtLink= _coverArtLink,
                    ArtistID = _artistID,

                };

                context.Albums.Add(album);
                context.SaveChanges();

                AlbumTitle = string.Empty;
                RelaseDate = string.Empty;
                CoverArtLink = string.Empty;

                MessageBox.Show("Album added.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updateAlbum(Album param)
        {
            if (!string.IsNullOrEmpty(AlbumTitle) && !string.IsNullOrEmpty(RelaseDate) && !string.IsNullOrEmpty(CoverArtLink))
            {

                Album album = context.Albums.Where(x => x.AlbumID==param.AlbumID).FirstOrDefault();
                album.AlbumTitle = _albumTitle;
                album.RelaseDate = _relaseDate;
                album.CoverArtLink = _coverArtLink;
                album.ArtistID = _artistID;

                context.SaveChanges();
                AlbumTitle = string.Empty;
                RelaseDate = string.Empty;
                CoverArtLink = string.Empty;

                MessageBox.Show("Album updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteAlbum(Album param)
        {
            Album album = context.Albums.Where(x => x.AlbumID==param.AlbumID).FirstOrDefault();
            context.Albums.Remove(album);
            context.SaveChanges();

            MessageBox.Show("Album deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);


        }



    }
}
