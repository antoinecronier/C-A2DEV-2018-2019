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
            this.Game = new Game();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void SetupMapForAi(List<Ship> ships)
        {
            Random rand = new Random();

            int x = rand.Next(0,(int)this.Game.Width);
            int y = rand.Next(0, (int)this.Game.Height);
            int direction = rand.Next(1, 4);

            Player ai = new Player("IA", PlayerType.AI);
            this.Game.Players.Add(ai);

            foreach (var item in ships)
            {
                while (!this.CheckCoordinateForShip(y, x, (Direction)direction, item, ai))
                {
                    x = rand.Next(0, (int)this.Game.Width);
                    y = rand.Next(0, (int)this.Game.Height);
                    direction = rand.Next(1, 4);
                }

                this.SetShip(y, x, (Direction)direction, item, ai);
            }
        }

        public Boolean CheckCoordinateForShip(int y, int x, Direction direction, Ship currentSelection, Player player)
        {
            Boolean result = true;

            foreach (var ship in this.Game.Players.Single(p => p == player).Ships)
            {
                foreach (var cell in ship.Cells)
                {
                    for (int i = 0; i < currentSelection.Width; i++)
                    {
                        for (int j = 0; j < currentSelection.Height; j++)
                        {
                            switch (direction)
                            {
                                case Direction.TOP:
                                    if (x + i <= 0 || y + j <= 0 || (cell.X == x + j && cell.Y == y + j))
                                    {
                                        result = false;
                                        break;
                                    }
                                    break;
                                case Direction.BOTTOM:
                                    if (x + i > this.Game.Width || y + j > this.Game.Height || (cell.X == x + j && cell.Y == y + j))
                                    {
                                        result = false;
                                        break;
                                    }
                                    break;
                                case Direction.RIGHT:
                                    if (x + i > this.Game.Width || y + j > this.Game.Height || (cell.X == x + j && cell.Y == y + j))
                                    {
                                        result = false;
                                        break;
                                    }
                                    break;
                                case Direction.LEFT:
                                    if (x + i <= 0 || y + j <= 0 || (cell.X == x + j && cell.Y == y + j))
                                    {
                                        result = false;
                                        break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (!result)
                        {
                            break;
                        }
                    }
                    if (!result)
                    {
                        break;
                    }
                }
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        public void SetShip(int y, int x, Direction direction, Ship currentSelection, Player player)
        {
            for (int i = 0; i < currentSelection.Height; i++)
            {
                for (int j = 0; j < currentSelection.Width; j++)
                {
                    currentSelection.Cells.Add(new Cell(i,j,State.SHIP));
                }
            }
            this.Game.Players.Single(p => p == player).Ships.Add(currentSelection);
        }

        public State Fire(int y, int x, Player player)
        {
            State result = State.WATER;
            Boolean isFound = false;
            Cell firedCell = new Cell(x, y, State.FIRED_WATER);

            if (this.Game.Players.Single(p => p == player).FiredCells.FindAll(c => c.X == x && c.Y == y).Count > 0)
            {
                result = State.RETRY;
            }
            else
            {
                this.Game.Players.Single(p => p == player).FiredCells.Add(firedCell);
            }

            if (result != State.RETRY)
            {
                foreach (var ship in this.Game.Players.Single(p => p != player).Ships)
                {
                    foreach (var cell in ship.Cells)
                    {
                        if (cell.X == x && cell.Y == y)
                        {
                            result = State.FIRED_SHIP;
                            firedCell.State = State.FIRED_SHIP;
                            cell.State = State.FIRED_SHIP;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }
                }

                if (!isFound)
                {
                    result = State.FIRED_WATER;
                }
            }

            return result;
        }

        public void PlayOthers(Player player)
        {
            Random rand = new Random();

            foreach (var item in this.Game.Players.FindAll(p => p != player))
            {
                int x = rand.Next(0, (int)this.Game.Width);
                int y = rand.Next(0, (int)this.Game.Height);

                while (Fire(y, x, item) == State.RETRY)
                {
                    x = rand.Next(0, (int)this.Game.Width);
                    y = rand.Next(0, (int)this.Game.Height);
                }
            }
        }

        public Boolean CheckGameEnded(Player player)
        {
            Boolean result = true;

            foreach (var item in this.Game.Players.FindAll(p => p != player))
            {
                foreach (var ship in item.Ships)
                {
                    if (ship.IsAlive)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public Boolean CheckGameLoosed(Player player)
        {
            Boolean result = true;

            foreach (var ship in player.Ships)
            {
                if (ship.IsAlive)
                {
                    result = false;
                }
            }

            return result;
        }
        #endregion

        #region Events
        #endregion
    }
}
