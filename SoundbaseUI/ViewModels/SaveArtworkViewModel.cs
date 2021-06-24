using Soundbase;
using Soundbase.DAO;
using SoundbaseUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoundbaseUI.ViewModels
{
    public class SaveArtworkViewModel : BindableBase
    {
        public SaveArtworkViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _artworkDAO = new ArtworkDAO();
            _albumDAO = new AlbumDAO();

            Artwork = new Artwork
            {
                Album = new Album(),
            };
            Operation = "Add";
        }

        public SaveArtworkViewModel(Artwork a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _artworkDAO = new ArtworkDAO();
            _albumDAO = new AlbumDAO();

            Artwork = a;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "artworks":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new ArtworksViewModel();
                    MainWindow.MainWindowViewModel.Title = "Artworks";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Artwork)) return;
            
            if (_artworkDAO.Insert(Artwork))
            {
                MessageBox.Show("Artwork successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("albums");
            }
            else
            {
                MessageBox.Show("Artwork couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Artwork)) return;

            if (_artworkDAO.Update(Artwork))
            {
                MessageBox.Show("Artwork successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("albums");
            }
            else
            {
                MessageBox.Show("Artwork couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Artwork a)
        {
            var error = "";

            if (a.Artist == null || a.Artist == string.Empty)
            {
                error += "Artwork doesn't have an artist name.\n";
            }

            if (a.Format == null || a.Format == string.Empty)
            {
                error += "Artwork doesn't have a format.\n";
            }

            if (a.Album == null)
            {
                error += "Artwork doesn't have an album.\n";
            }
            else
            {
                var album = _albumDAO.FindById(a.Album.Id);
                if (album == null)
                {
                    error += "Artwork's album doesn't exist with that ID.\n";
                }
                else
                {
                    var artworkExists = _albumDAO.GetAlbumArtwork(a.Album.Id) != null;
                    if (artworkExists)
                    {
                        error += "Album already has an artwork!\n";
                    }
                    else
                    {
                        a.Album = album;
                        album.Artwork = a;
                    }
                }
            }

            if (error != "")
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        //================================================================================================
        public Artwork Artwork
        {
            get { return _artwork; }
            set
            {
                _artwork = value;
                OnPropertyChanged("Artwork");
            }
        }

        public string Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                OnPropertyChanged("Operation");
            }
        }

        private ArtworkDAO _artworkDAO;
        private AlbumDAO _albumDAO;

        private Artwork _artwork;
        private string _operation;
    }
}
