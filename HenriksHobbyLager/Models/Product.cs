﻿namespace RefactoringExercise.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastUpdated { get; set; }  // Frågetecknet är för att jag är osäker på datumet
}