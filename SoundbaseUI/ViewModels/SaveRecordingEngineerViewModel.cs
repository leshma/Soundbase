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
    public class SaveRecordingEngineerViewModel : BindableBase
    {
        public SaveRecordingEngineerViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _engineerDAO = new EngineerDAO();

            RecordingEngineer = new RecordingEngineer();
            Operation = "Add";
        }

        public SaveRecordingEngineerViewModel(RecordingEngineer m)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _engineerDAO = new EngineerDAO();

            RecordingEngineer = m;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "recordingengineers":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new RecordingEngineersViewModel();
                    MainWindow.MainWindowViewModel.Title = "Recording Engineers";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(RecordingEngineer)) return;

            if (_engineerDAO.Insert(RecordingEngineer))
            {
                MessageBox.Show("Recording engineer successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("recordingengineers");
            }
            else
            {
                MessageBox.Show("Recording engineer couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(RecordingEngineer)) return;

            if (_engineerDAO.Update(RecordingEngineer))
            {
                MessageBox.Show("Recording engineer successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("recordingengineers");
            }
            else
            {
                MessageBox.Show("Recording engineer couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(RecordingEngineer m)
        {
            var error = "";

            if (m.Name == null || m.Name == string.Empty)
            {
                error += "Recording engineer doesn't have a name.\n";
            }

            if (m.StudioName == null || m.StudioName == string.Empty)
            {
                error += "Recording engineer doesn't have a studio name.\n";
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
        public RecordingEngineer RecordingEngineer
        {
            get { return _recingEngineer; }
            set
            {
                _recingEngineer = value;
                OnPropertyChanged("RecordingEngineer");
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

        private EngineerDAO _engineerDAO;

        private RecordingEngineer _recingEngineer;
        private string _operation;
    }
}
