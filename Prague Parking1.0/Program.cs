// Prague Parking 1.0


string[] parkeringsGarage = new string[100];

Console.WriteLine("Välkommen till Prague Parking 1.0");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("MENY");
    Console.WriteLine();
    Console.WriteLine("1. Parkera fordon");
    Console.WriteLine("2. Checka ut fordon");
    Console.WriteLine("3. Flytta fordon");
    Console.WriteLine("4. Hitta fordon");
    Console.WriteLine("5. Avsluta programmet");

    // Skulle vilja gardera mig för felinmatning. Inte helt nöjd med denna lösning. Men får duga för nu.
    // Ogillar att menyn snurrar om varje gång det blir fel. Hade velat ha Försök igen bara.. Tror jag fått ordning nu.
    // Kanske onödigt men gillar att inte menyn visa om och om igen vid felaktig inmatning. 
    int alternativ;

    while (true)        //Loopar tills det uppfyller kriterierna för val i switch-case loopen.
    { 
        Console.Write("Vänligen ange önskad åtgärd, alternativ 1-5: ");
    if (int.TryParse(Console.ReadLine(), out alternativ) && alternativ >= 1 && alternativ <= 5)
    {
        break;

    }
    Console.WriteLine("Felaktig inmatning. Försök igen");
}
        switch (alternativ)
        {
            case 1:
                {
                    Console.WriteLine("Parkera fordon");

                    //metod;     //break för att bryta ur
                    break;
                }
            case 2: //Normalt vill man ha detta i långa formatet då det oftare händer fler saker inom varje case.
                {
                    Console.WriteLine("Checka ut fordon");
                    //metod
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Flytta fordon/Byta plats");
                    // metod
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Hitta fordon");
                    // metod
                    break;
                }
            case 5:
                {
                    Console.WriteLine("Avsluta programmet.");
                    return;
                }
            default:
                Console.WriteLine("Felaktig inmatning! Försök igen.");  //Körs enbart om något villkor missas vid någon ändring och tar sig förbi.
                break;
        }
}




//Metoder:



string AngeRegNummer()
{
    Console.Write("Vänligen ange ditt regnr: ");
    string regNr = Console.ReadLine().ToUpper();
    return regNr;
}

static void SökaFordon(string[] garage)
{

}

static void TaBortFordon(string[] garage)
{

}

static void LäggaTillFordon(string[] garage)
{

}

static void HittaLedigPlats(string[] garage)
{

}


static void VisaLista(string[] garage)
{

}

static void TilldeladPlats(string[] garage)
{

}




static void ParkeraFordon(string[] parkering)
{
    Console.Write("Vill du parkera MC eller CAR? ");
    string fordon = Console.ReadLine().ToUpper();
    if (fordon == "MC")
    {
        string regNr = AngeRegNummer();
        for (int i = 0; i < parkering.Length; i++)
        {
            if (parkering[i] != null && parkering[i].StartsWith("MC") && (parkering[i].Contains("|") == false))
            {
                parkering[i] = parkering[i] + "|" + "MC" + "#" + regNr;
                break;
            }
            else if (parkering[i] == null)
            {
                parkering[i] = "MC" + "#" + regNr;
                break;
            }
            Console.WriteLine("Tyvärr, inga lediga platser för MC.");
        }
    }
    else if (fordon == "CAR")
    {
        string regNr = AngeRegNummer();
        for (int i = 0; i < parkering.Length; i++)
        {
            if (parkering[i] == null)
            {
                parkering[i] = "CAR" + "#" + regNr;
                break;
            }
            Console.WriteLine("Tyvärr, inga lediga platser.");
        }
    }
    else
    {
        Console.WriteLine("Ogiltigt svar. Ange MC eller CAR");
    }
}