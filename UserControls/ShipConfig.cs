using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.UserControls
{
    public class ShipConfig : INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private Ship ship = new Ship();
        private uint shipNb;
        #endregion

        #region Properties
        public Ship Ship
        {
            get { return ship; }
            set
            {
                ship = value;
                OnPropertyChanged("Ship");
            }
        }

        public uint ShipNb
        {
            get { return shipNb; }
            set
            {
                shipNb = value;
                OnPropertyChanged("ShipNb");
            }
        }

        public String ShipWidthTxt
        {
            get { return this.Ship.Name + " Width"; }
        }

        public String ShipHeightTxt
        {
            get { return this.Ship.Name + " Height"; }
        }

        public String ShipNbTxt
        {
            get { return this.Ship.Name + " Number"; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ShipConfig()
        {
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
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
