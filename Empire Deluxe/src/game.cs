class Game(Player player)
{
    private string state = "listening";

    private void MoveCharacterUp(Player player, char[,] map)
{
    if (player.PositionY - 1 >= 0 && map[player.PositionY - 1, player.PositionX] == ' ')
    {
        player.PositionY--;
        Console.Clear();
        Map.PlacePlayer(player);
        Map.AfficherCarte();
        Map.ClearPlayer(player);
    }
    else 
    {
        Console.WriteLine("Vous ne pouvez pas aller ici.");
    }
}

    private void MoveCharacterDown(Player player, char[,] map)
    {
        if (player.PositionY + 1 < map.GetLength(0) && map[player.PositionY + 1, player.PositionX] == ' ')
        {
            player.PositionY++;
            Console.Clear();
            Map.PlacePlayer(player);
            Map.AfficherCarte();
            Map.ClearPlayer(player);
        }
        else 
        {
            Console.WriteLine("Vous ne pouvez pas aller ici.");
        }
    }

    private void MoveCharacterLeft(Player player, char[,] map)
    {
        if (player.PositionX - 1 >= 0 && map[player.PositionY, player.PositionX - 1] == ' ')
        {
            player.PositionX--;
            Console.Clear();
            Map.PlacePlayer(player);
            Map.AfficherCarte();
            Map.ClearPlayer(player);
        }
        else 
        {
            Console.WriteLine("Vous ne pouvez pas aller ici.");
        }
    }

    private void MoveCharacterRight(Player player, char[,] map)
    {
        if (player.PositionX + 1 < map.GetLength(1) && map[player.PositionY, player.PositionX + 1] == ' ')
        {
            player.PositionX++;
            Console.Clear();
            Map.PlacePlayer(player);
            Map.AfficherCarte();
            Map.ClearPlayer(player);
        }
        else 
        {
            Console.WriteLine("Vous ne pouvez pas aller ici.");
        }
    }

    public void Start()
    {
        Map.ChargerCarte("../assets/map.txt");
        char[,] map = Map.GetMap();
        Map.PlacePlayer(player);
        Map.AfficherCarte();
        Map.ClearPlayer(player);

        while (state == "listening")
        {
            string direction = Console.ReadKey().KeyChar.ToString();
            switch (direction)
                {
                    case "z":
                        Console.WriteLine(player.PositionX + " " + player.PositionY);
                        MoveCharacterUp(player, map);
                        break;

                    case "s":
                        Console.WriteLine(player.PositionX + " " + player.PositionY);
                        MoveCharacterDown(player, map);
                        break;

                    case "q":
                        Console.WriteLine(player.PositionX + " " + player.PositionY);
                        MoveCharacterLeft(player, map);
                        break;

                    case "d":
                        Console.WriteLine(player.PositionX + " " + player.PositionY);
                        MoveCharacterRight(player, map);
                        break;
                        
                    default:
                        Console.WriteLine("Direction non valide.");
                        break;
                }
        }
    }
}


