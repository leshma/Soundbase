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
    public class ArtworksProcedureViewModel : BindableBase
    {
        public ArtworksProcedureViewModel()
        {
            CmdExecuteProcedure = new RelayCommand(ExecuteProcedure);

            _artworkDAO = new ArtworkDAO();
            Artworks = new ObservableCollection<GetArtworksWithSameFormat_Result1>();
            Format = "";
        }

        public void ExecuteProcedure() 
        {
            Artworks = new ObservableCollection<GetArtworksWithSameFormat_Result1>(_artworkDAO.GetArtworksWithSameFormat(Format));
        }

        public RelayCommand CmdExecuteProcedure { get; set; }

        public ObservableCollection<GetArtworksWithSameFormat_Result1> Artworks
        {
            get { return _artworks; }
            set
            {
                _artworks = value;
                OnPropertyChanged("Artworks");
            }
        }

        public string Format
        {
            get { return _format; }
            set 
            { 
                _format = value;
                OnPropertyChanged("Format");
            }
        }

        private ArtworkDAO _artworkDAO;
        private string _format;
        private ObservableCollection<GetArtworksWithSameFormat_Result1> _artworks;
    }
}
