using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_examenvehiculos.Models;

namespace api_examenvehiculos.Controllers
{
    public class ValuesController : ApiController
    {
        String SqlCon = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

        // GET api/values/5
        [HttpGet]
        [Route("api/Catalogos/Marca/")]
        public List<Marca> GetCatMarca()
        {
            List<Marca> lstMarca = new List<Marca>();
            
            using (SqlConnection con = new SqlConnection(SqlCon))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetMarca", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Marca marca = null;

                    while (reader.Read())
                    {
                        marca = new Marca();

                        marca.idMarca = int.Parse(reader["idMarca"].ToString());
                        marca.MarcaDes = reader["Marca"].ToString();

                        lstMarca.Add(marca);
                    }
                    con.Close();
                }

                return lstMarca;
            }
        }

        [HttpGet]
        [Route("api/Catalogos/SubMarca/")]
        public List<SubMarca> GetcatSubMarca(int idMarca)
        {
            List<SubMarca> lstSubMarca = new List<SubMarca>();

            using (SqlConnection con = new SqlConnection(SqlCon))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetSubMarca", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@idMarca", idMarca);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    SubMarca submarca = null;

                    while (reader.Read())
                    {
                        submarca = new SubMarca();

                        submarca.idSubMarca = int.Parse(reader["idSubmarca"].ToString());
                        submarca.SubMarcaDes = reader["Submarca"].ToString();

                        lstSubMarca.Add(submarca);
                    }
                    con.Close();
                }

                return lstSubMarca;
            }
        }


        [HttpGet]
        [Route("api/Catalogos/Modelo/")]
        public List<Modelo> GetcatModelo(int idSubMarca)
        {
            List<Modelo> lstModelo = new List<Modelo>();

            using (SqlConnection con = new SqlConnection(SqlCon))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetModelo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@idSubMarca", idSubMarca);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Modelo modelo = null;

                    while (reader.Read())
                    {
                        modelo = new Modelo();

                        modelo.idModelo = int.Parse(reader["idModelo"].ToString());
                        modelo.ModeloDes = reader["Modelo"].ToString();

                        lstModelo.Add(modelo);
                    }
                    con.Close();
                }

                return lstModelo;
            }
        }

        [HttpGet]
        [Route("api/Catalogos/Descripcion/")]
        public List<Descripcion> GetcatDescripcion(int idModelo)
        {

            List<Descripcion> lstDescripcion = new List<Descripcion>();

            using (SqlConnection con = new SqlConnection(SqlCon))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetDescripcion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@idModelo", idModelo);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Descripcion descripcion = null;

                    while (reader.Read())
                    {
                        descripcion = new Descripcion();
                        
                        descripcion.DescripcionDes = reader["Descripcion"].ToString();
                        descripcion.DescripcionId = reader["DescripcionId"].ToString();

                        lstDescripcion.Add(descripcion);
                    }
                    con.Close();
                }

                return lstDescripcion;
            }
        }

    }
}
