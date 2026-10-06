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
    Console.WriteLine();

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
                Console.WriteLine("\nParkera fordon");
                ParkeraFordon();
                Console.WriteLine("\nTryck på valfri tanget för att återgå till menyn."); //Upprepas efter varje case för att användaren ska hinna läsa informationen innan nytt menyval.
                Console.ReadKey(true);
                break;
            }
        case 2: //Normalt vill man ha detta i långa formatet då det oftare händer fler saker inom varje case.
            {
                Console.WriteLine("\nChecka ut fordon");
                CheckaUtFordon();
                Console.WriteLine("\nTryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
        case 3:
            {
                Console.WriteLine("\nFlytta fordon");
                FlyttaFordon();
                Console.WriteLine("\nTryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
        case 4:
            {
                Console.WriteLine("\nSöka fordon");
                HittaFordon();
                Console.WriteLine("\nTryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
        case 5:
            {
                Console.WriteLine("\nVisa parkeringsgaraget");
                VisaLista();
                Console.WriteLine("\nTryck på valfri tanget för att återgå till menyn.");
                Console.ReadKey(true);
                break;
            }
        case 6:
            {
                Console.WriteLine("\nAvsluta programmet.");
                return;
            }
        default:
            Console.WriteLine("\nFelaktig inmatning! Försök igen.");  //Körs enbart om något villkor missas vid någon ändring och tar sig förbi.
            Console.WriteLine();
            break;
    }
}




//Metoder:



string AngeRegNummer()
{
    Console.Write("\nVänligen ange regnr: ");
    string regNr = Console.ReadLine().ToUpper();
    return regNr;
}

int IndexRegNr(string regNr)
{
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        if (parkeringsGarage[i] == null)
        {
            continue;
        }
        string[] textDelar = parkeringsGarage[i].Split('#', '|');
        foreach (var del in textDelar)
        {
            if (del == regNr)
            {
                return i;
            }
        }

    }
    return -1;
}

void HittaFordon()
{
    string regNr = AngeRegNummer();
    int i = IndexRegNr(regNr);

    if (i >= 0 && i < 100)
    { 
        Console.WriteLine($"\n{regNr} finns på plats {(i + 1)}");
    }
    else
    {
        Console.WriteLine("\nAngivet regnr hittas ej i systemet.");
    }
}

void CheckaUtFordon()
{
    string regNr = AngeRegNummer();
    int i = IndexRegNr(regNr);

    if (i == -1)
    {
        Console.WriteLine("\nAngivet registreringsnummer hittades ej.");
        return;
    }
    if (parkeringsGarage[i].Contains('|') == false)
            {
        parkeringsGarage[i] = null;
        Console.WriteLine($"\nFordon: {regNr} har hämtats och plats {(i+1)} är nu tom");
    }
    else
    {
        string[] textDelar = parkeringsGarage[i].Split('|');
        if (textDelar[0].Contains(regNr))
        {
            parkeringsGarage[i] = textDelar[1];
        }
        else
        {
            parkeringsGarage[i] = textDelar[0];
        }
        Console.WriteLine($"\nFordon {regNr} har hämtats från plats {i+1}");
    }

}

int TaBortFordon()
{

}

void FlyttaFordon()
{
    string regNr = AngeRegNummer();
    int i = IndexRegNr(regNr);

    if (regNr.Contains(MC) = true)
    {
        ParkeraMC(regNr);
    }
    else
    {
        ParkeraBil(regNr);
    }
    CheckaUtFordon();
}

void HittaLedigPlats()
{
    VisaLista();

    Console.Write("Ange önskad plats att flytta fordonet till: ");
    int önskadplats.TryParse(Console.ReadLine()) out önskadplats;
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        if ((önskadplats - 1) == null)
        {
            parkeringsGarage[i] = (önskadplats - 1);

        }
    }

}


void VisaLista()
{
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        Console.WriteLine($"Plats{i + 1}: {parkeringsGarage[i]}");
    }
}




void ParkeraFordon()
{
    Console.Write("Vill du parkera MC eller CAR? ");
    string fordon = Console.ReadLine().ToUpper();
    if (fordon == "MC")
    {
        string regNr = AngeRegNummer();
        ParkeraMC(regNr);
        
    }
    else if (fordon == "CAR")
    {
        string regNr = AngeRegNummer();
        ParkeraBil(regNr);
    }
    else
    {
        Console.WriteLine("\nOgiltigt svar. Ange MC eller CAR");
    }
}

void ParkeraBil(string regNr)
{ 
    for (int i = 0; i < parkeringsGarage.Length; i++)
        {
            if (parkeringsGarage[i] == null)
            {
                parkeringsGarage[i] = "CAR" + "#" + regNr;
                Console.WriteLine($"Bilen ska parkeras på plats: {i + 1} ");
                break;
            }
            else if (i == parkeringsGarage.Length - 1)
            Console.WriteLine("Tyvärr, inga lediga platser.");
        }
}

void ParkeraMC(string regNr)
{
    for (int i = 0; i < parkeringsGarage.Length; i++)
    {
        if (parkeringsGarage[i] != null && parkeringsGarage[i].StartsWith("MC") && (parkeringsGarage[i].Contains("|") == false))
        {
            parkeringsGarage[i] = parkeringsGarage[i] + "|" + "MC" + "#" + regNr;
            Console.WriteLine($"MC ska parkeras på plats: {i + 1} ");
            break;
        }
        else if (parkeringsGarage[i] == null)
        {
            parkeringsGarage[i] = "MC" + "#" + regNr;
            Console.WriteLine($"Motorcykeln ska parkeras på plats: {i + 1} ");
            break;
        }
        else if (i == parkeringsGarage.Length - 1)
        {
            Console.WriteLine("Tyvärr, inga lediga platser för MC.");
        }
    }
}