using Devart.Data.Oracle;
using OracleHandler.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OracleHandler.Framework
{
    /// <summary>
    /// Context class to communicate with the database.
    /// </summary>
    public class DbContext
    {
        private OracleConnection connection = null;

        /// <summary>
        /// Public constructor to open a connection.
        /// </summary>
        public DbContext()
        {
            if (openConnection())
                Debug.WriteLine("Connection is open.");
            else
                Debug.WriteLine("Connection failed to open.");
        }


        /// <summary>
        /// Opens the actual connection
        /// </summary>
        /// <returns>True or false whether the connection is open and valid or not.</returns>
        bool openConnection()
        {
            connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OracleContextConnection"].ConnectionString);
            connection.Open();

            if (!connection.State.Equals(ConnectionState.Open))
            {
                Debug.WriteLine("Connection failed state: " + connection.State);
                return false;
            }
       

            Debug.WriteLine("Connection state: " + connection.State);
            return true;
        }


        /// <summary>
        ///  Closing the open connection.
        /// </summary>
        public void Close()
        {
            if (connection.State.Equals(ConnectionState.Open))
            {
                Debug.WriteLine("Closing connection...");
                connection.Close();

                if(connection.State.Equals(ConnectionState.Open))
                    Debug.WriteLine("Closing connection failed");
                else
                    Debug.WriteLine("Connection closed.");
            } else
                Debug.WriteLine("Closing connection failed");
        }


        /// <summary>
        /// Gets the connection
        /// </summary>
        /// <returns>Open OracleConnection</returns>
        protected OracleConnection GetConnection()
        {
            return this.connection;
        }


        /// <summary>
        /// Returns a created OracleQuery using objects only.
        /// </summary>
        /// <param name="obj">Model class. Either empty or with filled properties.</param>
        /// <returns>OracleQuery</returns>
        public OracleQuery GetObjectQuery(object obj)
        {
            if (this.GetConnection().Equals(null))
                Debug.WriteLine("Connection is null");

            OracleQuery query = new OracleQuery(OracleQuery.SELECT);
            query.Select("");
            query.From(((ModelAttribute)obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName);

            object valueUsedInForeach;

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                valueUsedInForeach = prop.GetValue(obj, null);
                if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                {
                    query.Where(prop.Name, "=", valueUsedInForeach);
                }

            }

            query.Rownum(1);
            Debug.WriteLine("Select query: " + query.GetQuery());
            return query;
        }


        /// <summary>
        /// Static variant to get an OracleQuery.
        /// </summary>
        /// <param name="obj">Model class. Either empty or with filled properties.</param>
        /// <param name="instance">Open OracleConnection instance.</param>
        /// <returns>OracleQuery</returns>
        public static OracleQuery GetObjectQuery(object obj, OracleConnection instance)
        {
            if (instance.Equals(null))
                Debug.WriteLine("Connection is null");

            OracleQuery query = new OracleQuery(OracleQuery.SELECT);
            query.Select("");
            query.From(((ModelAttribute)obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName);

            object valueUsedInForeach;

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                valueUsedInForeach = prop.GetValue(obj, null);

                if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                {
                    query.Where(prop.Name, "=", valueUsedInForeach);
                }

            }

            query.Rownum(1);
            Debug.WriteLine("Select query: " + query.GetQuery());
            return query;
        }


        /// <summary>
        /// Gets the OracleQuery with the possibility of the whereclause.
        /// </summary>
        /// <param name="obj">Model class</param>
        /// <param name="noWhereClause">Using where clause, true or false. Default is false.</param>
        /// <returns>OracleQuery</returns>
        public OracleQuery GetObjectsQuery(object obj, bool noWhereClause = false)
        {
            if (this.GetConnection().Equals(null))
                Debug.WriteLine("Connection is null");

            OracleQuery query = new OracleQuery(OracleQuery.SELECT);
            query.Select("");
            query.From(((ModelAttribute)obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName);


            if (noWhereClause)
            {
                object valueUsedInForeach;

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    valueUsedInForeach = prop.GetValue(obj, null);
                    if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                    {
                        query.Where(prop.Name, "=", valueUsedInForeach);
                    }

                }
            }

            return query;
        }


        /// <summary>
        /// Create an insert query.
        /// </summary>
        /// <param name="obj">Model class</param>
        /// <returns>OracleQuery</returns>
        public OracleQuery InsertObjectQuery(object obj)
        {
            if (this.GetConnection().Equals(null))
                Debug.WriteLine("Connection is null");

            object valueUsedInForeach;

            List<object> values = new List<object>();
            List<string> columns = new List<string>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                valueUsedInForeach = prop.GetValue(obj, null);
                if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                {
                    columns.Add(prop.Name);
                    values.Add(valueUsedInForeach);
                }

            }

            OracleQuery query = new OracleQuery(OracleQuery.INSERT);
            //ModelAttribute tableModelAttribute = (ModelAttribute) obj.GetType().GetCustomAttribute(typeof(ModelAttribute));
            query.Insert(( (ModelAttribute) obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName,
                values.ToArray(),
                columns.ToArray());

            Debug.WriteLine("Insert query: " + query.GetQuery());
            return query;
        }


        /// <summary>
        /// Create a update query.
        /// </summary>
        /// <param name="obj">Model class</param>
        /// <param name="whereObjs">Dictionary for the where clause</param>
        /// <returns>OracleQuery</returns>
        public OracleQuery UpdateObjectQuery(object obj, Dictionary<string, object> whereObjs)
        {
            if (this.GetConnection().Equals(null))
                Debug.WriteLine("Connection is null");

            object valueUsedInForeach;

            List<object> values = new List<object>();
            List<string> columns = new List<string>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                valueUsedInForeach = prop.GetValue(obj, null);
                if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                {
                    columns.Add(prop.Name);
                    values.Add(valueUsedInForeach);
                }

            }            

            OracleQuery query = new OracleQuery(OracleQuery.UPDATE);

            query.Update(((ModelAttribute)obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName,
                values.ToArray(),
                columns.ToArray());

            foreach (KeyValuePair<string, object> whereObj in whereObjs)
                query.Where(whereObj.Key, "=", whereObj.Value);

            return query;
        }


        /// <summary>
        /// Generate a delete query
        /// </summary>
        /// <param name="obj">Model class</param>
        /// <returns>OracleQuery</returns>
        public OracleQuery DeleteObjectQuery(object obj)
        {
            if (this.GetConnection().Equals(null))
                Debug.WriteLine("Connection is null");

            OracleQuery query = new OracleQuery(OracleQuery.DELETE);
            query.Delete();
            query.From(((ModelAttribute)obj.GetType()
                    .GetCustomAttribute(typeof(ModelAttribute)))
                    .tableName);

            object valueUsedInForeach;

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                valueUsedInForeach = prop.GetValue(obj, null);
                if (valueUsedInForeach != null && !valueUsedInForeach.Equals(""))
                {
                    query.Where(prop.Name, "=", valueUsedInForeach);
                }

            }

            return query;
        }
    }
}
