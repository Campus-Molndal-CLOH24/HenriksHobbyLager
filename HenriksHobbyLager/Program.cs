
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringExercise
{
    class Program
    {

        using var connection = new SqliteConnection("Data Source=HobbyLager.db");
        connection.Open();
        Console.WriteLine("SQLite connection successful!");
        /*
        // Min fantastiska databas! Fungerar perfekt så länge datorn är igång
        private static List<Product> _products = new List<Product>();
        
        // Räknare för ID. Börjar på 1 för att 0 känns så negativt
        private static int _nextId = 1;

        
        */
     }
        

        