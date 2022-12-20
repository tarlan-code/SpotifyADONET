using Spotifty.Models;
using Spotifty.Services;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Spotifty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region Music Add,Remove,CW,GetById

            //MusicServices mss = new MusicServices();

            //ADD
            //mss.Add(new Music()
            //{
            //    Name = "Runaway",
            //    Duration = 250,
            //    CategoryId = 2
            //});


            //REMOVE
            //mss.Remove(12);

            //CW
            //foreach (Music music in mss.GetData())
            //{
            //    Console.WriteLine($"{music.Id}. {music.Name}   {music.GetDuration}");
            //}



            //GetById
            //Music music = mss.GetById(1);
            //Console.WriteLine($"{music.Id}. {music.Name}   {music.GetDuration}");

            #endregion


            #region Artist  Add,Remove,CW,GetById
            ArtistServices ase = new ArtistServices();

            //ADD
            //ase.Add(new Artist()
            //{
            //    Name = "Tankurtttt",
            //    Surname = "Manas",
            //    BirthDay = DateTime.Parse("1991-09-12"),
            //    Gender = "Male"

            //});


            //REMOVE
            //ase.Remove(32);


            //CW
            //foreach (Artist artist in ase.GetData())
            //{
            //    Console.WriteLine($"{artist.Id}.{artist.Name}---{artist.Surname}---{artist.BirthDay.ToString().Substring(0, artist.BirthDay.ToString().Length - 12)}---{artist.Gender}");
            //}


            //GetById
            //Artist artist = ase.GetById(1);
            //Console.WriteLine($"{artist.Id}.{artist.Name}---{artist.Surname}---{artist.BirthDay.ToString().Substring(0, artist.BirthDay.ToString().Length - 12)}---{artist.Gender}");
            #endregion

        }
    }
}