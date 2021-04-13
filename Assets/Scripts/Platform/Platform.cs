using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _damageAllocatePrefab;

    private readonly float _bounceForce = 1000f;
    private readonly float _bounceRadius = 200f;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }

        GameObject effect = Instantiate(_damageAllocatePrefab, transform.position, Quaternion.Euler(90, 0, 0));
        
        Destroy(effect, 1f);
        Destroy(gameObject, 5);
    }
}
