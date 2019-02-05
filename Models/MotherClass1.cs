using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public abstract class MotherClass1
    {

        #region StaticVariables
        #endregion

        #region Constants
        public const String ITEM_TO_PRINT = "coucou";
        #endregion

        #region Variables
        private String test1;
        public String test2;
        #endregion

        #region Attributs
        private int count;
        protected String data;
        private String firstname;
        private String lastname;
        #endregion

        #region Properties
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

        #region Constructors

        public MotherClass1(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void F1(String a, String b)
        {

        }

        public virtual void F2()
        {
            System.Console.WriteLine("MotherClass1");
        }

        public abstract void F3();
        #endregion

        #region Events
        #endregion


    }
}
