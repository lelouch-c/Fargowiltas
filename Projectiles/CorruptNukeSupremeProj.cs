﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class CorruptNukeSupremeProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Items/Renewals/CorruptRenewalSupreme";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Nuke Supreme");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Shatter, projectile.Center);

            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.CorruptSpray, 0, 0, Main.myPlayer);
            }

            for (int x = -Main.maxTilesX; x < Main.maxTilesX; x++)
            {
                for (int y = -Main.maxTilesY; y < Main.maxTilesY; y++)
                {
                    int xPosition = (int)(x + projectile.Center.X / 16.0f);
                    int yPosition = (int)(y + projectile.Center.Y / 16.0f);

                    WorldGen.Convert(xPosition, yPosition, 1, 1); // Convert to corrupt
                }
            }
        }
    }
}