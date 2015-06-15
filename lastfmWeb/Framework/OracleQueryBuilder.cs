using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.Oracle;
using System.Diagnostics;

namespace lastfmWeb.Framework
{
    /// <summary>
    /// Oracle Query Builder to build an OracleCommand with.
    /// </summary>
    public class OracleQueryBuilder
    {
        private OracleQuery query;

        /// <summary>
        /// Public constructor
        /// </summary>
        public OracleQueryBuilder() { }

        /// <summary>
        /// Public constructor. Sets an OracleQuery.
        /// </summary>
        /// <param name="query">OracleQuery</param>
        public OracleQueryBuilder(OracleQuery query)
        {
            this.query = query;
        }


        /// <summary>
        /// Creates an OracleCommand.
        /// </summary>
        /// <param name="con">Instance of an OracleConnection</param>
        /// <returns>OracleCommand</returns>
        public OracleCommand CreateCommand(OracleConnection con)
        {
            if (this.query != null)
            {
                Debug.WriteLine(this.query.GetQuery());

                if (this.query.ActionReady())
                    return new OracleCommand(this.query.GetQuery(), con);
                else
                    throw new Exception("Command is not action ready.");
            }
            else
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                return cmd;
            }
        }
        
    }
}
