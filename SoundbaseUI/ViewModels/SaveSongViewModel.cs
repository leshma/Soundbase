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
    public class SaveSongViewModel : BindableBase
    {
        public SaveSongViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _songDAO = new SongDAO();
            _engineerDAO = new EngineerDAO();
            _writerDAO = new WriterDAO();
            _genreDAO = new GenreDAO();
            _composerDAO = new ComposerDAO();

            Song = new Song();
            
            Engineers = _engineerDAO.GetList();
            Writers = _writerDAO.GetList();
            Genres = _genreDAO.GetList();
            Composers = _composerDAO.GetList();

            Operation = "Add";
        }

        public SaveSongViewModel(Song c)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _songDAO = new SongDAO();
            _engineerDAO = new EngineerDAO();
            _writerDAO = new WriterDAO();
            _genreDAO = new GenreDAO();
            _composerDAO = new ComposerDAO();

            Song = c;

            Engineers = _engineerDAO.GetList();
            Writers = _writerDAO.GetList();
            Genres = _genreDAO.GetList();
            Composers = _composerDAO.GetList();

            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "songs":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SongsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Songs";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Song)) return;

            Song.Engineers = SelectedEngineers;
            Song.Genres = SelectedGenres;
            Song.Writers = SelectedWriters;
            Song.Composers = SelectedComposers;

            if (_songDAO.Insert(Song))
            {
                MessageBox.Show("Song successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("songs");
            }
            else
            {
                MessageBox.Show("Song couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Song)) return;

            Song.Engineers = SelectedEngineers;
            Song.Genres = SelectedGenres;
            Song.Writers = SelectedWriters;
            Song.Composers = SelectedComposers;

            if (_songDAO.Update(Song))
            {
                MessageBox.Show("Song successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("songs");
            }
            else
            {
                MessageBox.Show("Song couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Song c)
        {
            var error = "";

            if (c.Name == null || c.Name == string.Empty)
            {
                error += "Song doesn't have a name.\n";
            }

            if (SelectedGenres == null || SelectedGenres.Count == 0)
            {
                error += "Song doesn't have a genre.\n";
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
        public Song Song
        {
            get { return _song; }
            set
            {
                _song = value;
                OnPropertyChanged("Song");
            }
        }

        public List<Engineer> Engineers
        {
            get { return _engineers; }
            set 
            { 
                _engineers = value;
                OnPropertyChanged("Engineers");
            }
        }

        public List<Engineer> SelectedEngineers { get; set; }

        public List<Writer> Writers
        {
            get { return _writers; }
            set
            {
                _writers = value;
                OnPropertyChanged("Writers");
            }
        }

        public List<Writer> SelectedWriters { get; set; }

        public List<Genre> Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        public List<Genre> SelectedGenres { get; set; }

        public List<Composer> Composers
        {
            get { return _composers; }
            set
            {
                _composers = value;
                OnPropertyChanged("Composers");
            }
        }

        public List<Composer> SelectedComposers { get; set; }

        public string Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                OnPropertyChanged("Operation");
            }
        }

        private SongDAO _songDAO;
        private EngineerDAO _engineerDAO;
        private WriterDAO _writerDAO;
        private GenreDAO _genreDAO;
        private ComposerDAO _composerDAO;

        private Song _song;
        private List<Engineer> _engineers;
        private List<Writer> _writers;
        private List<Genre> _genres;
        private List<Composer> _composers;
        private string _operation;
    }
}
