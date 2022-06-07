using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P4_MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace P4_MVVM.ViewModel
{
    public class ArtistModel : BaseModel
    {
        public ICommand deleteArtistCommand { get; set; }
        public ICommand addArtistCommand { get; set; }
        public ICommand updateArtistCommand { get; set; }
        public ObservableCollection<Artist> Artists { get; set; }
        public ArtistModel()
        {

            Artists = new ObservableCollection<Artist>(context.Artists.ToList());

            deleteArtistCommand = new RelayCommand<Artist>((param) => deleteArtist(param));
            updateArtistCommand = new RelayCommand<Artist>((param) => updateArtist(param));
            addArtistCommand = new RelayCommand(addArtist);
        }


        private MusicContext context = new MusicContext();

        private int _artistID;
        public int ArtistID { get => _artistID; }

        private string _artistName;
        public string ArtistName
        {
            get { return _artistName; }
            set
            {
                _artistName = value;
                onPropertyChanged(nameof(_artistName));
            }
        }


        private string _shortDescription;
        public string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                _shortDescription = value;
                onPropertyChanged(nameof(_shortDescription));
            }
        }

        private string _countryOfOrgin;
        public string CountryOfOrgin
        {
            get { return _countryOfOrgin; }
            set
            {
                _countryOfOrgin = value;
                onPropertyChanged(nameof(_countryOfOrgin));
            }
        }

        private string _artistPhotoLink;
        public string ArtistPhotoLink
        {
            get { return _artistPhotoLink; }
            set
            {
                _artistPhotoLink = value;
                onPropertyChanged(nameof(_artistPhotoLink));
            }
        }

        private string _genre;
        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                onPropertyChanged(nameof(_genre));
            }
        }



        private void addArtist()
        {
            if (!string.IsNullOrEmpty(ArtistName) && !string.IsNullOrEmpty(ShortDescription) && !string.IsNullOrEmpty(CountryOfOrgin) && !string.IsNullOrEmpty(ArtistPhotoLink)&& !string.IsNullOrEmpty(Genre))
            {

                var artist = new Artist()
                {
                    ArtistName = _artistName,
                    ShortDescription = _shortDescription,
                    CountryOfOrgin = _countryOfOrgin,
                    ArtistPhotoLink = _artistPhotoLink,
                    Genre = _genre
                };

                context.Artists.Add(artist);
                context.SaveChanges();

                ArtistName = string.Empty;
                ShortDescription = string.Empty;
                CountryOfOrgin = string.Empty;
                ArtistPhotoLink = string.Empty;
                Genre = string.Empty;

                MessageBox.Show("Artist added.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void deleteArtist(Artist param)
        {
            Artist artist = context.Artists.Where(x => x.ArtistID==param.ArtistID).FirstOrDefault();
            context.Artists.Remove(artist);
            context.SaveChanges();
        }

        private void updateArtist(Artist param)
        {

            if (!string.IsNullOrEmpty(ArtistName) && !string.IsNullOrEmpty(ShortDescription) && !string.IsNullOrEmpty(CountryOfOrgin) && !string.IsNullOrEmpty(ArtistPhotoLink)&& !string.IsNullOrEmpty(Genre))
            {

                Artist artist = context.Artists.Where(x => x.ArtistID==param.ArtistID).FirstOrDefault();
                artist.ArtistName = _artistName;
                artist.ShortDescription= _shortDescription;
                artist.CountryOfOrgin = _countryOfOrgin;
                artist.ArtistPhotoLink = _artistPhotoLink;
                artist.Genre=_genre;
                context.SaveChanges();

                ArtistName = string.Empty;
                ShortDescription = string.Empty;
                CountryOfOrgin = string.Empty;
                ArtistPhotoLink = string.Empty;
                Genre = string.Empty;
                MessageBox.Show("Artist updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Fill al the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
