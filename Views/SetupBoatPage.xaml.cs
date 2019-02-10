using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.Entity;
using WpfApp2.Models;
using WpfApp2.UserControls;
using WpfApp2.Utils;
using WpfApp2.ViewModels;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour SetupBoatPage.xaml
    /// </summary>
    public partial class SetupBoatPage : Page
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private List<ShipConfig> shipConfigs;
        private uint mapWidth;
        private uint mapHeight;
        private Player player;
        private ObservableCollection<Ship> ships;
        private Ship currentSelection;
        private GameViewModel gameViewModel;
        private CellUserControl lastCellClicked;
        #endregion

        #region Properties
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        
        public uint MapHeight
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }
        
        public uint MapWidth
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }
        
        public List<ShipConfig> ShipConfigs
        {
            get { return shipConfigs; }
            set { shipConfigs = value; }
        }

        public ObservableCollection<Ship> Ships
        {
            get { return ships; }
            set { ships = value; }
        }

        public Ship CurrentSelection
        {
            get { return currentSelection; }
            set { currentSelection = value; }
        }

        public GameViewModel GameViewModel
        {
            get { return gameViewModel; }
            set { gameViewModel = value; }
        }

        public CellUserControl LastCellClicked
        {
            get { return lastCellClicked; }
            set { lastCellClicked = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SetupBoatPage()
        {
            InitializeComponent();

            this.GameViewModel = new GameViewModel();

            this.Ships = new ObservableCollection<Ship>();
            this.shipList.ItemsSource = this.Ships;
            this.shipList.SelectionChanged += ShipList_SelectionChanged;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void CreateGrid(List<ShipConfig> shipsConfig, uint mapWidth, uint mapHeight, Player player)
        {
            this.Player = player;

            this.GameViewModel.Game.Width = mapWidth;
            this.GameViewModel.Game.Height = mapHeight;

            this.GameViewModel.Game.Players.Add(player);

            this.ShipConfigs = shipsConfig;

            foreach (var item in shipsConfig)
            {
                for (int i = 0; i < item.ShipNb; i++)
                {
                    this.Ships.Add(new Ship(item.Ship.Width, item.Ship.Height, item.Ship.Name));
                }
            }

            this.mapGrid.ColumnDefinitions.Clear();
            this.mapGrid.RowDefinitions.Clear();

            for (int i = 0; i < mapWidth; i++)
            {
                this.mapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < mapHeight; i++)
            {
                this.mapGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    CellUserControl cellUc = new CellUserControl();
                    cellUc.X = i;
                    cellUc.Y = j;

                    cellUc.CellButton.Click += CellButton_Click;

                    Grid.SetRow(cellUc,i);
                    Grid.SetColumn(cellUc, j);

                    this.mapGrid.Children.Add(cellUc);
                }
            }
        }
        #endregion

        #region Events
        private void CellButton_Click(object sender, RoutedEventArgs e)
        {
            CellUserControl cellUc = ((e.Source as Button).Parent as CellUserControl);

            if (this.CurrentSelection != null)
            {
                if (this.LastCellClicked != null)
                {
                    Direction direction = Direction.NONE;
                    if (cellUc.X == this.LastCellClicked.X && cellUc.Y > this.LastCellClicked.Y)
                    {
                        direction = Direction.BOTTOM;
                    }
                    else if (cellUc.X == this.LastCellClicked.X && cellUc.Y < this.LastCellClicked.Y)
                    {
                        direction = Direction.TOP;
                    }
                    else if (cellUc.Y == this.LastCellClicked.Y && cellUc.X > this.LastCellClicked.X)
                    {
                        direction = Direction.RIGHT;
                    }
                    else if (cellUc.Y == this.LastCellClicked.Y && cellUc.X < this.LastCellClicked.X)
                    {
                        direction = Direction.LEFT;
                    }
                    else
                    {
                        this.LastCellClicked.ImagePath = ImageByState.GetImage(State.RETRY);
                        this.LastCellClicked = null;
                    }

                    if (this.LastCellClicked != null && this.GameViewModel.CheckCoordinateForShip(this.LastCellClicked.Y, this.LastCellClicked.X, direction, this.CurrentSelection, this.Player))
                    {
                        this.GameViewModel.SetShip(this.LastCellClicked.Y, this.LastCellClicked.X, direction, this.CurrentSelection, this.Player);
                        PrintShip(direction, this.LastCellClicked.X, this.LastCellClicked.Y, this.CurrentSelection.Height, this.CurrentSelection.Width);
                        
                        this.Ships.Remove(this.CurrentSelection);

                        if (this.Ships.Count <= 0)
                        {
                            List<Ship> ships = new List<Ship>();
                            foreach (var item in ShipConfigs)
                            {
                                for (int i = 0; i < item.ShipNb; i++)
                                {
                                    ships.Add(item.Ship);
                                }
                            }

                            this.GameViewModel.SetupMapForAi(ships);

                            GamePage page = new GamePage();
                            page.GameViewModel = this.GameViewModel;
                            page.InitGame(this.Player);
                            (this.Parent as Window).Content = page;
                        }
                    }

                    if (this.LastCellClicked != null)
                    {
                        this.LastCellClicked.ImagePath = ImageByState.GetImage(State.RETRY);
                        this.LastCellClicked = null;
                    }
                }
                else
                {
                    this.LastCellClicked = cellUc;
                    cellUc.ImagePath = ImageByState.GetImage(State.SHIP);
                }
            }
        }

        private void PrintShip(Direction direction, int width, int height, uint mapHeight, uint mapWidth)
        {
            switch (direction)
            {
                case Direction.TOP:

                    foreach (var item in this.mapGrid.Children)
                    {
                        for (int j = width; j < width + mapHeight; j++)
                        {
                            for (int i = height; i > height - mapWidth; i--)
                            {
                                if ((item as CellUserControl).Y == i && (item as CellUserControl).X == j)
                                {
                                    (item as CellUserControl).ImagePath = ImageByState.GetImage(State.SHIP);
                                }
                            }
                        }
                    }
                    break;
                case Direction.BOTTOM:

                    foreach (var item in this.mapGrid.Children)
                    {
                        for (int j = width; j < width + mapHeight; j++)
                        {
                            for (int i = height; i < height + mapWidth; i++)
                            {
                                if ((item as CellUserControl).Y == i && (item as CellUserControl).X == j)
                                {
                                    (item as CellUserControl).ImagePath = ImageByState.GetImage(State.SHIP);
                                }
                            }
                        }
                    }
                    break;
                case Direction.RIGHT:

                    foreach (var item in this.mapGrid.Children)
                    {
                        for (int j = width; j < width + mapWidth; j++)
                        {
                            for (int i = height; i < height + mapHeight; i++)
                            {
                                if ((item as CellUserControl).Y == i && (item as CellUserControl).X == j)
                                {
                                    (item as CellUserControl).ImagePath = ImageByState.GetImage(State.SHIP);
                                }
                            }
                        }
                    }
                    break;
                case Direction.LEFT:

                    foreach (var item in this.mapGrid.Children)
                    {
                        for (int j = width; j > width - mapWidth; j--)
                        {
                            for (int i = height; i < height + mapHeight; i++)
                            {
                                if ((item as CellUserControl).Y == i && (item as CellUserControl).X == j)
                                {
                                    (item as CellUserControl).ImagePath = ImageByState.GetImage(State.SHIP);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SetupGamePage setupGame = new SetupGamePage();
            setupGame.LoadConfiguration(this.ShipConfigs,this.MapWidth, this.MapHeight, this.Player);

            (this.Parent as Window).Content = setupGame;
        }

        private void ShipList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.CurrentSelection = e.AddedItems[0] as Ship;
            }
            else
            {
                this.CurrentSelection = null;
            }
        }
        #endregion
    }
}
