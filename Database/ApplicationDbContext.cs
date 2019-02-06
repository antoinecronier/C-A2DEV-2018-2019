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
        private DbSet<Class2Dto> class2Dtos;
        #endregion

        #region Properties
        public DbSet<Class1Dto> Class1DtoDbSet
        {
            get { return class1Dtos; }
            set { class1Dtos = value; }
        }

        public DbSet<Class2Dto> Class2DtoDbSet
        {
            get { return class2Dtos; }
            set { class2Dtos = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApplicationDbContext()
        {
            DevResetDatabase();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void DevResetDatabase()
        {
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.Create();
            }
        }
        #endregion

        #region Events
        #endregion


    }
}
