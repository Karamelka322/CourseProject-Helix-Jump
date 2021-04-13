using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject[] _bolts;

    private Rigidbody _rigidbody;
    private bool _jumping = true;
    private readonly float _delayTime = 0.2f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_jumping && collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            SpawnBlot(collision.contacts[0].point, collision.transform);

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            StartCoroutine(DelayJump());
        }
    }

    private void SpawnBlot(Vector3 point, Transform parent)
    {
        GameObject blot = Instantiate(_bolts[Random.Range(0, _bolts.Length)], point, Quaternion.Euler(-90, Random.Range(0, 360), 0), parent);
        Destroy(blot, .5f);
    }

    IEnumerator DelayJump()
    {
        _jumping = false;

        yield return new WaitForSeconds(_delayTime);

        _jumping = true;
    }
}
