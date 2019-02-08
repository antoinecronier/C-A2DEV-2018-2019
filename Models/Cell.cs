using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Database.BaseEntity;

namespace WpfApp2.Models
{
    public class Cell : DatabaseEntity
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int x;
        private int y;
        private State state;
        #endregion

        #region Properties
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cell()
        {

        }

        public Cell(int x, int y, State state) : this()
        {
            this.X = x;
            this.Y = y;
            this.State = state;
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
