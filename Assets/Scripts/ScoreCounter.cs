using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private SpawnerScore _spawnerScore;
    [SerializeField] private Text _score;

    private float counter = 0;

    private void Start()
    {
        PlusOneScore();
    }

    public void PlusOneScore()
    {
        _score.text = $"Score: {counter}";
        counter++;

        _spawnerScore.SpawnScore();
    }
}
