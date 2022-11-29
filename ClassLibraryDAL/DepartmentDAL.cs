using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class DepartmentsDAL
    {
        public static void SaveDepartments(DepartmentsModel dm)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveDepartments", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", dm.Name);
            //cmd.Parameters.AddWithValue("@fk_Organization", dm.fk_OrganizationId);
            cmd.Parameters.AddWithValue("@Block", dm.Block);
            cmd.Parameters.AddWithValue("@IsActive", dm.IsActive);
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }

        public static List<DepartmentsModel> ReadDepartments()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Sp_ReadDepartments", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<DepartmentsModel> Departmentslist = new List<DepartmentsModel>();
            while (sdr.Read())
            {
                DepartmentsModel department = new DepartmentsModel();
                //department.pk_DepartmentId = int.Parse(sdr["pk_DepartmentId"].ToString());
                department.Name = sdr["Name"].ToString();
                //department.fk_OrganizationId = int.Parse((string)sdr["fk_OrganizationId"]);
                department.Block = sdr["Block"].ToString();
                department.IsActive = (bool)sdr["IsActive"];
            }
            conn.Close();
            return Departmentslist;
        }
        public static int DeleteDepartment(int DeleteId)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteDepartments", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", DeleteId);
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
    }


}
