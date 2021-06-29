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
    class SaveOfficialVideoViewModel : BindableBase
    {
        public SaveOfficialVideoViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _officialVideoDAO = new OfficialVideoDAO();
            _songDAO = new SongDAO();

            OfficialVideo = new OfficialVideo
            {
                Song = new Song(),
            };
            Songs = new ObservableCollection<Song>(_songDAO.GetFullList());

            Operation = "Add";
        }

        public SaveOfficialVideoViewModel(OfficialVideo a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _officialVideoDAO = new OfficialVideoDAO();
            _songDAO = new SongDAO();

            OfficialVideo = a;
            Songs = new ObservableCollection<Song>(_songDAO.GetFullList());

            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "officialvideos":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new OfficialVideosViewModel();
                    MainWindow.MainWindowViewModel.Title = "Official videos";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(OfficialVideo)) return;

            if (_officialVideoDAO.Insert(OfficialVideo))
            {
                MessageBox.Show("Official video successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("officialvideos");
            }
            else
            {
                MessageBox.Show("Official video couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(OfficialVideo)) return;

            if (_officialVideoDAO.Update(OfficialVideo))
            {
                MessageBox.Show("Official video successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("officialvideos");
            }
            else
            {
                MessageBox.Show("Official video couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(OfficialVideo a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Official video doesn't have a name.\n";
            }

            if (a.Format == null || a.Format == string.Empty)
            {
                error += "Official video doesn't have a format.\n";
            }

            if (a.Song == null)
            {
                error += "OfficialVideo doesn't have a song.\n";
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
        public OfficialVideo OfficialVideo
        {
            get { return _officialVideo; }
            set
            {
                _officialVideo = value;
                OnPropertyChanged("OfficialVideo");
            }
        }

        public ObservableCollection<Song> Songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged("Songs");
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

        private OfficialVideoDAO _officialVideoDAO;
        private SongDAO _songDAO;

        private OfficialVideo _officialVideo;
        private ObservableCollection<Song> _songs;
        private string _operation;
    }
}
