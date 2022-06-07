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
    public partial class MainViewModel : BaseModel
    {

        public RelayCommand artistViewCommand
        {
            get { return new RelayCommand(artistViewSet); }
        }
        public RelayCommand songViewCommand { get; set; }

        public RelayCommand albumViewCommand
        {
            get
            {
                return new RelayCommand(albumViewSet);
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

        private void albumViewSet()
        {
            currentView = new AlbumModel();
        }

        private void artistViewSet()
        {
            currentView = new ArtistModel();
        }

        public MainViewModel()
        {

            currentView =  new ArtistModel();

        }




        //public void ArtistView()
        //{
        //    _currentView = new artistModel();

        //}


    }
}
