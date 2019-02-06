using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Database.DTO
{
    public class Class1Dto
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
        private Boolean myBool;
        private int[] intArray;
        private List<Class2Dto> class2Dtos;
        #endregion

        #region Properties
        [Key]
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

        public Boolean MyBool
        {
            get { return myBool; }
            set { myBool = value; }
        }

        public int[] IntArray
        {
            get { return intArray; }
            set { intArray = value; }
        }

        public List<Class2Dto> Class2Dtos
        {
            get { return class2Dtos; }
            set { class2Dtos = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class1Dto()
        {
            this.Class2Dtos = new List<Class2Dto>();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            String result = "id:" + this.Id + " " + "data:" + this.Data + " " + "myBool:" + this.MyBool;

            if (this.IntArray != null)
            {
                result += " " + "intArray:[";
                foreach (var item in this.IntArray)
                {
                    result += item + ",";
                }
                result += "]";
            }

            if (this.Class2Dtos != null)
            {
                foreach (var item in this.Class2Dtos)
                {
                    result += " " + "class2Dto:\n   " + item.ToString();
                }
            }
            
            return result;
        }
        #endregion

        #region Events
        #endregion
    }
}
