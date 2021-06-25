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
    public class SaveCreationViewModel : BindableBase
    {
        public SaveCreationViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _createdDAO = new CreatedDAO();
            _albumDAO = new AlbumDAO();
            _artistDAO = new ArtistDAO();

            Created = new Created();
            Operation = "Add";
        }

        public SaveCreationViewModel(Created c)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _createdDAO = new CreatedDAO();
            _albumDAO = new AlbumDAO();
            _artistDAO = new ArtistDAO();

            Created = c;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "creations":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new CreationsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Creations";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Created)) return;

            if (_createdDAO.Insert(Created))
            {
                MessageBox.Show("Creation successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("creations");
            }
            else
            {
                MessageBox.Show("Creation couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Created)) return;

            if (_createdDAO.Update(Created))
            {
                MessageBox.Show("Creation successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("creations");
            }
            else
            {
                MessageBox.Show("Creation couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Created c)
        {
            var error = "";

            if (c.AlbumId == 0)
            {
                error += "Creation doesn't have an album.\n";
            }
            else
            {
                var album = _albumDAO.FindById(c.AlbumId);
                if (album == null)
                {
                    error += "Creation's album doesn't exist with that ID.\n";
                }
                else
                {
                    c.Album = album;
                    //album.Created.Add(c);
                }
            }

            if (c.ArtistId == 0)
            {
                error += "Creation doesn't have an artist.\n";
            }
            else
            {
                var artist = _artistDAO.FindById(c.ArtistId);
                if (artist == null)
                {
                    error += "Creation's artist doesn't exist with that ID.\n";
                }
                else
                {
                    c.Artist = artist;
                    //artist.Created.Add(c);
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
        public Created Created
        {
            get { return _created; }
            set
            {
                _created = value;
                OnPropertyChanged("Created");
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

        private CreatedDAO _createdDAO;
        private ArtistDAO _artistDAO;
        private AlbumDAO _albumDAO;

        private Created _created;
        private string _operation;
    }
}
