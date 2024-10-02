using System;

public class Player
{
    public string Nom { get; set; }
    public int PointsDeVie { get; private set; }
    public int PointsDeMagie { get; private set; }
    public int Attaque { get; set; }
    public int Defense { get; set; }
    public int Experience { get; private set; }
    public int Niveau { get; private set; }

    // Constructeur qui vérifie que le nom n'est pas null ou vide
    public Player(string nom)
    {
        if (string.IsNullOrWhiteSpace(nom))
        {
            throw new ArgumentException("Le nom ne peut pas être vide ou null.", nameof(nom));
        }
        Nom = nom;
        PointsDeVie = 100; // Valeur de départ
        PointsDeMagie = 50; // Valeur de départ
        Attaque = 20; // Valeur de départ
        Defense = 10; // Valeur de départ
        Experience = 0;
        Niveau = 1;
    }

    // Méthode pour attaquer un autre joueur
    public void Attaquer(Player cible)
    {
        if (cible == null) throw new ArgumentNullException(nameof(cible));
        
        if (cible.PointsDeVie > 0) // Vérifiez que la cible est toujours en vie
        {
            Console.WriteLine($"{Nom} attaque {cible.Nom} !");
            int degats = Attaque - cible.Defense;
            if (degats > 0)
            {
                cible.PointsDeVie -= degats;
                Console.WriteLine($"{cible.Nom} subit {degats} points de dégâts !");
            }
            else
            {
                Console.WriteLine($"{cible.Nom} bloque tous les dégâts !");
            }

            if (cible.PointsDeVie <= 0)
            {
                Console.WriteLine($"{cible.Nom} est KO !");
                GagnerExperience(50); // Gagne de l'expérience pour avoir vaincu un adversaire
            }
        }
        else
        {
            Console.WriteLine($"{cible.Nom} est déjà KO !");
        }
    }

    // Méthode pour gagner de l'expérience
    public void GagnerExperience(int points)
    {
        if (points < 0) throw new ArgumentOutOfRangeException(nameof(points), "Les points d'expérience doivent être positifs.");

        Experience += points;
        Console.WriteLine($"{Nom} gagne {points} points d'expérience !");
        if (Experience >= 100) // Seuil d'expérience pour passer au niveau supérieur
        {
            Niveau++;
            Experience = 0; // Réinitialiser l'expérience
            Console.WriteLine($"{Nom} passe au niveau {Niveau} !");
        }
    }

    // Méthode pour afficher les statistiques du joueur
    public void AfficherStatistiques()
    {
        string etat = PointsDeVie > 0 ? "En vie" : "KO";
        Console.WriteLine($"Nom: {Nom}, PV: {PointsDeVie}, PM: {PointsDeMagie}, Attaque: {Attaque}, Défense: {Defense}, Niveau: {Niveau}, Expérience: {Experience}, État: {etat}");
    }
}
