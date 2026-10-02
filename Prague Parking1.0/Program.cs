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
    Console.WriteLine("5. Visa parkeringsgaraget");
    Console.WriteLine("6. Avsluta programmet");

    // Skulle vilja gardera mig för felinmatning. Inte helt nöjd med denna lösning. Men får duga för nu.
    // Ogillar att menyn snurrar om varje gång det blir fel. Hade velat ha Försök igen bara.. Tror jag fått ordning nu.
    // Kanske onödigt men gillar att inte menyn visa om och om igen vid felaktig inmatning. 
    int alternativ;

    while (true)        //Loopar tills det uppfyller kriterierna för val i switch-case loopen.
    {
        Console.Write("Vänligen ange önskad åtgärd, alternativ 1-6: ");
        if (int.TryParse(Console.ReadLine(), out alternativ) && alternativ >= 1 && alternativ <= 6)
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
                ParkeraFordon();
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
                Console.WriteLine("Söka fordon");
                SökaFordon();
                break;
            }
        case 5:
            {
                Console.WriteLine("Visa parkeringsgaraget");
                VisaLista();
                break;
            }
        case 6:
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
    Console.Write("Vänligen ange regnr: ");
    string regNr = Console.ReadLine().ToUpper();
    return regNr;
}

void SökaFordon()
{
    string regNr = AngeRegNummer();
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        if (parkeringsGarage[i].Contains(regNr))
        {
            Console.WriteLine($"{regNr} finns på plats {(i + 1)}");
            Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
            Console.ReadKey(true);
        }
        if (parkeringsGarage[i].Contains(regNr) == false)
        {
            Console.WriteLine("Angivet regnr hittas ej i systemet.");
            Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
            Console.ReadKey(true);
        }
        break;
    }
}

void TaBortFordon(string[] parkeringsGarage)
{

}

void LäggaTillFordon(string[] parkeringsGarage)
{

}

void HittaLedigPlats(string[] parkeringsGarage)
{

}


void VisaLista()
{
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        Console.WriteLine($"Plats{i + 1}: {parkeringsGarage[i]}");
    }
    Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
    Console.ReadKey(true);
}

static void TilldeladPlats(string[] parkeringsGarage)
{

}




void ParkeraFordon()
{
    Console.Write("Vill du parkera MC eller CAR? ");
    string fordon = Console.ReadLine().ToUpper();
    if (fordon == "MC")
    {
        string regNr = AngeRegNummer();
        for (int i = 0; i < parkeringsGarage.Length; i++)
        {
            if (parkeringsGarage[i] != null && parkeringsGarage[i].StartsWith("MC") && (parkeringsGarage[i].Contains("|") == false))
            {
                parkeringsGarage[i] = parkeringsGarage[i] + "|" + "MC" + "#" + regNr;
                Console.WriteLine($"MC ska parkeras på plats {i + 1} ");
                Console.WriteLine("Tryck på valfri tanget för att återgå till menyn."); //Adderades för att användaren ska hinna se var
                                                                                        //fordonet ska parkeras innan återgång till menyn
                Console.ReadKey(true);
                break;
            }
            else if (parkeringsGarage[i] == null)
            {
                parkeringsGarage[i] = "MC" + "#" + regNr;
                Console.WriteLine($"Motorcykeln ska parkeras på plats {i + 1} ");
                Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
            else if (i == parkeringsGarage.Length - 1)
            {
                Console.WriteLine("Tyvärr, inga lediga platser för MC.");
            }
        }
    }
    else if (fordon == "CAR")
    {
        string regNr = AngeRegNummer();
        for (int i = 0; i < parkeringsGarage.Length; i++)
        {
            if (parkeringsGarage[i] == null)
            {
                parkeringsGarage[i] = "CAR" + "#" + regNr;
                Console.WriteLine($"Bilen ska parkeras på plats {i + 1} ");
                Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
            else if (i == parkeringsGarage.Length - 1)
            Console.WriteLine("Tyvärr, inga lediga platser.");
        }
    }
    else
    {
        Console.WriteLine("Ogiltigt svar. Ange MC eller CAR");
    }
}