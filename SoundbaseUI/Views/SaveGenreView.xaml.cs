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
    /// Interaction logic for SaveGenreView.xaml
    /// </summary>
    public partial class SaveGenreView : UserControl
    {
        public SaveGenreView()
        {
            InitializeComponent();
        }

        private void SubgenresListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Genre> mySelectedItems = new List<Genre>();

            foreach (Genre item in SubgenresListView.SelectedItems)
            {
                mySelectedItems.Add(item);
            }

            ((SaveGenreViewModel)DataContext).Genre.Subgenres = mySelectedItems;
        }
    }
}
