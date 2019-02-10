using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.Utils;
using WpfApp2.ViewModels;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class GamePage : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private GameViewModel gameViewModel;
        private Player player;
        #endregion

        #region Properties
        public GameViewModel GameViewModel
        {
            get { return gameViewModel; }
            set { gameViewModel = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GamePage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void InitGame(Player player)
        {
            this.Player = player;
            this.CreateGrid(player, this.gameGridP1);
            this.CreateGrid(this.GameViewModel.Game.Players.Single(p => p != player), this.gameGridP2);
        }

        public void CreateGrid(Player player, Grid grid)
        {
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            for (int i = 0; i < this.GameViewModel.Game.Width; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < this.GameViewModel.Game.Height; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < this.GameViewModel.Game.Width; i++)
            {
                for (int j = 0; j < this.GameViewModel.Game.Height; j++)
                {
                    CellUserControl cellUc = new CellUserControl();
                    cellUc.X = j;
                    cellUc.Y = i;

                    cellUc.CellButton.Click += CellButton_Click;

                    Grid.SetRow(cellUc, i);
                    Grid.SetColumn(cellUc, j);

                    foreach (var ship in this.GameViewModel.Game.Players.Single(p => p == player).Ships)
                    {
                        foreach (var cell in ship.Cells)
                        {
                            if (cell.X == j && cell.Y == i)
                            {
                                cellUc.ImagePath = ImageByState.GetImage(State.SHIP);
                            }
                        }
                    }

                    grid.Children.Add(cellUc);
                }
            }
        }
        #endregion

        #region Events
        private void CellButton_Click(object sender, RoutedEventArgs e)
        {
            CellUserControl cellUc = ((e.Source as Button).Parent as CellUserControl);

            State state = this.GameViewModel.Fire(cellUc.Y,cellUc.X,this.Player);

            if (state != State.RETRY)
            {
                switch (state)
                {
                    case State.FIRED_SHIP:
                        cellUc.ImagePath = "";
                        break;
                    case State.FIRED_WATER:
                        cellUc.ImagePath = "";
                        break;
                    default:
                        break;
                }

                if (this.GameViewModel.CheckGameEnded(this.Player))
                {
                    MessageBox.Show("Game Winned");
                    SetupGamePage page = new SetupGamePage();
                    (this.Parent as Window).Content = page;
                }

                this.GameViewModel.PlayOthers(this.Player);

                if (this.GameViewModel.CheckGameLoosed(this.Player))
                {
                    MessageBox.Show("Game Loosed");
                    SetupGamePage page = new SetupGamePage();
                    (this.Parent as Window).Content = page;
                }
            }
        }
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Content = new SetupGamePage();
        }
    }
}
