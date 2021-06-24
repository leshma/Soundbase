using Soundbase;
using Soundbase.DAO;
using SoundbaseUI.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoundbaseUI.ViewModels
{
    public class ArtistsViewModel : BindableBase
    {
        public ArtistsViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);

            _artistDAO = new ArtistDAO();
            Artists = new ObservableCollection<Artist>(_artistDAO.GetList());
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdRemoveSelected { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "addartist":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveArtistViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add an artist";
                    break;

                case "updateartist":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveArtistViewModel(SelectedArtist);
                    MainWindow.MainWindowViewModel.Title = "Update an artist (ID: " + SelectedArtist.Id + ")";
                    break;
            }
        }

        public void RemoveSelected()
        {
            if (_artistDAO.Delete(SelectedArtist.Id))
            {
                MessageBox.Show("Artist successfully deleted!", "Success", MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            } 
            else
            {
                MessageBox.Show("Artist couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Artists = new ObservableCollection<Artist>(_artistDAO.GetList());
        }

        //================================================================================================
        public ObservableCollection<Artist> Artists
        {
            get { return _artists; }
            set
            {
                _artists = value;
                OnPropertyChanged("Artists");
            }
        }

        public Artist SelectedArtist
        {
            get { return _selectedArtist; }
            set 
            {
                _selectedArtist = value;
                OnPropertyChanged("SelectedArtist");
            }
        }

        //================================================================================================
        private ArtistDAO _artistDAO;

        private ObservableCollection<Artist> _artists;
        private Artist _selectedArtist;
    }
}
