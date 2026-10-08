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
 
    int val;
    
    while (true)        //Loopar tills det uppfyller kriterierna för val i switch-case loopen.
    {
        Console.Write("Vänligen ange önskad åtgärd, alternativ 1-6: ");
        if (int.TryParse(Console.ReadLine(), out val) && val >= 1 && val <= 6)
        {
            break;

        }
        Console.WriteLine("Felaktig inmatning. Försök igen");
    }
    switch (val)
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

string HittaFordonsTyp(int i)
{
    if (parkeringsGarage[i].Contains("CAR") && i != -1)
    {
        return "CAR";
    }
    else if (parkeringsGarage[i].Contains("MC") && i != -1)
    {
        return "MC";
    }
    else
    {
        return null;
    }
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
    TaBortFordon(i, regNr);

}

void TaBortFordon(int i, string regNr)
{
    if (parkeringsGarage[i].Contains('|') == false)
    {
        parkeringsGarage[i] = null;
        Console.WriteLine($"\nFordon: {regNr} har hämtats och plats {(i + 1)} är nu tom");
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
        Console.WriteLine($"\nFordon {regNr} har hämtats från plats {i + 1}");
    }
}

void FlyttaFordon()
{
    string regNr = AngeRegNummer();
    int i = IndexRegNr(regNr);
    string fordonstyp = HittaFordonsTyp(i);

    if (i == -1)
    {
        Console.WriteLine("\nAngivet registreringsnummer hittades ej.");
        return;
    }
    
    bool valdplatsledig = VäljaLedigPlats(fordonstyp, regNr, i);
    
    if (valdplatsledig == true && i >= 0 && i <= 100)
    {
        TaBortFordon(i, regNr);
    }


}

bool VäljaLedigPlats(string fordonstyp, string regNr, int i)        //Gör return true eller fasle beroende på om ledig plats hittas eller ej.
{
    VisaLista();
    Console.Write("Ange önskad ledig parkeringsplats (1-100): ");
    int.TryParse(Console.ReadLine(), out int valdPlats);

    int valtIndex = valdPlats - 1;      //konverterar "språkvalet" användaren gjort till korrekt index.

    if (fordonstyp == "MC")
    {
        if (parkeringsGarage[valtIndex] != null && parkeringsGarage[valtIndex].StartsWith("MC") && (parkeringsGarage[valtIndex].Contains("|") == false))
        {
            parkeringsGarage[valtIndex] = parkeringsGarage[valtIndex] + "|" + fordonstyp + "#" + regNr;
            Console.WriteLine($"{fordonstyp} ska parkeras på plats: {valtIndex + 1} ");
            return true;
        }
        else if (parkeringsGarage[valtIndex] == null)
        {
            parkeringsGarage[valtIndex] = "MC" + "#" + regNr;
            Console.WriteLine($"Motorcykeln ska parkeras på plats: {valtIndex + 1} ");
            return true;
        }
    }
    if (fordonstyp == "CAR" && parkeringsGarage[valtIndex] == null)
    {
        parkeringsGarage[valtIndex] = "CAR" + "#" + regNr;
        Console.WriteLine($"Bilen ska parkeras på plats: {valtIndex + 1} ");
        return true;
    }
    else
    {
        Console.WriteLine($"Valdplats {valdPlats} är ej ledig.");
        return false;
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
        if (parkeringsGarage[i] != null && parkeringsGarage[i].StartsWith("MC") && (parkeringsGarage[i].Contains("|") == false))    //Kollar på de platser som ej är tomma ifall det står en ensam MC där.
        {                                                                                                                         //Ska i så fall endast stå MC och inte ett skiljetecken för då står det två MC.
            parkeringsGarage[i] = parkeringsGarage[i] + "|" + "MC" + "#" + regNr;   //Lägger till | mellan två MC
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