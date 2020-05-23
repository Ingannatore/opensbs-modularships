using ModularShips.Entities;
using ModularShips.Models;

namespace ModularShips.Templates.Modules.Shields
{
    public class SmallMultiLayerShield : DefenseTemplate
    {
        public SmallMultiLayerShield()
        {
            Id = "shield:small:multilayer";
            Name = "Multi-Layer Shield Generator";
            Description = "A shield generator used primarily to defend against kinetic damage";
            Size = EntitySize.Small;
            Hitpoints = 40;
            Mass = 500;
            Value = 25000;

            ActivationCost = 200000;
            ActivationTime = 1;
            SingleActivation = false;

            ShieldCapacity = DefenseCapacity.Create(150);
            Resistances = DamageResistances.Create(0.5f, 0.2f, 0.1f);
            RegenerationRate = 10;
        }
    }
}
