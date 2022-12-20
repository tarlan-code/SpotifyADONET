using Spotifty.Abstractions;
using Spotifty.Helper;
using Spotifty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Services
{
    class MusicServices : IService<Music>
    {


        public void Add(Music music)
        {
            
            //SQL.ExecCommand($"INSERT INTO Musics VALUES (N'{music.Name}',CONVERT(VARCHAR,CAST(DATEADD(ms,{music.Duration * 1000},0) as time)),{music.CategoryId},NULL)");
            SQL.ExecCommand($"EXEC usp_CreateMusic N'{music.Name}',{music.Duration},{music.CategoryId}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Məlumatlar Musics cədvəlinə əlavə olundu");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void Remove(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT DeletedTime FROM Musics WHERE Id = {id}");
            int result = SQL.ExecCommand($"DELETE Musics WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Music yoxdur");
            else
            {
                string DelTime = null;
                foreach (DataRow dr in dt.Rows)
                {
                    DelTime = dr[0].ToString();
                }

                if (DelTime == "") Console.WriteLine($"{id} ID-li Music zibil qutusuna atıldı");
                
                else Console.WriteLine($"{id} ID-li Music cədvəldən silindi");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public List<Music> GetData()
        {
            List<Music> list = new List<Music>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Musics");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Music()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    GetDuration = (TimeSpan) dr["Duration"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                });
            }

            return list;
        }

        public Music GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Musics WHERE Id = {id}");
            Music music = null;
            foreach (DataRow dr in dt.Rows)
            {
                music = new Music()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    GetDuration = (TimeSpan)dr["Duration"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                };
            }

            return music;
        }
    }
}
