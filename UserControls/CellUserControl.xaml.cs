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

namespace WpfApp2.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class CellUserControl : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private BitmapImage imageSource;
        private int x;
        private int y;
        private String imagePath;

        /// <summary>
        /// "./Resources/1023.wav"
        /// </summary>
        private String soundPath;
        #endregion

        #region Properties
        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public String ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
                if (value == "")
                {
                    this.ImageSource = null;
                }
                else
                {
                    this.ImageSource = new BitmapImage(
                                new Uri("pack://application:,,,/WpfApp2;component/Resources/" + value));
                }
            }
        }

        public String SoundPath
        {
            get { return soundPath; }
            set { soundPath = value; }
        }

        public Button CellButton
        {
            get { return this.cellBtn; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CellUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        //private void Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(this.SoundPath);
        //    //player.Play();
        //    //MessageBox.Show("Button " + "X:" + this.X + " " + "Y:" + this.Y + "clicked");
        //}

        //private void Btn_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    this.ImagePath = "BB61_USS_Iowa_BB61_broadside_USN.jpg";
        //}

        //private void Btn_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    this.ImagePath = "battleship_003.jpg";
        //}
        #endregion

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
