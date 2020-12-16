using E_Class.Models.Class_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL.DALModel
{
    public class ProfesoratDAL
    {
        public static bool Insert(Profesori profesorat)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Profesorat_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emri", profesorat.Emri);
                cmd.Parameters.AddWithValue("@Mbiemri", profesorat.Mbiemri);
                cmd.Parameters.AddWithValue("@Mail", profesorat.Mail);
                cmd.Parameters.AddWithValue("@CreatedOn", profesorat.CreatedOn);


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

        public static bool Update(Profesori profesorat, int id)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.usp_Profesorat_Edit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProfesoratID", id);
                cmd.Parameters.AddWithValue("@Emri", profesorat.Emri);
                cmd.Parameters.AddWithValue("@Mbiemri", profesorat.Mbiemri);
                cmd.Parameters.AddWithValue("@Mail", profesorat.Mail);
                cmd.Parameters.AddWithValue("@LastUpdate", profesorat.LastUpdate);


                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
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

            var cmd = new SqlCommand("usp_Profesorat_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@ProfesoratID", id);

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
        public static Profesori Read(int id)
        {
            var profesorat = new Profesori();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Profesorat_Read", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (id != 0)
                {
                    cmd.Parameters.AddWithValue("@ProfesoratID", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        profesorat.ProfesoratID = int.Parse(rdr["ProfesoratID"].ToString());
                        profesorat.Emri = rdr["Emri"].ToString();
                        profesorat.Mbiemri = rdr["Mbiemri"].ToString();
                        profesorat.Mail = rdr["Mail"].ToString();
                        profesorat.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                      //  profesorat.LastUpdate = DateTime.Parse(rdr["LastUpdated"].ToString()) == null ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    }
                    return profesorat;
                }
                else
                {
                    return null;
                }
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
        public static List<Profesori> List()
        {
            var profesori = new List<Profesori>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("usp_Profesorat_List", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var profesorat = new Profesori();
                    profesorat.ProfesoratID = int.Parse(rdr["ProfesoratID"].ToString());
                    profesorat.Emri = rdr["Emri"].ToString();
                    profesorat.Mbiemri = rdr["Mbiemri"].ToString();
                    profesorat.Mail = rdr["Mail"].ToString();
                    profesorat.CreatedOn = DateTime.Parse(rdr["CreatedOn"].ToString());
                   // profesorat.LastUpdate = DateTime(rdr["LastUpdate"].ToString()) == true ? DateTime.Now : DateTime.Parse(rdr["LastUpdated"].ToString());

                    profesori.Add(profesorat);
                }
                return profesori;
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