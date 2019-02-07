using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using WpfApp2.Models;
using WpfApp2.UserControls;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int mapWidth;
        private int mapHeight;
        private Account account;
        #endregion

        #region Properties
        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public int MapWidth
        {
            get { return mapWidth; }
            set
            {
                mapWidth = value;
                ResizeMap();
            }
        }

        public int MapHeight
        {
            get { return mapHeight; }
            set
            {
                mapHeight = value;
                ResizeMap();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Page1()
        {
            InitializeComponent();
            this.DataContext = this;
            this.account = new Account();
            this.account.Firstname = "toto";
            this.account.Lastname = "test";
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void ResizeMap()
        {
            this.gameGrid.Children.Clear();
            this.gameGrid.ColumnDefinitions.Clear();
            this.gameGrid.RowDefinitions.Clear();

            for (int i = 0; i < this.MapHeight; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                this.gameGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < this.MapWidth; i++)
            {
                RowDefinition row = new RowDefinition();
                this.gameGrid.RowDefinitions.Add(row);
            }

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.MapHeight; i++)
                {
                    for (int j = 0; j < this.MapWidth; j++)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            UserControl1 uc1 = new UserControl1();
                            uc1.X = i;
                            uc1.Y = j;
                            
                            Grid.SetColumn(uc1, i);
                            Grid.SetRow(uc1, j);

                            this.gameGrid.Children.Add(uc1);
                        }));
                    }
                }
            });
        }
        #endregion

        #region Events
        #endregion
    }
}
