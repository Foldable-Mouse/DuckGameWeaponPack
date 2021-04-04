using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuckGame.FoldableMod
{
    [EditorGroup("FoldableMod|Guns")]
    class Blueie : Gun
    {
        public Blueie(float xval, float yval ) : base (xval, yval)
        {
            this.ammo = 7;
            this._ammoType = new AT9mm();
            this._fullAuto = false;
            this._fireWait = 15f;
            this._ammoType.range = 50f;
            this.ammoType.accuracy = 15f;
            this.ammoType.penetration = 1f;
            this._type = "gun";
            base.graphic = new SpriteMap(Mod.GetPath<FoldableMod>("blueie"), 29, 12);

            this.center = new Vec2(13f, 3f);
            this._fireRumble = RumbleIntensity.Kick;
            this.loseAccuracy = 10f;
            this.maxAccuracyLost = 1.2f;
            this.collisionOffset = new Vec2(-8f, -2f);
            this.collisionSize = new Vec2(16f, 9f);
            this._barrelOffsetTL = new Vec2(1f, 1.5f); //1, 1.5
            this._bulletColor = Color.BlueViolet;
            this._kickForce = 0f;
            this._numBulletsPerFire = 20;
            this._angle = 10f;
        }
        public override void OnPressAction()
        {
            if (this.ammo > 0)
            {
                for (int index = 0; index < 3; ++index)
                {
                    Vec2 vec2 = this.Offset(new Vec2(-9f, 0.0f));
                    Vec2 hitAngle = this.barrelVector.Rotate(Rando.Float(1f), Vec2.Zero);

                    int r = Rando.Int(0, 5);
                    if (r == 0)
                        this._fireSound = GetPath("sounds/blueie/duckgamelick1");
                    if (r == 1)
                        this._fireSound = GetPath("sounds/blueie/duckgamelick2");
                    if (r == 2)
                        this._fireSound = GetPath("sounds/blueie/duckgamelick3");
                    if (r == 3)
                        this._fireSound = GetPath("sounds/blueie/duckgamelick4");
                    if (r == 4)
                        this._fireSound = GetPath("sounds/blueie/duckgamelick5");
                }
            }
            this.Fire();
        }

    }

}
