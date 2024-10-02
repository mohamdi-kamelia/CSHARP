using System;

class Menu
{
    static void Main(string[] args)
    {
        bool quitter = false;

        while (!quitter)
        {
            Console.Clear();
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine("1. Jouer");
            Console.WriteLine("2. Quitter");
            Console.WriteLine("=======================");
            Console.Write("Choisissez une option : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Jouer();
                    break;
                case "2":
                    quitter = true;
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix non valide. Appuyez sur une touche pour réessayer.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Jouer()
    {
        Console.Clear();
        Console.WriteLine("=== Bienvenue dans le jeu ===");
        
        // Création du joueur
        Console.Write("Entrez le nom de votre personnage : ");
        string nomJoueur = Console.ReadLine();

        try
        {
            Player joueur = new Player(nomJoueur); // Création d'un joueur

            // Chargement et affichage de la carte
            Map.ChargerCarte("../assets/map.txt"); 
            Map.AfficherCarte(); 

            // Affichage des statistiques du joueur
            joueur.AfficherStatistiques(); 
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        
        Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
}
