using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL.DALModel
{
    public class LendaDAL
    {
        public static bool Insert(Lenda lenda)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Lenda_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emertimi", lenda.Emertimi);
                cmd.Parameters.AddWithValue("@Libri", lenda.Libri);
                cmd.Parameters.AddWithValue("@CreatedOn", lenda.CreatedOn);


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

        public static bool Update(Lenda lenda)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Lenda_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LendaID", lenda.LendaID);
                cmd.Parameters.AddWithValue("@Emertimi", lenda.Emertimi);
                cmd.Parameters.AddWithValue("@Libri", lenda.Libri);
                cmd.Parameters.AddWithValue("@LastUpdate", lenda.LastUpdate);


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

            var cmd = new SqlCommand("usp_Lenda_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@LendaID", id);

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
        public static Lenda Read(int id)
        {
            var lenda = new Lenda();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Lenda_Read", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (id != 0)
                {
                    cmd.Parameters.AddWithValue("@LendaID", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        lenda.LendaID = int.Parse(rdr["LendaID"].ToString());
                        lenda.Emertimi = rdr["Emertimi"].ToString();
                        lenda.Libri = rdr["Libri"].ToString();
                        lenda.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                        lenda.LastUpdate = DateTime.Parse(rdr["LastUpdated"].ToString()) == null ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    }
                    return lenda;
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
        public static List<Lenda> List()
        {
            var lenda = new List<Lenda>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Lenda_List", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Lenda = new Lenda();
                    Lenda.LendaID = int.Parse(rdr["LendaID"].ToString());
                    Lenda.Emertimi = rdr["Emertimi"].ToString();
                    Lenda.Libri = rdr["Libri"].ToString();
                    Lenda.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                    Lenda.LastUpdate = string.IsNullOrEmpty(rdr["LastUpdate"].ToString()) == true ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    lenda.Add(Lenda);
                }
                return lenda;
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