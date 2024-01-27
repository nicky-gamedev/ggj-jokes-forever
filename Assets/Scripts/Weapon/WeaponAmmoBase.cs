namespace Weapon
{
    public abstract class WeaponAmmoBase
    {
        private int _ammoInClip;
        public bool HasAmmo => _ammoInClip > 0;
    }
}