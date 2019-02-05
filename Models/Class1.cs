using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Class1 : MotherClass1, Interface1
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
        private new String data;
        #endregion

        #region Properties
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public new String Data
        {
            get { return data; }
            set { data = value; }
        }

        public int MyProperty { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Class1() : base("toto","tata")
        {
        }

        public Class1(string data) : base(data, data)
        {
            this.data = data;
        }

        public Class1(long id, string data) : this()
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
            this.data = "test";
            this.test2 = "";
            base.test2 = "";
            //this.test1 = "10";
            this.F2();
            //this.F1();
        }

        public override void F2()
        {
            base.F2();
        }

        public override void F3()
        {
        }

        public void F4()
        {
            throw new NotImplementedException();
        }

        public bool F5()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Events
        #endregion
    }
}
