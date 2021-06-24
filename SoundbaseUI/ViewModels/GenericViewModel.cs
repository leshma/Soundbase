using Soundbase.DAO.Base;
using SoundbaseUI.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundbaseUI.ViewModels
{
    public abstract class GenericViewModel<TElement> : BindableBase
    {
        public GenericViewModel(IRepository<TElement> repository)
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            CmdRemoveSelected = new RelayCommand(RemoveSelected);

            _DAO = repository;

            Elements = new ObservableCollection<TElement>(repository.GetList());
        }

        //================================================================================================
        public RelayCommand<string> CmdSwitchView { get; set; }

        public RelayCommand CmdRemoveSelected { get; set; }

        public abstract void ChangeView(string view);

        public abstract void RemoveSelected();

        //================================================================================================
        public ObservableCollection<TElement> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }

        public TElement SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                OnPropertyChanged("SelectedElement");
            }
        }

        //================================================================================================
        protected IRepository<TElement> _DAO;

        private ObservableCollection<TElement> _elements;
        private TElement _selectedElement;
    }
}
