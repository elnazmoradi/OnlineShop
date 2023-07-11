using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SocksRepository : ISocksRepository
    {
        public void CreateSocks(Socks TheSocks)
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                connection.Open();
                string command = $"INSERT INTO SOCKS (TITLE, DESCRIPTION, PRICE, SIZE, COLOR, IMAGE) values ('{TheSocks.Title}', '{TheSocks.Description}', '{TheSocks.Price}', '{TheSocks.SocksSize}', '{TheSocks.SocksColor}', {TheSocks.Image});";
                using var cmd = new SqlCommand(command, connection);
                var reader = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSocksByID(Guid ID)
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                connection.Open();
                string command = $"DELETE FROM SOCKS WHERE Id = {ID};";
                using var cmd = new SqlCommand(command, connection);
                var reader = cmd.ExecuteNonQuery();
            }
        }

        public List<Socks> GetAllSocks()
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                connection.Open();
                List<Socks> allSocks = new List<Socks>();
                string command = $"SELECT * FROM SOCKS;";
                using var cmd = new SqlCommand(command, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Socks socks = new Socks()
                    {
                        ID = (Guid)reader.GetValue(0),
                        Title = reader.GetValue(1).ToString(),
                        Description = reader.GetValue(2).ToString(),
                        Price = (double)reader.GetValue(3),
                        SocksSize = Enum.Parse<Size>(reader.GetValue(4).ToString()),
                        SocksColor = Enum.Parse<Color>(reader.GetValue(5).ToString()),
                        Image = (Blob)reader.GetValue(6)

                    };
                    allSocks.Add(socks);
                }

                return allSocks;
            }
        }

        public Socks GetSocksByID(Guid ID)
        {
            using (SqlConnection connection = DbContext.Connection())
            {
                connection.Open();
                string command = $"SELECT * FROM SOCKS where id = {ID};";
                using var cmd = new SqlCommand(command, connection);
                var reader = cmd.ExecuteReader();
                Socks socks = new Socks()
                {
                    ID = (Guid)reader.GetValue(0),
                    Title = reader.GetValue(1).ToString(),
                    Description = reader.GetValue(2).ToString(),
                    Price = (double)reader.GetValue(3),
                    SocksSize = Enum.Parse<Size>(reader.GetValue(4).ToString()),
                    SocksColor = Enum.Parse<Color>(reader.GetValue(5).ToString()),
                    Image = (Blob)reader.GetValue(5)
                };
                return socks;
            }
        }

        public void UpdateSocksByID(Guid ID)
        {
            // i don't think it is functional.
        }
    }
}
