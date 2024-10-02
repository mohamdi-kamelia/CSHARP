using System;
using System.IO;

public class Map
{
    static char[,] _map = new char[0, 0]; // Initialisation par défaut à une carte vide

    public static void ChargerCarte(string chemin)
    {
        if (!File.Exists(chemin))
        {
            Console.WriteLine("Le fichier de carte n'existe pas !");
            _map = new char[0, 0]; // Utilisation d'une carte vide si le fichier est introuvable
            return;
        }

        string[] lignes = File.ReadAllLines(chemin);
        _map = new char[lignes.Length, lignes[0].Length];

        for (int y = 0; y < lignes.Length; y++)
        {
            for (int x = 0; x < lignes[y].Length; x++)
            {
                _map[y, x] = lignes[y][x];
            }
        }
    }

    public static void AfficherCarte()
    {
        // Vérifier si la carte est chargée et qu'elle n'est pas vide
        if (_map.GetLength(0) == 0 || _map.GetLength(1) == 0)
        {
            Console.WriteLine("Erreur : La carte n'a pas été chargée.");
            return;
        }

        for (int y = 0; y < _map.GetLength(0); y++)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                switch (_map[y, x])
                {
                    case 'O':
                        Console.Write('~'); // Afficher l'eau
                        break;
                    case 'M':
                        Console.Write('^'); // Afficher les montagnes
                        break;
                    case 'F':
                        Console.Write('T'); // Afficher la forêt
                        break;
                    case 'C':
                        Console.Write('C'); // Afficher la ville
                        break;
                    case '.':
                        Console.Write('.'); // Afficher la terre
                        break;
                    default:
                        Console.Write(' '); // Afficher un espace par défaut
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
