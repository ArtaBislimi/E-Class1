using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL.DALModel
{
    public class SallatDAL
    {
        public static bool Insert(Salla sallat)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Sallat_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NumriSalles", sallat.NumriSalles);
                cmd.Parameters.AddWithValue("@Tipi", sallat.Tipi);
                cmd.Parameters.AddWithValue("@CreatedOn", sallat.CreatedOn);


                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool Update(Salla Salla)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Sallat_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SallaID", Salla.SallaID);
                cmd.Parameters.AddWithValue("@NumriSalles", Salla.NumriSalles);
                cmd.Parameters.AddWithValue("@Tipi", Salla.Tipi);
                cmd.Parameters.AddWithValue("@LastUpdate", Salla.LastUpdate);


                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool Delete(int id)
        {
            var conn = DBHelper.GetConnection();

            var cmd = new SqlCommand("usp_Sallat_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@SallaID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public static Salla Read(int id)
        {
            var salla = new Salla();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Sallat_Read", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (id != 0)
                {
                    cmd.Parameters.AddWithValue("@GrupiId", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        salla.SallaID = int.Parse(rdr["SallaID"].ToString());
                        salla.NumriSalles = int.Parse(rdr["NumriSalles"].ToString());
                        salla.Tipi = char.Parse(rdr["Tipi"].ToString());
                        salla.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                        salla.LastUpdate = DateTime.Parse(rdr["LastUpdated"].ToString()) == null ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    }
                    return salla;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Salla> List()
        {
            var list = new List<Salla>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Sallat_List", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var sallat = new Salla();
                    sallat.SallaID = int.Parse(rdr["SallaID"].ToString());
                    sallat.NumriSalles = int.Parse(rdr["NumriSalles"].ToString());
                    sallat.Tipi = char.Parse(rdr["Tipi"].ToString());
                    sallat.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                    sallat.LastUpdate = string.IsNullOrEmpty(rdr["LastUpdate"].ToString()) == true ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    list.Add(sallat);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}