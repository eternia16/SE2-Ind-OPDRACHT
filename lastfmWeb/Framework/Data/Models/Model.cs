using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleHandler.Framework.Data.Models
{
    /// <summary>
    /// Model class. Has to be extended by model classes.
    /// </summary>
    public class Model : IModel
    {
        //public int ID { get; set; }

        #region IModel Members

        //imply methods of IModel.

        #endregion

        /// <summary>
        /// Static method to get the name of the table binded to the model.
        /// </summary>
        /// <param name="type">Type of the model class</param>
        /// <returns>Table name in a string</returns>
        public static string GetModelAttribute(Type type)
        {
            return type
                .GetCustomAttributes(true)
                .Cast<ModelAttribute>()
                .ToArray()[0]
                .tableName;
        }

        /// <summary>
        /// Method to get the name of the table binded to the model.
        /// </summary>
        /// <returns>Table name in a string</returns>
        public string GetModelAttribute()
        {
            return this.GetType()
                .GetCustomAttributes(true)
                .Cast<ModelAttribute>()
                .ToArray()[0]
                .tableName;
        }
    }
}
