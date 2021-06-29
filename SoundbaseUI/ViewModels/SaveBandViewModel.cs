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
    public class SaveBandViewModel : BindableBase
    {
        public SaveBandViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _artistDAO = new ArtistDAO();
            _bandDAO = new BandDAO();

            Band = new Band();
            Operation = "Add";
            Artists = _artistDAO.GetFullList();
            SelectedArtists = new List<Artist>();
        }

        public SaveBandViewModel(Band b)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _artistDAO = new ArtistDAO();
            _bandDAO = new BandDAO();

            Band = b;
            Operation = "Update";
            Artists = _artistDAO.GetFullList();
            SelectedArtists = new List<Artist>();
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "bands":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new BandsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Bands";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Band)) return;

            if (_bandDAO.Insert(Band))
            {
                MessageBox.Show("Band successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("bands");
            }
            else
            {
                MessageBox.Show("Band couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Band)) return;

            if (_bandDAO.Update(Band))
            {
                MessageBox.Show("Band successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("bands");
            }
            else
            {
                MessageBox.Show("Band couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Band b)
        {
            var error = "";

            if (b.Name == null || b.Name == string.Empty)
            {
                error += "Band doesn't have a name.\n";
            }

            if (SelectedArtists == null || SelectedArtists.Count == 0)
            {
                error += "Band must have some artists.\n";
            }
            else
            {
                b.Artists = SelectedArtists;
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
        public Band Band
        {
            get { return _band; }
            set
            {
                _band = value;
                OnPropertyChanged("Band");
            }
        }

        public List<Artist> Artists
        {
            get { return _artists; }
            set
            {
                _artists = value;
                OnPropertyChanged("Artists");
            }
        }

        public List<Artist> SelectedArtists
        {
            get { return _selectedArtists; }
            set
            {
                _selectedArtists = value;
                OnPropertyChanged("SelectedArtists");
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
        private BandDAO _bandDAO;

        private Band _band;
        private List<Artist> _artists;
        private List<Artist> _selectedArtists;
        private string _operation;
    }
}
