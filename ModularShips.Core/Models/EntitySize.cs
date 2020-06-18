namespace ModularShips.Core.Models
{
    public enum EntitySize
    {
        Fine = 1, // Mines, Missiles (4)
        Diminutive = 2, // Drones (8)
        Tiny = 3, // Fighters, Bombers (16)
        Small = 4, // Frigates (32)
        Medium = 5, // Cruisers (64)
        Large = 6, // Heavy cruisers, Battleships (128)
        Huge = 7, // Capitals (256)
        Gargantuan = 8, // Outposts (512)
        Colossal = 9 // Stations (1024)
    }
}
