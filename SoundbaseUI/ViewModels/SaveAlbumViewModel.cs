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
    public class SaveAlbumViewModel : BindableBase
    {
        public SaveAlbumViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _albumDAO = new AlbumDAO();

            Album = new Album();
            Operation = "Add";
        }

        public SaveAlbumViewModel(Album a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _albumDAO = new AlbumDAO();

            Album = a;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "albums":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new AlbumsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Albums";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Album)) return;

            if (_albumDAO.Insert(Album))
            {
                MessageBox.Show("Album successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("albums");
            }
            else
            {
                MessageBox.Show("Album couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Album)) return;

            if (_albumDAO.Update(Album))
            {
                MessageBox.Show("Album successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("albums");
            }
            else
            {
                MessageBox.Show("Album couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Album a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Album doesn't have a name.\n";
            }

            if (a.Year == 0)
            {
                error += "Album doesn't have a year.\n";
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
        public Album Album
        {
            get { return _album; }
            set
            {
                _album = value;
                OnPropertyChanged("Album");
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

        private AlbumDAO _albumDAO;

        private Album _album;
        private string _operation;
    }
}
