using UnityEngine;

public class AmmoItem : Item,ICollectable
{
    public Item Collect()
    {
        return this;
    }
}