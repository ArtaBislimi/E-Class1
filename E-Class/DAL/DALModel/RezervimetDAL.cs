using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL.DALModel
{
    public class RezervimetDAL
    {
        public static bool Insert(Rezervimet rezervimet)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Grupi_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmriGrupit", rezervimet.RezervimeID);
             


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

        public static bool Update(Rezervimet rezervimet)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Students_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GrupiId", rezervimet.RezervimeID);
            


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
        //public static Grupi Read(int id)
        //{
        //    var rezervimet = new Rezervimet();
        //    var conn = DBHelper.GetConnection();
        //    var cmd = new SqlCommand("usp_Grupi_Read", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        if (id != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@GrupiId", id);

        //            conn.Open();
        //            var rdr = cmd.ExecuteReader();

        //            if (rdr.Read())
        //            {
        //                rezervimet.RezervimeID = int.Parse(rdr["rezervimetID"].ToString());
                      
                     
        //            }
        //         //   return rezervimet;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public static List<Rezervimet> List()
        {
            var list = new List<Rezervimet>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Grupi_List", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var rezervimet = new Rezervimet();
                   // rezervimet.GrupiID = int.Parse(rdr["RezervimetID"].ToString());
                  
                  //  grupi.LastUpdate = string.IsNullOrEmpty(rdr["LastUpdate"].ToString()) == true ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    list.Add(rezervimet);
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