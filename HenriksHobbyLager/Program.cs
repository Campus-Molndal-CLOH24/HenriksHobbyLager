namespace HenriksHobbyLager;

using HenriksHobbyLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

internal static class Program
{
    public static void Main()
    {
        HobbyLager lager = new();
        lager.Start();
    }
}