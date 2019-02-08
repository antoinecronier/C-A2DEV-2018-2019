using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Database.BaseEntity;

namespace WpfApp2.Models
{
    public class Game : DatabaseEntity
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private List<Player> players;
        private uint width;
        private uint height;
        private List<Ship> ships;
        #endregion

        #region Properties
        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public uint Height
        {
            get { return height; }
            set { height = value; }
        }

        public uint Width
        {
            get { return width; }
            set { width = value; }
        }

        public List<Ship> Ships
        {
            get { return ships; }
            set { ships = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Game()
        {
            this.Players = new List<Player>();
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
