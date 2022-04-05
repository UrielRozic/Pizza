using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Dapper;
using System.Data.SqlClient; 
       
       
        /*public static List<Pizza> SelectAll (){
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
        }*/

        public static List<Pizza> GetAll() {
            string sqlQuery;    
            List<Pizza> returnList;

            returnList = new List<Pizza>();
            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {      
                sqlQuery = "SELECT * FROM Pizzas";      
                returnList  = db.Query<Pizza>(sqlQuery).ToList();
                }    
                
            return returnList;
        }

        public static Pizza GetById(int id) {
            string  sqlQuery;    
            Pizza returnEntity = null;

            sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas ";    
            sqlQuery = "WHERE Id = @idPizza";
            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {        
                returnEntity  = db.QueryFirstOrDefault<Pizza>(sqlQuery, new { idPizza = id });
            }    
            return returnEntity;
        }

        public static int Insert(Pizza pizza) {   
            string  sqlQuery;    
            int     intRowsAffected = 0;           
            sqlQuery  = "INSERT INTO Pizzas ("; 
            sqlQuery += "Nombre, LibreGluten, Importe, Descripcion";    
            sqlQuery += ") VALUES (";sqlQuery += "@nombre, @libreGluten, @importe, @descripcion"; 
            sqlQuery += ")";
            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                intRowsAffected = db.Execute(sqlQuery, new { 
                    nombre      = pizza.Nombre,   
                        libreGluten = pizza.LibreGluten,  
                                importe     = pizza.Importe, 
                                  descripcion = pizza.Descripcion
                                  } );    }    
            
            return intRowsAffected; 
            
        }

        public static int TestTryCatch(){
            try {
                //bloque de código que quieras probar 
            }
            catch (Exception error){
                return Ok("error error error")
            }
        }