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
    class RecordLabelsViewModel : GenericViewModel<RecordLabel>
    {
        public RecordLabelsViewModel() : base(new RecordLabelDAO())
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

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveRecordLabelViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a record label";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveRecordLabelViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a record label (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public override void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Record label successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Record label couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<RecordLabel>(_DAO.GetList());

        }
    }
}
