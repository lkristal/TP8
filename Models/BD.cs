using System;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace TP8.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=LEOK\SQLEXPRESS; DataBase=BDSeries;Trusted_Connection=True;";
         /*
          using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string SQL= "INSERT INTO Jugadores(Nombre, FechaHora, Comodin50, ComodinSaltear, ComodinDobleChance) values (@pNombre, @pFechaHora,1,1,1)";
                db.Execute(SQL, new {pNombre=Nombre, pFechaHora=DateTime.Now});
                SQL = "SELECT * FROM Jugadores ORDER BY IdJugador DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY"; 
                _Player = db.QueryFirstOrDefault<Jugador>(SQL);
            }
         */
        
        public static List<Temporada> GetTemporadas(int IdSerie)
        {
            List<Temporada> ListaTemporadas = null;
            string SQL = "SELECT * FROM Temporadas WHERE IdSerie=@pIdSerie"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                ListaTemporadas = db.Query<Temporada>(SQL, new {pIdSerie = IdSerie} ).ToList(); 
            } 
            return ListaTemporadas;
        }

        public static List<Actor> GetActores(int IdSerie)
        {
            List<Actor> ListaActores = null;
            string SQL = "SELECT * FROM Actores WHERE IdSerie=@pIdSerie"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                ListaActores = db.Query<Actor>(SQL, new {pIdSerie = IdSerie} ).ToList(); 
            } 
            return ListaActores;
        }

        public static List<Serie> GetSeries()
        {
            List<Serie> ListaSeries = null;
            string SQL = "SELECT * FROM Series"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                ListaSeries = db.Query<Serie>(SQL).ToList(); 
            } 
            return ListaSeries;
        }

        public static Serie GetInfo(int IdSerie)
        {
            Serie LaSerie = null;
            string SQL = "SELECT * FROM Series WHERE IdSerie=@pIdSerie"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                LaSerie = db.QueryFirstOrDefault<Serie>(SQL, new {pIdSerie = IdSerie} ); 
            } 
            return LaSerie;
        }
    }
}