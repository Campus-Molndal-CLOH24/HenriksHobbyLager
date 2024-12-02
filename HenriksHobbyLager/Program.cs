namespace HenriksHobbyLager;

using HenriksHobbyLager.Database;
using HenriksHobbyLager.Interfaces;

internal static class Program
{
    public static void Main()
    {
        // Fejkad Dependency Injection 😇,
        // egentligen Inversion of Control
        IListRepository repository = new FakeRepository();
        HobbyLager.Start(repository);

        // TODO: Skapa en Dependency Injection container (Autofac kanske)
    }
}