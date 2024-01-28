using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] 
    private string dialog_key;
    private void OnTriggerEnter(Collider other)
    {
        var dialogComponent = other.GetComponent<CharacterDialog>();
        if (dialogComponent != null)
        {
            dialogComponent.ActivateDialog(dialog_key);
        }
    }
}
