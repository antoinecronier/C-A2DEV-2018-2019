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
using WpfApp2.Models;

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

            for (int i = 0; i < this.MapHeight; i++)
            {
                for (int j = 0; j < this.MapWidth; j++)
                {
                    Button btn = new Button();
                    btn.Content = "H:" + i + "W:" + j;
                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, j);
                    this.gameGrid.Children.Add(btn);
                }
            }
        }
        #endregion

        #region Events
        #endregion
    }
}
