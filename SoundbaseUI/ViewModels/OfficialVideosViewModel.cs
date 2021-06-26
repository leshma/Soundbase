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
    public class OfficialVideosViewModel : GenericViewModel<OfficialVideo>
    {
        public OfficialVideosViewModel() : base(new OfficialVideoDAO())
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

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveOfficialVideoViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a video";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveOfficialVideoViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a video (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public override void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Official video successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Official video couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<OfficialVideo>(_DAO.GetList());
        }
    }
}