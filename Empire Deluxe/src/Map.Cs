public class Map
{
    static char[,] _map = new char[0, 0]; // Initialisation par défaut à une carte vide

    public static void ChargerCarte(string chemin)
    {
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", chemin);
        Console.WriteLine($"Trying to load map from: {fullPath}");

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("Le fichier de carte n'existe pas !");
            _map = new char[0, 0]; // Utilisation d'une carte vide si le fichier est introuvable
            return;
        }

        string[] lignes = File.ReadAllLines(fullPath);
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
                Console.Write(_map[y, x]);
            }
            Console.WriteLine();
        }
    }
    public static void PlacePlayer(Player player)
    {
        if (_map.GetLength(0) == 0 || _map.GetLength(1) == 0)
        {
            Console.WriteLine("Erreur : La carte n'a pas été chargée.");
            return;
        }

        if (player.PositionX < 0 || player.PositionX >= _map.GetLength(1) ||
            player.PositionY < 0 || player.PositionY >= _map.GetLength(0))
        {
            Console.WriteLine("Erreur : Position du joueur en dehors des limites de la carte.");
            return;
        }

        _map[player.PositionY, player.PositionX] = 'P';
    }

    public static void ClearPlayer(Player player)
    {
        _map[player.PositionY, player.PositionX] = ' ';
    }

    public static char[,] GetMap()
    {
        return _map;
    }
}
