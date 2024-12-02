namespace HenriksHobbyLager;

using HenriksHobbyLager.Database;
using HenriksHobbyLager.Interfaces;

internal static class Program
{
    public static void Main()
    {
        HobbyLager lager = new();

        // Fejkad Dependency Injection 😇,
        // egentligen Inversion of Control
        IListRepository repository = new ListRepository();
        lager.Start(repository);

        // TODO: Skapa en Dependency Injection container
    }
}