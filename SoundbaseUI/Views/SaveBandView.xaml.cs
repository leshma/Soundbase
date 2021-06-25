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
    /// Interaction logic for SaveBandView.xaml
    /// </summary>
    public partial class SaveBandView : UserControl
    {
        public SaveBandView()
        {
            InitializeComponent();
        }

        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Artist> mySelectedItems = new List<Artist>();

            foreach (Artist item in ArtistListView.SelectedItems)
            {
                mySelectedItems.Add(item);
            }

            ((SaveBandViewModel)DataContext).SelectedArtists = mySelectedItems;
        }
    }
}
