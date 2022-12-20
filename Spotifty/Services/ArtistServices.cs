using Spotifty.Abstractions;
using Spotifty.Helper;
using Spotifty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotifty.Services
{
    internal class ArtistServices : IService<Artist>
    {
        public void Add(Artist artist)
        {
            //SQL.ExecCommand($"INSERT INTO Artists VALUES (N'{artist.Name}',N'{artist.Surname}','{artist.BirthDay}','{artist.Gender}',NULL)");
            SQL.ExecCommand($"EXEC usp_CreateArtist N'{artist.Name}',N'{artist.Surname}','{artist.BirthDay}','{artist.Gender}'");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Məlumatlar Artists cədvəlinə əlavə olundu");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void Remove(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT DeletedTime FROM Artists WHERE Id = {id}");
            int result = SQL.ExecCommand($"DELETE Artists WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Artist yoxdur");
            else
            {
                string DelTime = null;
                foreach (DataRow dr in dt.Rows)
                {
                    DelTime = dr[0].ToString();
                }

                if (DelTime == "") Console.WriteLine($"{id} ID-li Artist zibil qutusuna atıldı");

                else Console.WriteLine($"{id} ID-li Artist cədvəldən silindi");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public List<Artist> GetData()
        {
            List<Artist> list = new List<Artist>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Artists");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Artist()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    BirthDay = (DateTime)dr["Birthday"],
                    Gender = dr["Gender"].ToString()

                });
            }
            return list;
        }

        public Artist GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Artists WHERE Id = {id}");
            Artist artist = null;

            foreach (DataRow dr in dt.Rows)
            {
                artist = new Artist()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    BirthDay = (DateTime)dr["Birthday"],
                    Gender = dr["Gender"].ToString()
                };
            }

            return artist;
        }
    }
}
