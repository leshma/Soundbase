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
    class SaveWriterViewModel : BindableBase
    {
        public SaveWriterViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _writerDAO = new WriterDAO();

            Writer = new Writer();
            Operation = "Add";
        }

        public SaveWriterViewModel(Writer a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _writerDAO = new WriterDAO();

            Writer = a;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "writers":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new WritersViewModel();
                    MainWindow.MainWindowViewModel.Title = "Writers";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(Writer)) return;

            if (_writerDAO.Insert(Writer))
            {
                MessageBox.Show("Writer successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("writers");
            }
            else
            {
                MessageBox.Show("Writer couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(Writer)) return;

            if (_writerDAO.Update(Writer))
            {
                MessageBox.Show("Writer successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("writers");
            }
            else
            {
                MessageBox.Show("Writer couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(Writer a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Writer doesn't have a name.\n";
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
        public Writer Writer
        {
            get { return _writer; }
            set
            {
                _writer = value;
                OnPropertyChanged("Writer");
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

        private WriterDAO _writerDAO;

        private Writer _writer;
        private string _operation;
    }
}
