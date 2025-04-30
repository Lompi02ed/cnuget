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

    public class Administratorius : Naudotojas
    {
        public string Leidimai { get; set; }
    }

    public class PaprastasNaudotojas : Naudotojas
    {
        public string Prenumerata { get; set; }
    }

    public class BendraNaudotojuStruktura : Naudotojas
    {
        public string Tipas { get; set; }
        public string Leidimai { get; set; }
        public string Prenumerata { get; set; }
    }

    static void Main(string[] args)
    {
        string json = File.ReadAllText("naudotojuTipai.json");
        List<BendraNaudotojuStruktura> sarasas = JsonConvert.DeserializeObject<List<BendraNaudotojuStruktura>>(json);

        foreach (var naudotojas in sarasas)
        {
            if (naudotojas.Tipas == "Admin")
            {
                var admin = new Administratorius
                {
                    Vardas = naudotojas.Vardas,
                    Amžius = naudotojas.Amžius,
                    Miestas = naudotojas.Miestas,
                    Leidimai = naudotojas.Leidimai
                };

                Console.WriteLine($"ADMIN | {admin.Vardas} – Leidimai: {admin.Leidimai}");
            }
            else
            {
                var vartotojas = new PaprastasNaudotojas
                {
                    Vardas = naudotojas.Vardas,
                    Amžius = naudotojas.Amžius,
                    Miestas = naudotojas.Miestas,
                    Prenumerata = naudotojas.Prenumerata
                };

                Console.WriteLine($"VARTOTOJAS | {vartotojas.Vardas} – Prenumerata: {vartotojas.Prenumerata}");
            }
        }
    }
}