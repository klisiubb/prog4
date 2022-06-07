using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P4_MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.ViewModel
{
    public class MainViewModel : BaseModel
    {

        public RelayCommand artistViewCommand
        {
            get { return new RelayCommand(artistViewSet); }
        }

        public RelayCommand albumViewCommand
        {
            get
            {
                return new RelayCommand(albumViewSet);
            }
        }

        public RelayCommand homeViewCommand
        {
            get
            {
                return new RelayCommand(homeViewSet);
            }
        }

        public RelayCommand songViewCommand
        {
            get
            {
                return new RelayCommand(songViewSet);
            }
        }

        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged(); // ,moze tutaj
            }
        }

        public void albumViewSet()
        {
            currentView = new AlbumModel();
        }

        public void artistViewSet()
        {
            currentView = new ArtistModel();
        }

        public void homeViewSet()
        {
            currentView = new HomeModel();
        }

        public void songViewSet()
        {
            currentView = new SongModel();
        }
        public MainViewModel()
        {

            currentView =  new HomeModel();

        }




        //public void ArtistView()
        //{
        //    _currentView = new artistModel();

        //}


    }
}
