using Soundbase;
using SoundbaseUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoundbaseUI.Views
{
    /// <summary>
    /// Interaction logic for SaveSongView.xaml
    /// </summary>
    public partial class SaveSongView : UserControl
    {
        public SaveSongView()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            List<Engineer> engineers = new List<Engineer>();
            List<Writer> writers = new List<Writer>();
            List<Genre> genres = new List<Genre>();
            List<Composer> composers = new List<Composer>();

            foreach (Engineer item in EngineersList.SelectedItems)
            {
                engineers.Add(item);
            }

            foreach (Writer item in WritersList.SelectedItems)
            {
                writers.Add(item);
            }

            foreach (Genre item in GenresList.SelectedItems)
            {
                genres.Add(item);
            }

            foreach (Composer item in ComposersList.SelectedItems)
            {
                composers.Add(item);
            }

            ((SaveSongViewModel)DataContext).SelectedEngineers = engineers;
            ((SaveSongViewModel)DataContext).SelectedWriters = writers;
            ((SaveSongViewModel)DataContext).SelectedGenres = genres;
            ((SaveSongViewModel)DataContext).SelectedComposers = composers;
        }
    }
}
