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
    public class SavePerformanceViewModel : BindableBase
    {
        public SavePerformanceViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _performedDAO = new PerformedDAO();
            _songDAO = new SongDAO();
            _artistDAO = new ArtistDAO();

            Performed = new Performed();
            Operation = "Add";
        }

        public SavePerformanceViewModel(Performed c)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _performedDAO = new PerformedDAO();
            _songDAO = new SongDAO();
            _artistDAO = new ArtistDAO();

            Performed = c;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "performance":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new PerformancesViewModel();
                    MainWindow.MainWindowViewModel.Title = "Performances";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Performed)) return;

            if (_performedDAO.Insert(Performed))
            {
                MessageBox.Show("Performance successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("creations");
            }
            else
            {
                MessageBox.Show("Performance couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Performed)) return;

            if (_performedDAO.Update(Performed))
            {
                MessageBox.Show("Performance successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("creations");
            }
            else
            {
                MessageBox.Show("Performance couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Performed c)
        {
            var error = "";

            if (c.SongId == 0)
            {
                error += "Performance doesn't have a song.\n";
            }
            else
            {
                var song = _songDAO.FindById(c.SongId);
                if (song == null)
                {
                    error += "Performance's song doesn't exist with that ID.\n";
                }
                else
                {
                    c.Song = song;
                    //album.Performed.Add(c);
                }
            }

            if (c.ArtistId == 0)
            {
                error += "Performance doesn't have an artist.\n";
            }
            else
            {
                var artist = _artistDAO.FindById(c.ArtistId);
                if (artist == null)
                {
                    error += "Performance's artist doesn't exist with that ID.\n";
                }
                else
                {
                    c.Artist = artist;
                    //artist.Performed.Add(c);
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
        public Performed Performed
        {
            get { return _performed; }
            set
            {
                _performed = value;
                OnPropertyChanged("Performed");
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

        private PerformedDAO _performedDAO;
        private ArtistDAO _artistDAO;
        private SongDAO _songDAO;

        private Performed _performed;
        private string _operation;
    }
}
