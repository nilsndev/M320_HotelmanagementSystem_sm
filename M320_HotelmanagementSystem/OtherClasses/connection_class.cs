using System.Data.Common;
using MySql.Data.MySqlClient;
namespace M320_HotelmanagementSystem.OtherClasses{
    public class connection_class{
        string _host = "localhost";
        string _userID = "root";
        string _passWord = "";
        string _database = "hotelmanagement_db";
        MySqlConnection _connection;
        private connection_class(){
            string connectionString = $"server={_host};userid={_userID};password={_passWord};database={_database};";
            _connection = new MySqlConnection(connectionString);
        }
        private MySqlConnection getConnection(){
            if (_connection.State != System.Data.ConnectionState.Open){
                _connection.Open();
            }
            return _connection;
        }
        private void closeConnection(){
            if (_connection.State != System.Data.ConnectionState.Closed){
                _connection.Close();
            }
        }
        public bool executeSELECTQuery(string query){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            DbDataReader reader = cmd.ExecuteReader();
            bool success = reader.HasRows;
            reader.Close();
            cmd.Dispose();
            return success;
        }
        public T executeWithReturnValue<T>(string query){
            T returnValue;
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            returnValue = (T)cmd.ExecuteScalar();
            cmd.Dispose();
            return returnValue;
        }
        public int executeQuery(string query){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return rowsAffected;
        }
    }
}
