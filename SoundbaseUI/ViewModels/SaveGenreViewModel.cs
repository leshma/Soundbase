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
    public class SaveGenreViewModel : BindableBase
    {
        public SaveGenreViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _genreDAO = new GenreDAO();

            Genre = new Genre();
            Supergenre = new Genre();
            Genres = new ObservableCollection<Genre>(_genreDAO.GetFullList().Except(new List<Genre>() { Genre }));
            SelectedSubgenres = new List<Genre>();

            Operation = "Add";
        }

        public SaveGenreViewModel(Genre a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _genreDAO = new GenreDAO();

            Genre = a;
            Supergenre = a.Supergenre;
            Genres = new ObservableCollection<Genre>(_genreDAO.GetFullList().Except(new List<Genre>() { Genre }));
            SelectedSubgenres = a.Subgenres.ToList();

            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "genres":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new GenresViewModel();
                    MainWindow.MainWindowViewModel.Title = "Genres";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Genre)) return;

            if (_genreDAO.Insert(Genre))
            {
                MessageBox.Show("Genre successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("genres");
            }
            else
            {
                MessageBox.Show("Genre couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Genre)) return;

            if (_genreDAO.Update(Genre))
            {
                MessageBox.Show("Genre successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("genres");
            }
            else
            {
                MessageBox.Show("Genre couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Genre a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Genre doesn't have a name.\n";
            }

            if (a.Supergenre != null)
            {
                a.GenreId = a.Supergenre.Id;
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
        public Genre Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        public Genre Supergenre
        {
            get { return _supergenre; }
            set
            {
                _supergenre = value;
                OnPropertyChanged("Supergenre");
            }
        }

        public List<Genre> SelectedSubgenres
        {
            get { return _selectedSubgenres; }
            set
            {
                _selectedSubgenres = value;
                OnPropertyChanged("SelectedSubgenres");
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

        private GenreDAO _genreDAO;

        private Genre _genre;
        private ObservableCollection<Genre> _genres;
        private Genre _supergenre;
        private List<Genre> _selectedSubgenres;
        private string _operation;
    }
}
