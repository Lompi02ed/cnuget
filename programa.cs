using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Programa
{
    public class Naudotojas
    {
        public string Vardas { get; set; }
        public int Amžius { get; set; }
        public string Miestas { get; set; }
    }

    static void Main(string[] args)
    {
        string json = File.ReadAllText("naudotojai.json");
        List<Naudotojas> naudotojai = JsonConvert.DeserializeObject<List<Naudotojas>>(json);

        foreach (var n in naudotojai)
        {
            Console.WriteLine($"Vardas: {n.Vardas}, Amžius: {n.Amžius}, Miestas: {n.Miestas}");
        }
    }
}