using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] 
    private string _key;

    public string Key => _key;
}
