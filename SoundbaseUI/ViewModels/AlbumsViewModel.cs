using Soundbase;
using Soundbase.DAO;
using SoundbaseUI.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundbaseUI.ViewModels
{
    public class AlbumsViewModel : BindableBase
    {
        public AlbumsViewModel()
        {
            _albumDAO = new AlbumDAO();
            Albums = new ObservableCollection<Album>(_albumDAO.GetList());
        }

        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set
            {
                _albums = value;
                OnPropertyChanged("Albums");
            }
        }

        private AlbumDAO _albumDAO;
        private ObservableCollection<Album> _albums;
    }
}
