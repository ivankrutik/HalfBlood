//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 06.09.2013 12:09:31
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

namespace Learning
{

    /// <summary>
    /// There are no comments for Figure in the schema.
    /// </summary>
    public partial class Figure {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for Figure constructor in the schema.
        /// </summary>
        public Figure()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for RN in the schema.
        /// </summary>
        public virtual int RN
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Code in the schema.
        /// </summary>
        public virtual string Code
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BType in the schema.
        /// </summary>
        public virtual string BType
        {
            get;
            set;
        }
    }

}
