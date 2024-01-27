using UnityEngine;

public class AmmoItem : Item,ICollectable
{
    public int amount;
    public WeaponBase _weaponBase;
    
    public Item Collect()
    {
        _weaponBase.CurrentAmmo.AddAmmo(amount);
        return this;
    }
}