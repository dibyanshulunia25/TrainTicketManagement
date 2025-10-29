using System;
using System.Data;
using System.Data.SqlClient;

namespace TrainTicketManagement
{
    internal class Functions
    {
        SqlConnection Con;
        SqlDataAdapter Sda;
        DataTable dt;
        SqlCommand Cmd;
        string ConStr;
        public Functions()
        {
            ConStr = @"Data Source=(localdb)\ProjectModels;Initial Catalog=TrainTicketManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            Sda = new SqlDataAdapter(Query, ConStr);
            dt = new DataTable();
            Sda.Fill(dt);
            return dt;
        }
        public int setData(string Query)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed) Con.Open();
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
