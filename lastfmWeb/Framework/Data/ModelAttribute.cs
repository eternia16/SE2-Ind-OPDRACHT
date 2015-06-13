namespace OracleHandler.Framework.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ModelAttribute. Binds table name to a model class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// Table name
        /// </summary>
        private string _tableName;

        /// <summary>
        /// Public property to get a table name.
        /// </summary>
        public string tableName
        {
            get
            {
                return this._tableName;
            }
        }

        /// <summary>
        /// Public constructor. Sets the name
        /// </summary>
        /// <param name="tableName">Table name</param>
        public ModelAttribute(string tableName)
        {
            this._tableName = tableName;
        }

        /// <summary>
        /// ToString override to get the table name.
        /// </summary>
        /// <returns>Table name in a string</returns>
        public override string ToString()
        {
            return this.tableName;
        }          
    }
}