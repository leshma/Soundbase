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
    class WritersViewModel : GenericViewModel<Writer>
    {
        public WritersViewModel() : base(new WriterDAO())
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

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveWriterViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a writer";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveWriterViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a writer (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public override void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Writer successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Writer couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<Writer>(_DAO.GetList());

        }
    }
}
