using UnityEngine;

public class SpawnerScore : MonoBehaviour
{
    [SerializeField] private Transform _textSpawnPiont;
    [SerializeField] private GameObject[] _textPrefabs;

    public void SpawnScore()
    {
        GameObject text = Instantiate(_textPrefabs[Random.Range(0, _textPrefabs.Length)], _textSpawnPiont);
        Destroy(text, 1f);
    }
}
