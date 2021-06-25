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
    class SaveComposerViewModel : BindableBase
    {
        public SaveComposerViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _composerDAO = new ComposerDAO();

            Composer = new Composer();
            Operation = "Add";
        }

        public SaveComposerViewModel(Composer c)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _composerDAO = new ComposerDAO();

            Composer = c;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "composers":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new ComposersViewModel();
                    MainWindow.MainWindowViewModel.Title = "Composers";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Composer)) return;

            if (_composerDAO.Insert(Composer))
            {
                MessageBox.Show("Composer successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("artists");
            }
            else
            {
                MessageBox.Show("Composer couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Composer)) return;

            if (_composerDAO.Update(Composer))
            {
                MessageBox.Show("Composer successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("artists");
            }
            else
            {
                MessageBox.Show("Composer couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Composer c)
        {
            var error = "";

            if (c.Name == null || c.Name == string.Empty)
            {
                error += "Composer doesn't have a name.\n";
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
        public Composer Composer
        {
            get { return _composer; }
            set
            {
                _composer = value;
                OnPropertyChanged("Composer");
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

        private ComposerDAO _composerDAO;

        private Composer _composer;
        private string _operation;
    }
}
