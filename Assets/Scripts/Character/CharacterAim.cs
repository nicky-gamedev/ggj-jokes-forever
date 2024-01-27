using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float raycastMaxDistance;

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300);
        if (Physics.Raycast(ray, out var hitInfo, raycastMaxDistance, raycastLayerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();
        return direction;
    }
}
