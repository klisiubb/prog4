﻿using P4_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P4_MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy Artistxaml.xaml
    /// </summary>
    public partial class Artist : UserControl
    {
        private readonly ArtistModel _viewModel;
        public Artist()
        {
            InitializeComponent();
            //_viewModel = new ArtistModel();
            // DataContext = _viewModel;
        }
    }
}
