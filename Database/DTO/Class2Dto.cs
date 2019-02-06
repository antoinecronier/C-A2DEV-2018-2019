using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp2.Database.DTO
{
    public class Class2Dto
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
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class2Dto()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            return "id:" + this.Id + " " + "data:" + this.Data;
        }
        #endregion

        #region Events
        #endregion
    }
}