using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        private String arrayDump;
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

        [NotMapped]
        public int[] IntArray
        {
            get { return intArray; }
            set
            {
                intArray = value;
                String dataTranslation = "";
                int i = 0;
                for (; i < IntArray.Length; i++)
                {
                    dataTranslation += IntArray.ElementAt(i) + ",";
                }
                dataTranslation += "";
                this.ArrayDump = dataTranslation;
            }
        }

        public List<Class2Dto> Class2Dtos
        {
            get { return class2Dtos; }
            set { class2Dtos = value; }
        }

        public String ArrayDump
        {
            get
            {
                int[] array = new int[this.arrayDump.Split(',').Length];
                int i = 0;
                foreach (var item in this.arrayDump.Split(','))
                {
                    array[i] = int.Parse(item);
                    i++;
                }
                this.IntArray = array;
                return arrayDump;
            }
            set { arrayDump = value; }
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
