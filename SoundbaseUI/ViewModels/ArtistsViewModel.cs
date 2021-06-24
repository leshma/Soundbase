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
    public class ArtistsViewModel : GenericViewModel<Artist>
    {
        public ArtistsViewModel() : base(new ArtistDAO())
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);
        }

        //================================================================================================
        public override void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "addnew":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveArtistViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add an artist";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveArtistViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update an artist (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public override void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Artist successfully deleted!", "Success", MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            } 
            else
            {
                MessageBox.Show("Artist couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<Artist>(_DAO.GetList());
        }
    }
}
