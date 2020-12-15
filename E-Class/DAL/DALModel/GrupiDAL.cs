using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL.DALModel
{
    public class GrupiDAL
    {
        public static bool Insert(Grupi grupi)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Grupi_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmriGrupit", grupi.EmriGrupi);
                cmd.Parameters.AddWithValue("@VitiAkademik", grupi.VitiAkademik);
                cmd.Parameters.AddWithValue("@CreatedOn", grupi.CreatedOn);
                

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

        public static bool Update(Grupi grupi)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Students_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GrupiId", grupi.GrupiID);
                cmd.Parameters.AddWithValue("@EmriGrupit", grupi.EmriGrupi);
                cmd.Parameters.AddWithValue("@VitiAkademik", grupi.VitiAkademik);
                cmd.Parameters.AddWithValue("@LastUpdate", grupi.LastUpdate);
           

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

            var cmd = new SqlCommand("usp_Grupi_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@GrupiId", id);

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
        public static Grupi Read(int id) {
            var Grupi= new Grupi();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Grupi_Read", conn);
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
                        Grupi.GrupiID = int.Parse(rdr["GrupiID"].ToString());
                        Grupi.EmriGrupi = int.Parse(rdr["EmriGrupit"].ToString());
                        Grupi.VitiAkademik = int.Parse(rdr["VitiAkademik"].ToString());
                        Grupi.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                        Grupi.LastUpdate = DateTime.Parse(rdr["LastUpdated"].ToString()) == null ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());
                       
                    }
                    return Grupi;
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
        public static List<Grupi> List()
        {
            var list = new List<Grupi>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Grupi_List", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var grupi = new Grupi();
                    grupi.GrupiID = int.Parse(rdr["GrupiID"].ToString());
                    grupi.EmriGrupi = int.Parse(rdr["EmriGrupit"].ToString());
                    grupi.VitiAkademik = int.Parse(rdr["VitiAkademik"].ToString());
                    grupi.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                    grupi.LastUpdate = string.IsNullOrEmpty(rdr["LastUpdate"].ToString()) == true ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());
                  
                    list.Add(grupi);
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