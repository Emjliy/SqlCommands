using System;
using System.Data.SqlClient;

namespace Commands
{
    class Program
    {
        private const string connectionString =@"Server=DESKTOP-ULBGA9L\SQL;Database=SQLCOMMANDS;Integrated Security=true;";
        static void Main(string[] args)
        {
            Delete();

        }
        static void Insert()
        {
            Console.WriteLine("Enter GroupName:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter GroupCount:");
            int groupCount = int.Parse(Console.ReadLine());
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string query = $"Insert Into GROUPS Values('{name}',{groupCount})";
            SqlCommand command = new SqlCommand(query, connect);
            int result = command.ExecuteNonQuery();
            if (result<1)
            {
                Console.WriteLine("Some problems");

            }
            connect.Close();
        }
        static void Delete()
        {
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string query = $"DELETE FROM GROUPS WHERE GROUPS.ID={id}";
            SqlCommand command = new SqlCommand(query, connect);
            int result = command.ExecuteNonQuery();
            if (result < 1)
            {
                Console.WriteLine("Some problems");
            }
            connect.Close();
        }
        static void Update()
        {
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter groupcount:");
            int count = int.Parse(Console.ReadLine());
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string query = $"UPDATE GROUPS SET NAME = '{name}', GROUPCOUNT = {count} WHERE ID = {id}";
            using (SqlCommand command = new SqlCommand(query, connect))
            {
                int result = command.ExecuteNonQuery();
                if (result < 1)
                {
                    Console.WriteLine("Some problems");
                }
            }
            connect.Close();
        }
        static void Select()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string query = $"SELECT*FROM GROUPS";
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine(result["name"] + " " + result["count"]);
            }
            connect.Close();
        }

    }
}

