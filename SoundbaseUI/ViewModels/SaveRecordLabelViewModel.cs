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
    class SaveRecordLabelViewModel : BindableBase
    {
        public SaveRecordLabelViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(AddNew);

            _recordLabelDAO = new RecordLabelDAO();

            RecordLabel = new RecordLabel();
            Operation = "Add";
        }

        public SaveRecordLabelViewModel(RecordLabel a)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdOperation = new RelayCommand(UpdateExisting);

            _recordLabelDAO = new RecordLabelDAO();

            RecordLabel = a;
            Operation = "Update";
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdOperation { get; set; }

        public void ChangeView(string view)
        {
            switch (view.ToLower())
            {
                case "recordlabels":

                    MainWindow.MainWindowViewModel.CurrentViewModel = new RecordLabelsViewModel();
                    MainWindow.MainWindowViewModel.Title = "Record labels";
                    break;
            }
        }

        public void AddNew()
        {
            if (!Validate(RecordLabel)) return;

            if (_recordLabelDAO.Insert(RecordLabel))
            {
                MessageBox.Show("Record label successfully added!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("recordlabels");
            }
            else
            {
                MessageBox.Show("Record label couldn't be added.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void UpdateExisting()
        {
            if (!Validate(RecordLabel)) return;

            if (_recordLabelDAO.Update(RecordLabel))
            {
                MessageBox.Show("Record label successfully updated!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ChangeView("recordlabels");
            }
            else
            {
                MessageBox.Show("Record label couldn't be updated.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        //================================================================================================
        public bool Validate(RecordLabel a)
        {
            var error = "";

            if (a.Name == null || a.Name == string.Empty)
            {
                error += "Record label doesn't have a name.\n";
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
        public RecordLabel RecordLabel
        {
            get { return _recordLabel; }
            set
            {
                _recordLabel = value;
                OnPropertyChanged("RecordLabel");
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

        private RecordLabelDAO _recordLabelDAO;

        private RecordLabel _recordLabel;
        private string _operation;
    }
}