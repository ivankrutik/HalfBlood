//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 01.10.2013 14:54:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Learning
{

    /// <summary>
    /// There are no comments for Learning.Student, Learning in the schema.
    /// </summary>
    public partial class Student {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for Student constructor in the schema.
        /// </summary>
        public Student()
        {
            this.TermPapers = new List<TermPaper>();
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Group in the schema.
        /// </summary>
        public virtual Group Group
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TermPapers in the schema.
        /// </summary>
        public virtual IList<TermPaper> TermPapers
        {
            get;
            set;
        }
    }

}
