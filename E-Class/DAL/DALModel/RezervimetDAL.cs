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
                var cmd = new SqlCommand("dbo.usp_Rezervimet_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RezervimetID", rezervimet.RezervimeID);
                cmd.Parameters.AddWithValue("@GrupiID", rezervimet.GrupiID);
                cmd.Parameters.AddWithValue("@ProfesoriID", rezervimet.ProfesoriID);
                cmd.Parameters.AddWithValue("@SallaID", rezervimet.SallaID);
                cmd.Parameters.AddWithValue("@LendaId", rezervimet.LendaID);
                cmd.Parameters.AddWithValue("@Fillimi", rezervimet.Fillimi);
                cmd.Parameters.AddWithValue("@Mbarimi", rezervimet.Mbarimi);
                cmd.Parameters.AddWithValue("@statusi", rezervimet.statusi);
                cmd.Parameters.AddWithValue("@CreatedOn", rezervimet.CreatedOn);

             
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

        public static bool Update(Rezervimet rezervimet, int id)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Rezervimet_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RezervimetID", id);
                cmd.Parameters.AddWithValue("@GrupiID", rezervimet.GrupiID);
                cmd.Parameters.AddWithValue("@ProfesoriID", rezervimet.ProfesoriID);
                cmd.Parameters.AddWithValue("@SallaID", rezervimet.SallaID);
                cmd.Parameters.AddWithValue("@LendaId", rezervimet.LendaID);
                cmd.Parameters.AddWithValue("@Fillimi", rezervimet.Fillimi);
                cmd.Parameters.AddWithValue("@Mbarimi", rezervimet.Mbarimi);
                cmd.Parameters.AddWithValue("@statusi", rezervimet.statusi);
                cmd.Parameters.AddWithValue("@LastUpdate", rezervimet.LastUpdate);



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

            var cmd = new SqlCommand("dbo.usp_Rezervimet_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@RezervimetID",id);

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
        public static Rezervimet Read(int id)
        {
            var rezervimet = new Rezervimet();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("dbo.usp_Rezervimet_Read", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (id != 0)
                {
                    cmd.Parameters.AddWithValue("@RezervimetID", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        rezervimet.RezervimeID = int.Parse(rdr["rezervimetID"].ToString());


                    }
                       return rezervimet;
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
        public static List<Rezervimet> List()
        {
            var list = new List<Rezervimet>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("dbo.usp_Rezervimet_List", conn);
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