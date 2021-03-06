using SoundbaseUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundbaseUI.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        public MenuViewModel()
        {
            CmdSwitchView = new RelayCommand<string>(ChangeView);
            Title = "Choose an option on the left";
        }

        //=================================================================================================
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public RelayCommand<string> CmdSwitchView { get; set; }

        public void ChangeView(string view)
        {
            switch(view.ToLower())
            {
                case "albums":

                    CurrentViewModel = new AlbumsViewModel();
                    Title = "Albums";
                    break;

                case "artists":

                    CurrentViewModel = new ArtistsViewModel();
                    Title = "Artists";
                    break;

                case "artworks":

                    CurrentViewModel = new ArtworksViewModel();
                    Title = "Artworks";
                    break;

                case "artworksprocedure":

                    CurrentViewModel = new ArtworksProcedureViewModel();
                    Title = "Artworks procedure";
                    break;

                case "bands":

                    CurrentViewModel = new BandsViewModel();
                    Title = "Bands";
                    break;

                case "composers":

                    CurrentViewModel = new ComposersViewModel();
                    Title = "Composers";
                    break;

                case "creations":

                    CurrentViewModel = new CreationsViewModel();
                    Title = "Creations";
                    break;

                case "mixingengineers":

                    CurrentViewModel = new MixingEngineersViewModel();
                    Title = "Mixing Engineers";
                    break;

                case "recordingengineers":

                    CurrentViewModel = new RecordingEngineersViewModel();
                    Title = "Recording Engineers";
                    break;

                case "genres":

                    CurrentViewModel = new GenresViewModel();
                    Title = "Genres";
                    break;

                case "officialvideos":

                    CurrentViewModel = new OfficialVideosViewModel();
                    Title = "Official videos";
                    break;

                case "performances":

                    CurrentViewModel = new PerformancesViewModel();
                    Title = "Performances";
                    break;

                case "recordlabels":

                    CurrentViewModel = new RecordLabelsViewModel();
                    Title = "Record labels";
                    break;

                case "songs":

                    CurrentViewModel = new SongsViewModel();
                    Title = "Songs";
                    break;

                case "writers":

                    CurrentViewModel = new WritersViewModel();
                    Title = "Writers";
                    break;
            }
        }

        //=================================================================================================
        private BindableBase _currentViewModel;
        private string _title;
    }
}
