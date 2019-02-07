using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.Models;
using WpfApp2.Views;

namespace WpfApp2.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl, INotifyPropertyChanged
    {
        #region Attributs
        private int mapWidth;
        private int mapHeight;
        private Account account;
        #endregion

        #region Properties
        public Account Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        public int MapWidth
        {
            get { return mapWidth; }
            set
            {
                mapWidth = value;
                OnPropertyChanged("MapWidth");
                ((this.Parent as Grid).Parent as Page1).ResizeMap();
            }
        }

        public int MapHeight
        {
            get { return mapHeight; }
            set
            {
                mapHeight = value;
                OnPropertyChanged("MapHeight");
                ((this.Parent as Grid).Parent as Page1).ResizeMap();
            }
        }
        #endregion

        public UserControl2()
        {
            InitializeComponent();
        }

        #region Property changed implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
