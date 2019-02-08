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
using WpfApp2.UserControls;

namespace WpfApp2.Views
{
    /// <summary>
    /// Logique d'interaction pour SetupGamePage.xaml
    /// </summary>
    public partial class SetupGamePage : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private uint mapWidth;
        private uint mapHeight;
        private String playerName;
        private ShipConfig corvette = new ShipConfig();
        private ShipConfig destroyer = new ShipConfig();
        private ShipConfig cruser = new ShipConfig();
        private ShipConfig airportShip = new ShipConfig();
        #endregion

        #region Properties
        public String PlayerName
        {
            get { return playerName; }
            set
            {
                playerName = value;
                OnPropertyChanged("PlayerName");
            }
        }

        public uint MapHeight
        {
            get { return mapHeight; }
            set
            {
                mapHeight = value;
                OnPropertyChanged("MapHeight");
            }
        }

        public uint MapWidth
        {
            get { return mapWidth; }
            set
            {
                mapWidth = value;
                OnPropertyChanged("MapWidth");
            }
        }

        public ShipConfig Corvette
        {
            get { return corvette; }
            set
            {
                corvette = value;
                OnPropertyChanged("Corvette");
            }
        }

        public ShipConfig Destroyer
        {
            get { return destroyer; }
            set
            {
                destroyer = value;
                OnPropertyChanged("Destroyer");
            }
        }

        public ShipConfig Cruser
        {
            get { return cruser; }
            set
            {
                cruser = value;
                OnPropertyChanged("Cruser");
            }
        }

        public ShipConfig AirportShip
        {
            get { return airportShip; }
            set
            {
                airportShip = value;
                OnPropertyChanged("AirportShip");
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SetupGamePage()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Corvette.Ship.Name = "Corvette";
            this.Destroyer.Ship.Name = "Destroyer";
            this.Cruser.Ship.Name = "Cruser";
            this.AirportShip.Ship.Name = "AirportShip";

            this.UCCorvette.ShipConfig = this.Corvette;
            this.UCDestroyer.ShipConfig = this.Destroyer;
            this.UCCruser.ShipConfig = this.Cruser;
            this.UCAirportShip.ShipConfig = this.AirportShip;
        }

        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void LoadConfiguration(List<ShipConfig> shipConfigs, uint mapWidth, uint mapHeight, string playerName)
        {
            this.UCCorvette.ShipConfig = shipConfigs.ElementAt(0);
            this.UCDestroyer.ShipConfig = shipConfigs.ElementAt(1);
            this.UCCruser.ShipConfig = shipConfigs.ElementAt(2);
            this.UCAirportShip.ShipConfig = shipConfigs.ElementAt(3);
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;
            this.PlayerName = playerName;
        }
        #endregion

        #region Events
        private void ValidateBtn_Click(object sender, RoutedEventArgs e)
        {
            List<ShipConfig> ships = new List<ShipConfig>() { Corvette, Destroyer, Cruser, AirportShip };

            SetupBoatPage setupBoat = new SetupBoatPage();
            setupBoat.CreateGrid(ships, this.MapWidth, this.MapHeight, this.PlayerName);

            (this.Parent as Window).Content = setupBoat;
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
    }
}
