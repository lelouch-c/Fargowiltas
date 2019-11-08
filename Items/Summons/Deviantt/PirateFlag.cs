using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PirateFlag : DevianttSummon
    {
        public override int summonType => NPCID.PirateCaptain;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate Flag");
            Tooltip.SetDefault("Summons Pirate Captain\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}