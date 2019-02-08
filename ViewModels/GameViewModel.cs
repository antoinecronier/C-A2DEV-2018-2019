using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class GameViewModel
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private Game game;
        #endregion

        #region Properties
        public Game Game
        {
            get { return game; }
            set { game = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameViewModel()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void SetupMapForPlayers()
        {
            foreach (var item in this.Game.Players)
            {
                if (item.PlayerType == PlayerType.HUMAN)
                {
                    this.SetupMapForHumanPlayer(item);
                }
            }
        }

        private void SetupMapForHumanPlayer(Player player)
        {
            foreach (var item in this.Game.Ships)
            {
                this.SetupGraphicalShip(item);
            }
        }

        private void SetupGraphicalShip(Ship item)
        {
        }

        public Boolean CheckCoordinateForShip(int y, int x, System.Windows.Controls.ExpandDirection direction, Ship currentSelection, PlayerType playerType)
        {
            Boolean result = true;

            return result;
        }

        public void SetShip(int y, int x, ExpandDirection direction, Ship currentSelection, PlayerType hUMAN)
        {
        }
        #endregion

        #region Events
        #endregion
    }
}
