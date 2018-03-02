using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Xml.Serialization;

namespace GasMetropolitano.Runtime.DataManager
{
    [Serializable, XmlRoot("DataManager", IsNullable = false)]
    public class DataManager
    {

        public DataManager()
        {}        


        private DAC _data = null;

        private DbConnection _connection;
        private DbProviderFactory factory ;

        private string providerName;

        [XmlAttribute("ProviderName")]
        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        [XmlIgnoreAttribute]
        public DbConnection Connection
        {
            set
            {
                if (this._connection == null)
                {
                    _connection = value;
                    _data = new DAC(_connection,this.providerName);
                }
            }
            get
            {
                return _connection;
            }
        }

        private string connectionString;
        [XmlAttribute("ConnectionString")]
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
                _connection = factory.CreateConnection();
                _connection.ConnectionString = connectionString;
                _data = new DAC(_connection,this.providerName);
            }
        }

        [XmlIgnoreAttribute]
        public DAC Data
        {
            get
            {
                return _data;
            }
        }

        //public static DataManager Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new DataManager();
        //        }
        //        return _instance;
        //    }
        //}

        //private static DataManager _instance;

        public DataManager(string ConnectionString, string providerName)
        {
            connectionString = ConnectionString;
            this.providerName = providerName;
            factory = DbProviderFactories.GetFactory(providerName);
            _connection = factory.CreateConnection();
            _connection.ConnectionString = connectionString;
            _data = new DAC(_connection,this.providerName);
        }

        public DataManager(DbConnection Connection, string providerName)
        {
            _connection = Connection;
            this.providerName = providerName;
            _data = new DAC(_connection,this.providerName);
        }
    }
}
