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
    public class MixingEngineersViewModel : BindableBase
    {
        public MixingEngineersViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);

            _DAO = new EngineerDAO();

            Elements = new ObservableCollection<MixingEngineer>(_DAO.GetMixingEngineersList());
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdRemoveSelected { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "addnew":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveMixingEngineerViewModel();
                    MainWindow.MainWindowViewModel.Title = "Add a mix engineer";
                    break;

                case "updateselected":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new SaveMixingEngineerViewModel(SelectedElement);
                    MainWindow.MainWindowViewModel.Title = "Update a mix engineer (ID: " + SelectedElement.Id + ")";
                    break;
            }
        }

        public void RemoveSelected()
        {
            if (_DAO.Delete(SelectedElement.Id))
            {
                MessageBox.Show("Mix engineer successfully deleted!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Mix engineer couldn't be deleted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Elements = new ObservableCollection<MixingEngineer>(_DAO.GetMixingEngineersList());
        }

        //================================================================================================
        public ObservableCollection<MixingEngineer> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }

        public MixingEngineer SelectedElement
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

        private ObservableCollection<MixingEngineer> _elements;
        private MixingEngineer _selectedElement;
    }
}
