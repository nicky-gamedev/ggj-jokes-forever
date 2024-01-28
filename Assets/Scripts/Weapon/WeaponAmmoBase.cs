public abstract class WeaponAmmoBase
{
    protected int _ammoInClip;
    public int AmmoInClip => _ammoInClip;
    public bool HasAmmo => _ammoInClip > 0;

    public void AddAmmo(int amount) => _ammoInClip += amount;
}