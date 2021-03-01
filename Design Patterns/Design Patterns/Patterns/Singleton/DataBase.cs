using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Singleton
{
    public class DataBase : IDisposable
    {
        private static Connection _connection;

        public void Open()
        {
            if (_connection == null)
                _connection = Connection.GetInstance();
        }

        public string Query(string queryString)
        {
            return _connection.Query(queryString);
        }

        public void Close()
        {
            _connection.Close();
            _connection = null;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
