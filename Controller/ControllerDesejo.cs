using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace Controller
{
    public class ControllerDesejo
    {
        public bool GravarDesejo(Desejo desejo)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            if (desejo.IDDesejo == 0)
            {
                comando.CommandText = "insert into tbl_desejo (Solicitante, Solicitado, Valor, DataDesejo, Descricao) values ( @solicitante, @solicitado, @valor, @datadesejo, @descricao)";
                
                comando.Parameters.AddWithValue("@solicitante", desejo.Solicitante);
                comando.Parameters.AddWithValue("@solicitado", desejo.Solicitado);
                comando.Parameters.AddWithValue("@valor", desejo.Valor);
                comando.Parameters.AddWithValue("@descricao", desejo.Descricao);
                comando.Parameters.AddWithValue("@datadesejo", desejo.DataDesejo);
            }
            else
            {
                comando.CommandText = "update into tbl_desejo set solicitante=@solicitante,solicitado=@solicitado, valor=@valor, descricao=@descricao, datadesejo=@datadesejo where iddesejo=@iddesejo";
                comando.Parameters.AddWithValue("@iddesejo", desejo.IDDesejo);
                comando.Parameters.AddWithValue("@solicitante", desejo.Solicitante);
                comando.Parameters.AddWithValue("@solicitado", desejo.Solicitado);
                comando.Parameters.AddWithValue("@valor", desejo.Valor);
                comando.Parameters.AddWithValue("@descricao", desejo.Descricao);
                comando.Parameters.AddWithValue("@datadesejo", desejo.DataDesejo);

            }

            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }
        public List<Desejo> ListarDesejo() 
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_desejo order by IDDesejo";
            List<Desejo> listaDesejo = new List<Desejo>();
            Desejo desejo;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    desejo = new Desejo();
                    desejo.IDDesejo = reader.GetInt32(0);
                    desejo.Solicitante = reader.GetString(1);
                    desejo.Solicitado = reader.GetString(2);
                    desejo.Valor = reader.GetDouble(3);
                    desejo.DataDesejo = reader.GetDateTime(4);
                    desejo.Descricao = reader.GetString(5);
                    listaDesejo.Add(desejo);


                }
                conexao.Close();
            }
            return listaDesejo;
        
        }
    }
}
