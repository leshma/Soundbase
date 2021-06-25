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
    class GenresViewModel : GenericViewModel<Genre>
    {
        public GenresViewModel() : base(new GenreDAO())
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);

            Elements = new ObservableCollection<Genre>(((GenreDAO)_DAO).GetFullList());
        }

        //================================================================================================
        public override void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "addnew":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveGenreViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a genre";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveGenreViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a genre (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public override void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Genre successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Genre couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<Genre>(((GenreDAO)_DAO).GetFullList());
        }
    }
}