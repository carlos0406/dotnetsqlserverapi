using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIdotnet.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace APIdotnet.Controllers
{
    
    
    [ApiController]
    [Route("v1/usuarios")]
    public class WeatherForecastController : ControllerBase
    {
        List<Usuario>usuarios=new List<Usuario>();
        private Conexao conClasse = new Conexao();
        private SqlCommand cmd = new SqlCommand();
        //Task<Action<List<Usuario>>>

        [HttpGet]
        public List<Usuario>  Get()
        {
            try
            {
                cmd.Connection = conClasse.conectar();
                cmd.CommandText = "SELECT * FROM usuarios" ;
                
                SqlDataReader  reader=cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuario=new Usuario();
                        usuario.nome = reader.GetString(reader.GetOrdinal("nome"));
                        usuario.cpf = reader.GetString(reader.GetOrdinal("cpf"));
                        usuario.empresa = reader.GetString(reader.GetOrdinal("empresa"));
                        usuarios.Add(usuario);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            return usuarios;
        }

        [HttpPost]
        public Usuario Post([FromBody] Usuario model)
        {
            try
            {
                cmd.Connection = conClasse.conectar();
                cmd.CommandText = "insert into usuarios (nome,empresa,cpf) values (@nome,@empresa,@cpf)";
                cmd.Parameters.AddWithValue("@nome", model.nome);
                cmd.Parameters.AddWithValue("@empresa", model.empresa);
                cmd.Parameters.AddWithValue("@cpf", model.cpf);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return model;
        }
    }
}