using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Class2
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private long id;
        private String data;
        private List<Class1> class1s;
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

        public List<Class1> Class1s
        {
            get { return class1s; }
            set { class1s = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class2()
        {

        }

        public Class2(string data)
        {
            this.data = data;
        }

        public Class2(long id, string data)
        {
            this.id = id;
            this.data = data;
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
