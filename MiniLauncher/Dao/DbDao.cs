using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using MiniLauncher.Model;

namespace MiniLauncher
{
    /// <summary>
    /// データベースアクセスするクラスです。
    /// </summary>
    public class DbDao
    {
        private static string connectionString = "DataSource=MiniLauncher.sdf;";

        public List<Cmd> GetDbList()
        {
            List<Cmd> list = new List<Cmd>();

            SqlCeConnection con = new SqlCeConnection(connectionString);
            try
            {
                con.Open();

                SqlCeDataAdapter adapter = new SqlCeDataAdapter(
                    "select * from cmd order by name", con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Cmd");
                DataTable table = dataSet.Tables["Cmd"];
                foreach (DataRow row in table.Rows)
                {
                    Cmd cmd = new ExecutionCmd();
                    cmd.name = (string)row["name"];
                    cmd.description = (string)row["description"];
                    cmd.path = (string)row["path"];
                    cmd.arg = (string)row["arg"];
                    list.Add(cmd);
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return list;
        }

        public void InsertCmd(Cmd cmd)
        {
            SqlCeConnection con = new SqlCeConnection(connectionString);
            try
            {
                con.Open();

                //SqlCeDataAdapter adapter = new SqlCeDataAdapter(
                //    "insert into cmd (name, description, path, arg) values (" +
                //    "'" + cmd.name + "'," +
                //    "'" + cmd.description + "'," +
                //    "'" + cmd.path + "'," +
                //    "'" + cmd.arg + "'" +
                //    ")", con);
                //SqlCeCommand sqlCmd = adapter.InsertCommand;
                //int count = sqlCmd.ExecuteNonQuery();

                SqlCeCommand sqlCmd = con.CreateCommand();
                sqlCmd.CommandText = "insert into cmd (name, description, path, arg) values (" +
                    "'" + cmd.name + "'," +
                    "'" + cmd.description + "'," +
                    "'" + cmd.path + "'," +
                    "'" + cmd.arg + "'" +
                    ")";
                int count = sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

    }
}
