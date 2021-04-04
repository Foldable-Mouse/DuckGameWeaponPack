using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuckGame.FoldableMod
{
    [EditorGroup("FoldableMod|Guns")]
    class SquidShotgun : Gun
    {
        private SpriteMap _barrelSteam;
        private SpriteMap _netGunGuage;
        public SquidShotgun(float xval, float yval) : base(xval, yval)
        {
            this.ammo = 2;
            this._ammoType = new ATLaser();
            this._fullAuto = false;
            this._ammoType.range = 5000f; //very long range
            this._ammoType.accuracy = 3f;
            this._ammoType.penetration = 1f;
            this.isFatal = false;
            this._type = "gun";
            base.graphic = new SpriteMap(Mod.GetPath<FoldableMod>("squidgun"), 29, 12);

            this._barrelSteam = new SpriteMap("steamPuff", 16, 16);
            this._barrelSteam.center = new Vec2(0.0f, 14f);
            this._barrelSteam.AddAnimation("puff", 0.4f, false, 0, 1, 2, 3, 4, 5, 6, 7);
            this._barrelSteam.SetAnimation("puff");
            this._barrelSteam.speed = 0.0f;

            this.center = new Vec2(8f, 9.5f);
            this.collisionOffset = new Vec2(-8f, -7f);
            this.collisionSize = new Vec2(16f, 9f);
            this._barrelOffsetTL = new Vec2(16f, 1f);
            this._holdOffset = new Vec2(1f, 1.5f);
            this._fireSound = "smg"; //firesound
            this._kickForce = 10f;
            this._numBulletsPerFire = 1;
        }

        public override void OnPressAction()
        {
            if (this.ammo > 0)
            {
                //NetGun ammunition physics, modified with for loop for multiple nets:
                --this.ammo;
                for (int i = 0; i < 5; i++)
                {

                    Random rnd = new Random();
                    if (this.duck != null)
                        RumbleManager.AddRumbleEvent(this.duck.profile, new RumbleEvent(this._fireRumble, RumbleDuration.Pulse, RumbleFalloff.None));
                    SFX.Play("netGunFire");
                    this._barrelSteam.speed = 1f;
                    this._barrelSteam.frame = 0;
                    Vec2 vec2 = this.Offset(this.barrelOffset);
                    if (this.receivingPress)
                        return;
                    Net net = new Net(vec2.x + Rando.Float(-5, 5), vec2.y - 2f + Rando.Float(-5,5), this.duck);
                    Level.Add((Thing)net);
                    /* FLAMETHROWER RANDOM FIRE: (Similar mechanics used)
                        Vec2 vec = Maths.AngleToVec(this.barrelAngle + Rando.Float(-0.5f, 0.5f));
                        Vec2 vec2 = new Vec2(vec.x * Rando.Float(2f, 3.5f), vec.y * Rando.Float(2f, 3.5f));
                        this.ammo -= 2;
                        Level.Add((Thing) SmallFire.New(this.barrelPosition.x, this.barrelPosition.y, vec2.x, vec2.y, firedFrom: ((Thing) this)));
                    */

                    this.Fondle((Thing)net);
                    if (this.owner != null)
                        net.responsibleProfile = this.owner.responsibleProfile;
                    net.clip.Add(this.owner as MaterialThing);
                    net.hSpeed = this.barrelVector.x * 10f + Rando.Float(-5, 5);
                    net.vSpeed = (float)((double)this.barrelVector.y * 7.0 - 1.5);
                }
                this.ApplyKick();
            }
            else
                this.DoAmmoClick();
        }
    }
}
