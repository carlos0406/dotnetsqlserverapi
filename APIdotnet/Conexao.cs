using Microsoft.Data.SqlClient;

namespace APIdotnet
{
    
    public class Conexao
    {
        private SqlConnection _connection = new SqlConnection();
        public Conexao()
        {
            _connection.ConnectionString =
                "Password=senha0406%;Persist Security Info=True;User ID=sa;Initial Catalog=sqlServerExample;Data Source=localhost";
        }

        public SqlConnection conectar()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public void desconectar()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            } 
        }
    }
}