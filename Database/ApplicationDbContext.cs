using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Database.DTO;
using WpfApp2.Models;

namespace WpfApp2.Database
{
    public class ApplicationDbContext : DbContext
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private DbSet<Class1Dto> class1Dtos;
        #endregion

        #region Properties
        public DbSet<Class1Dto> Class1DtoDbSet
        {
            get { return class1Dtos; }
            set { class1Dtos = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApplicationDbContext()
        {

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
