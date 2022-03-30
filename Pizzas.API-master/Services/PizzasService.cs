using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Dapper;
using System.Data.SqlClient; 
       
       
        public static List<Pizza> SelectAll (){
            List<Pizza> pizzas = new List<Pizza>();
            string sql = "SELECT * FROM Pizzas";
            using(SqlConnection Bd =  new SqlConnection(_connectionString)){
               pizzas = Bd.Query<Pizza> (sql).ToList();
            }
            return pizzas;
        }

        public static Pizza GetById (int IdPizza){
           Pizza PizzaBuscada = null;
           string sql = "SELECT * FROM Pizzas WHERE Id = @p";
           using(SqlConnection Bd =  new SqlConnection(_connectionString)){
               PizzaBuscada = Bd.QueryFirstOrDefault<Pizza>(sql, new {p = IdPizza});
           }
           return PizzaBuscada;
        }

        public static void Add (Pizza Pizza){
            string sql = "INSERT INTO Pizzas(  Nombre, LibreGluten, Importe, Descripcion) VALUES ( @pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using(SqlConnection Bd =  new SqlConnection(_connectionString)){
                Bd.Execute(sql, new{ pNombre = Pizza.Nombre, pLibreGluten = Pizza.LibreGluten, pImporte = Pizza.Importe, pDescripcion = Pizza.Descripcion});
            }
        }
        public static void Update (int id,Pizza pizzacambiada){
           string sql = "UPDATE Pizza SET Nombre='@pNombre', LibreGluten='pLibreGluten' Importe='pImporte' Descripcion='pDescripcion' WHERE id =@pid ";
           using(SqlConnection Bd =  new SqlConnection(_connectionString)){
               Bd.Execute (sql,new{pid=id,pNombre=pizzacambiada.Nombre,pLibreGluten=pizzacambiada.LibreGluten,pImporte=pizzacambiada.Importe,pDescripcion=pizzacambiada.Descripcion});
           }
        }

         public static int DeleteBy (int Id){
           int Registro = 0;
           string sql = "DELETE * FROM Pizza WHERE Id = @p ";
           using(SqlConnection Bd =  new SqlConnection(_connectionString)){
               Registro = Bd.Execute(sql, new {p = Id});
           }
           return Registro;
        }

        public static int TestTryCatch(){
            try {
                //bloque de código que quieras probar 
            }
            catch (Exception error){
                return Ok("error error error")
            }
        }