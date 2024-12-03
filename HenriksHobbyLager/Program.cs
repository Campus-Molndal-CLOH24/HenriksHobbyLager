
namespace HenriksHobbyLager;

using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
static class Program
{
    public static void Main()
    {
        HobbyLager Lager = new();
        IListRepository repository = new ListRepository();
        Lager.Start(repository);
    }
}