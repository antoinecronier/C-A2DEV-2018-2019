using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Database.BaseEntity;

namespace WpfApp2.Models
{
    public class Ship : DatabaseEntity
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private List<Cell> cells;
        private uint width;
        private uint height;
        private String name;
        #endregion

        #region Properties
        public uint Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        public uint Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }

        public List<Cell> Cells
        {
            get { return cells; }
            set
            {
                cells = value;
                OnPropertyChanged("Cells");
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public Boolean IsAlive
        {
            get
            {
                Boolean result = false;
                foreach (var item in this.Cells)
                {
                    if (item.State == State.SHIP)
                    {
                        result = true;
                        break;
                    }
                }
                return result;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ship()
        {
            this.Cells = new List<Cell>();
        }

        public Ship(uint width, uint height, string name) : this()
        {
            this.Width = width;
            this.Height = height;
            this.Name = name;
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
