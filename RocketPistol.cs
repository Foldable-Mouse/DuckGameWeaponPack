using System;

namespace DuckGame.FoldableMod
{
    [EditorGroup("FoldableMod|Guns")]
    public class RocketPistol : Gun
    {
        public RocketPistol(float xval, float yval) : base(xval, yval)
        {
            this.ammo = 10;
            this._ammoType = new ATMissile();
            this._fullAuto = true;
            this._ammoType.range = 250f;
            this._ammoType.accuracy = .6f;
            this._ammoType.penetration = 1f;
            this._type = "gun";
            base.graphic = new SpriteMap(Mod.GetPath<FoldableMod>("rocketpistol"), 16, 19);
            this.center = new Vec2(8f, 12.5f);
            this.collisionOffset = new Vec2(-8f, -7f);
            this.collisionSize = new Vec2(16f, 9f);
            this._barrelOffsetTL = new Vec2(16f, 7f);
            this._holdOffset = new Vec2(1f, 1.5f);
            this._fireSound = GetPath("sounds/Boing_01");
            this._kickForce = 3f;
            this.loseAccuracy = 0.2f;
            this.maxAccuracyLost = 0.8f;
        }
    }
}
