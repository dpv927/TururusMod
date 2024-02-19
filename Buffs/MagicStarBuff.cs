using Terraria.ModLoader;
using Terraria;
using TururusMod.Projectiles.Summon;

namespace TururusMod.Buffs { 

    public class MagicStarBuff : ModBuff {

        public override void Update(Player player, ref int buffIndex) {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<MagicStar>()] > 0)
                player.buffTime[buffIndex] = 18000;
            else {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
