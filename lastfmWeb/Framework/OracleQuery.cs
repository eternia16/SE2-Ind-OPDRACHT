namespace lastfmWeb.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

 
    // Class to generate a query. Orginally used in the proftaak ict4events recycled for this purpose
    public class OracleQuery
    {

       
        // Static const variables. Used for types of the action mostly.

        public static int SELECT = 0,
            INSERT = 1,
            DELETE = 2,
            UPDATE = 3;



        // Stamdard actions defined.

        private const string _select = "SELECT ",
            _insert = "INSERT INTO ",
            _delete = "DELETE ",
            _update = "UPDATE ";


        // Types that are available for the where clause.

        Dictionary<Type, string> typesWhereClause = new Dictionary<Type, string>{
                { typeof(int), "int" },
                { typeof(string), "string" },
                { typeof(double), "double" }
            };



        // Properties

        private int _type;
        private string _query = "";
        private int _actionAdded = -1;
        private bool _actionReady = false;
        private bool _whereAdded = false;

        public OracleQuery() { }


        // Public constructor. Possibility to set a query type.

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


        // Selecting colummns.

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


        // Adds delete to the query.

        public void Delete()
        {
            InvalidActionUsed(OracleQuery.DELETE);

            if (_query.Equals("") || _query.Length == 0)
                _query = _delete;
        }



        // Adds insert to the query.

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
                        case "DateTime?":
                            _values += val;
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


        // Add update to the query.

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



        // Adds where clause. Sub Queries allowed.
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



        // Add rownum to where clause.
        public void Rownum(int limit)
        {
            Where("ROWNUM", "<=", limit);
        }



        // Adds from to the query.

        public void From(string tableName)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            _query += "FROM " + tableName;
            _actionReady = true;
        }




        // Leftjoin
        public void LeftJoin(string table, string on)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            if(table.Length < 5 || on.Length < 5)
                throw new IOException("Wrong query caused in Left Join.");
            _query += " LEFT JOIN " + table + " ON " + on;
        }



        // Right join. Exact copy of LeftJoin method but replaced Left with Right.
        public void RightJoin(string table, string on)
        {
            if (_query.Equals("") || _query.Length == 0 || _actionAdded == -1)
                throw new IOException("Invalid query format. You must first select columns or use one of the following actions:\n" +
            "SELECT, UPDATE, INSERT, DELETE");

            if (table.Length < 5 || on.Length < 5)
                throw new IOException("Wrong query caused in Right Join.");
            _query += " RIGHT JOIN " + table + " ON " + on;
        }


       

        void InvalidActionUsed(int type) {
            if (_actionAdded == -1)
                _actionAdded = type;
            else if (_actionAdded != type)
                throw new IOException("Invalid action used. You can only use either SELECT, INSERT, DELETE or UPDATE. Not two or more of them."); 
        }



        // Check if the action is complete or ready to be used.

        public bool ActionReady()
        {
            return this._actionReady;
        }



        // Gets the query.

        public string GetQuery()
        {
            return this._query;
        }


        // Sets a query manually

        public void SetQuery(string query)
        {
            this._query = query;
            this._actionReady = true;
        }
    }
}
