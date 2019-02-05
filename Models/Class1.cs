using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Class1
    {
        #region StaticVariables
        public static String maData = "toto";
        #endregion

        #region Constants
        public const String MA_DATA = "tata";
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private long id;
        private String data;
        #endregion

        #region Properties
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class1()
        {

        }

        public Class1(string data)
        {
            this.data = data;
        }

        public Class1(long id, string data)
        {
            this.id = id;
            this.data = data;
        }
        #endregion

        #region StaticFunctions
        public static void MaFonction2()
        {
        }
        #endregion

        #region Functions
        public void MaFonction()
        {
            this.Id = 12;
        }
        #endregion

        #region Events
        #endregion
    }
}
