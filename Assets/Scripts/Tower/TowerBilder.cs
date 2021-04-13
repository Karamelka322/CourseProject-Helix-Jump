using UnityEngine;

public class TowerBilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalyScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private GameObject _air;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startEndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => _levelCount / 2f + _startEndFinishAdditionalScale + _additionalyScale / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalyScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);
        SpawnAir(_air, ref spawnPosition, transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }    
    
    private void SpawnAir(GameObject air, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(air, spawnPosition, Quaternion.Euler(-90, 0, 0), parent);
        spawnPosition.y -= 1;
    }
}
