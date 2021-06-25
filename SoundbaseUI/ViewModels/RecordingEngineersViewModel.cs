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
    class RecordingEngineersViewModel : BindableBase
    {
        public RecordingEngineersViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);

            _DAO = new EngineerDAO();

            Elements = new ObservableCollection<RecordingEngineer>(_DAO.GetRecordingEngineersList());
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdRemoveSelected { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "addnew":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveRecordingEngineerViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a rec. engineer";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveRecordingEngineerViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a rec. engineer (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Recording engineer successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Recording engineer couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<RecordingEngineer>(_DAO.GetRecordingEngineersList());
        }

        //================================================================================================
        public ObservableCollection<RecordingEngineer> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }

        public RecordingEngineer SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                OnPropertyChanged("SelectedElement");
            }
        }

        //================================================================================================
        protected EngineerDAO _DAO;

        private ObservableCollection<RecordingEngineer> _elements;
        private RecordingEngineer _selectedElement;
    }
}
