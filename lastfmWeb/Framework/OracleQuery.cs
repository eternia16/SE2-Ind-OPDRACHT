namespace OracleHandler.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class to generate a query.
    /// </summary>
    public class OracleQuery
    {

        /// <summary>
        /// Static const variables. Used for types of the action mostly.
        /// </summary>
        public static int SELECT = 0,
            INSERT = 1,
            DELETE = 2,
            UPDATE = 3;


        /// <summary>
        /// Stamdard actions defined.
        /// </summary>
        private const string _select = "SELECT ",
            _insert = "INSERT INTO ",
            _delete = "DELETE ",
            _update = "UPDATE ";

        /// <summary>
        /// Types that are available for the where clause.
        /// </summary>
        Dictionary<Type, string> typesWhereClause = new Dictionary<Type, string>{
                { typeof(int), "int" },
                { typeof(string), "string" },
                { typeof(double), "double" }
            };


        /// <summary>
        /// Properties
        /// </summary>
        private int _type;
        private string _query = "";
        private int _actionAdded = -1;
        private bool _actionReady = false;
        private bool _whereAdded = false;


        /// <summary>
        /// Public constructor
        /// </summary>
        public OracleQuery() { }

        /// <summary>
        /// Public constructor. Possibility to set a query type.
        /// </summary>
        /// <param name="type">Query type. Check static properties of OracleQuery</param>
        public OracleQuery(int type)
        {
            switch (type)
            {
                case 0:
                    this._type = type;
                    break;

                case 1:
                    this._type = type;
                    break;

                case 2:
                    this._type = type;
                    break;

                case 3:
                    this._type = type;
                    break;

                default:
                    throw new IOException("Wrong Query Type.");
            }
        }

        /// <summary>
        /// Selecting colummns.
        /// </summary>
        /// <param name="columns">Columns</param>
        public void Select(string columns = "")
        {
            InvalidActionUsed(OracleQuery.SELECT);

            if (_query.Equals("") || _query.Length == 0)
                _query = _select;

            if (columns.Length >= 1)
                _query += columns + " ";
            else
                _query += "* ";
        }


        /// <summary>
        /// Adds delete to the query.
        /// </summary>
        public void Delete()
        {
            InvalidActionUsed(OracleQuery.DELETE);

            if (_query.Equals("") || _query.Length == 0)
                _query = _delete;
        }


        /// <summary>
        /// Adds insert to the query.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="values">Values to insert</param>
        /// <param name="columns">Columns to be filled</param>
        public void Insert(string tableName, object[] values, string[] columns = null)
        {
            InvalidActionUsed(OracleQuery.INSERT);

            string _columns = "";
            string _values = "";

            if (_query.Equals("") || _query.Length == 0)
                _query = _insert + tableName + " ";

            // Adding the columns to the query.
            foreach (string column in columns)
            {
                if (!_columns.Equals(""))
                    _columns += ", ";
                _columns += column;
            }

            // Closing the columns string.
            if (!_columns.Equals(""))
                _query += "(" + _columns + ") ";

            // Adding the values to the query.
            foreach(object val in values) 
            {
                if (typesWhereClause.ContainsKey(val.GetType()))
                {
                    // Adds a comma when the values string isn't empty or equals double quotes.
                    if (!_values.Equals(""))
                        _values += ", ";

                    // Typical type class to see if the object is an int or string.
                    switch (typesWhereClause[val.GetType()])
                    {
                        case "string":
                            _values += "'" + val + "'";
                            break;
                        case "int":
                        case "double":
                            _values += val;
                            break;
                        default:
                            throw new IOException("Value is not an integer nor value in the insert into action.");
                    }

                }
                else
                    throw new IOException("Value is not an integer nor value in the insert into action.");
            }

            // Closing the values string.
            if (!_values.Equals(""))
                _query += "VALUES (" + _values + ")";

            _actionReady = true;
        }


        /// <summary>
        /// Add update to the query.
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="values">Values to be filled</param>
        /// <param name="columns">Columns to be updated</param>
        public void Update(string tableName, object[] values, string[] columns = null)
        {
            InvalidActionUsed(OracleQuery.UPDATE);

            string _setData = "";

            if (_query.Equals("") || _query.Length == 0)
                _query = _update + tableName + " ";

            for (int i = 0; i < columns.Length; i++)
            {
                if (_setData.Equals(""))
                    _setData = "SET ";

                _setData += columns[i] + " = ";

                if (typesWhereClause.ContainsKey(values[i].GetType()))
                {

                    // Typical type class to see if the object is an int or string.
                    switch (typesWhereClause[values[i].GetType()])
                    {
                        case "string":
                            _setData += "'" + values[i] + "'";
                            break;
                        case "int":
                            _setData += values[i];
                            break;
                        default:
                            throw new IOException("Value is not an integer nor value in the update set clause.");
                    }

                }
                else
                    throw new IOException("Value is not an integer nor value in the update set clause.");

                if (i < columns.Length-1)
                    _setData += ", ";
                else
                    _setData += " ";
            }

            _query += _setData;

            _actionReady = true;
        }


        /// <summary>
        /// Adds where clause to the query..
        /// </summary>
        /// <param name="column">Column in the where clause</param>
        /// <param name="op">Operator to use</param>
        /// <param name="val">Value after the operator.</param>
        /// <param name="field">Is val a field?</param>
        public void Where(string column, string op, object val, bool field = false)
        {
            if(!_actionReady && _type != OracleQuery.UPDATE)
                throw new IOException("Invalid where clause. You can't add a where clause if you didn't add FORM table and any action.");

            if (!_whereAdded) 
            {
                _query += " WHERE ";
                _whereAdded = true;
            }
            else
                _query += "AND ";
            _query += column + " " + op + " ";


            if (typesWhereClause.ContainsKey(val.GetType()))
            {
                switch (typesWhereClause[val.GetType()])
                {
                    case "string":
                        if (val.Equals("null"))
                            _query += "null ";
                        else if (field)
                            _query += val + " ";
                        else
                            _query += "'" + val + "' ";
                        break;
                    case "int":
                        _query += val + " ";
                        break;
                    default:
                        throw new IOException("Value is not an integer nor value in the where clause.");
                }
            }
            else
                throw new IOException("Value is not an integer nor value in the where clause.");
        }


        /// <summary>
        /// Adds where clause. Sub Queries allowed.
        /// </summary>
        /// <param name="column">Column for the sub query</param>
        /// <param name="op">Operator</param>
        /// <param name="subquery">Subquery</param>
        public void WhereSubQuery(string column, string op, string subquery)
        {
            if (!_actionReady)
                throw new IOException("Invalid where clause. You can't add a where clause if you didn't add FORM table and any action.");

            if (!_whereAdded)
                _query += " WHERE ";
            else
                _query += " AND ";
            _query += column + " " + op + " (" + subquery + ") ";
        }


        /// <summary>
        /// Add rownum to where clause.
        /// </summary>
        /// <param name="limit">Rownum limit</param>
        public void Rownum(int limit)
        {
            Where("ROWNUM", "<=", limit);
        }


        /// <summary>
        /// Adds from to the query.
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        public void From(string tableName)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            _query += "FROM " + tableName;
            _actionReady = true;
        }



        /// <summary>
        /// Leftjoin
        /// </summary>
        /// <param name="table">Name of the table</param>
        /// <param name="on">On clause</param>
        public void LeftJoin(string table, string on)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            if(table.Length < 5 || on.Length < 5)
                throw new IOException("Wrong query caused in Left Join.");
            _query += " LEFT JOIN " + table + " ON " + on;
        }


        /// <summary>
        /// Right join. Exact copy of LeftJoin method but replaced Left with Right.
        /// </summary>
        /// <param name="table">Name of the table</param>
        /// <param name="on">On clause</param>
        public void RightJoin(string table, string on)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            if (table.Length < 5 || on.Length < 5)
                throw new IOException("Wrong query caused in Right Join.");
            _query += " RIGHT JOIN " + table + " ON " + on;
        }


        /// <summary>
        /// Throws a new IOException in case someone f**s it up.
        /// </summary>
        /// <param name="type">Correct query action.</param>
        void InvalidActionUsed(int type) {
            if (_actionAdded == -1)
                _actionAdded = type;
            else if (_actionAdded != type)
                throw new IOException("Invalid action used. You can only use either SELECT, INSERT, DELETE or UPDATE. Not two or more of them."); 
        }


        /// <summary>
        /// Check if the action is complete or ready to be used.
        /// </summary>
        /// <returns></returns>
        public bool ActionReady()
        {
            return this._actionReady;
        }


        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns>Query string</returns>
        public string GetQuery()
        {
            return this._query;
        }


        /// <summary>
        /// Sets a query manually
        /// </summary>
        /// <param name="query">Query to set</param>
        public void SetQuery(string query)
        {
            this._query = query;
            this._actionReady = true;
        }
    }
}
