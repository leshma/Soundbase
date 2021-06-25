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
    class SaveMixingEngineerViewModel : BindableBase
    {
        public SaveMixingEngineerViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _engineerDAO = new EngineerDAO();

            MixingEngineer = new MixingEngineer();
            Operation = "Add";
        }

        public SaveMixingEngineerViewModel(MixingEngineer m)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _engineerDAO = new EngineerDAO();

            MixingEngineer = m;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "mixingengineers":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new MixingEngineersViewModel();
                    MainWindow.MainWindowViewModel.Title = "Mixing Engineers";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(MixingEngineer)) return;

            if (_engineerDAO.Insert(MixingEngineer))
            {
                MessageBox.Show("Mixing engineer successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("mixingengineers");
            }
            else
            {
                MessageBox.Show("Mixing engineer couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(MixingEngineer)) return;

            if (_engineerDAO.Update(MixingEngineer))
            {
                MessageBox.Show("Mixing engineer successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("mixingengineers");
            }
            else
            {
                MessageBox.Show("Mixing engineer couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(MixingEngineer m)
        {
            var error = "";

            if (m.Name == null || m.Name == string.Empty)
            {
                error += "Mixing engineer doesn't have a name.\n";
            }

            if (m.Awards == null || m.Awards == string.Empty)
            {
                error += "Mixing engineer doesn't have awards.\n";
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
        public MixingEngineer MixingEngineer
        {
            get { return _mixingEngineer; }
            set
            {
                _mixingEngineer = value;
                OnPropertyChanged("MixingEngineer");
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

        private MixingEngineer _mixingEngineer;
        private string _operation;
    }
}
