using UnityEngine;

public class Ball : MonoBehaviour
{
    private ScoreCounter _scoreCounter;
    private GameObject _nowPlatformCollision;

    private void Awake()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {
            if (_nowPlatformCollision != other.gameObject)
            {
                other.GetComponentInParent<Platform>().Break();
                _scoreCounter.PlusOneScore();

                _nowPlatformCollision = other.gameObject;
            }
        }
    }
}
