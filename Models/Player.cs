using System.Collections.Generic;
using WpfApp2.Database.BaseEntity;

namespace WpfApp2.Models
{
    public class Player : DatabaseEntity
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private List<Ship> ships;
        private string name;
        private List<Cell> firedCells;
        private PlayerType playerType;
        #endregion

        #region Properties
        public List<Cell> FiredCells
        {
            get { return firedCells; }
            set { firedCells = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Ship> Ships
        {
            get { return ships; }
            set { ships = value; }
        }

        public PlayerType PlayerType
        {
            get { return playerType; }
            set { playerType = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Player()
        {
            this.FiredCells = new List<Cell>();
            this.Ships = new List<Ship>();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion


    }
}