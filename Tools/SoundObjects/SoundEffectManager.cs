using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.SoundObjects
{
    internal class SoundEffectManager
    {
        List<SoundEffect> SFX = new();
        ContentManager Content;
        public SoundEffectManager(ContentManager content)
        {
            this.Content = content;
        }

        // This is not ideal for now but I couldn't figure out a smarter way to do it
        public List<SoundEffect> FillEffects()
        {
            SFX.Add(Content.Load<SoundEffect>(Constants.AquaScreamLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.BossHitLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.DodongoScreamLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.EnemyDieLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.EnemyHitLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.OtherBossScream));
            SFX.Add(Content.Load<SoundEffect>(Constants.DoorUnlockLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.FoundSecretLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.KeyAppearLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.TextLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.TextSlowLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.WalkingStairsLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.ArrowBoomerangLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.BombBlowLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.BombDropLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.CandleLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.GetHeartLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.GetItemLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.GetRupeeLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.MagicRodLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.NewItemSongLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.ShieldDeflectLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.SwordCombinedLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.SwordShootLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.SwordSlashLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.LinkDieLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.LinkHurtLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.LowHealthLocation));
            SFX.Add(Content.Load<SoundEffect>(Constants.RefillHealthLocation));

            return SFX;

        }
    }
}
