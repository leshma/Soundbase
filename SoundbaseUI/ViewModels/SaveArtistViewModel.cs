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
    public class SaveArtistViewModel : BindableBase
    {
        public SaveArtistViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _artistDAO = new ArtistDAO();

            Artist = new Artist();
            Operation = "Add";
        }

        public SaveArtistViewModel(Artist a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _artistDAO = new ArtistDAO();

            Artist = a;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "artists":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new ArtistsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Artists";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Artist)) return;

            if (_artistDAO.Insert(Artist))
            {
                MessageBox.Show("Artist successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("artists");
            }
            else
            {
                MessageBox.Show("Artist couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Artist)) return;

            if (_artistDAO.Update(Artist))
            {
                MessageBox.Show("Artist successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("artists");
            }
            else
            {
                MessageBox.Show("Artist couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Artist a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Artist doesn't have a name.\n";
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
        public Artist Artist
        {
            get { return _artist; }
            set
            {
                _artist = value;
                OnPropertyChanged("Artist");
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

        private ArtistDAO _artistDAO;

        private Artist _artist;
        private string _operation;
    }
}
