using UnityEngine;

public class FinishPlatform : Platform
{
    private RestartGame _restartGame;
    private bool _endGame;

    private void Start()
    {
        _restartGame = FindObjectOfType<RestartGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_endGame && other.gameObject.GetComponent<Ball>())
        {
            _restartGame.GetComponent<Animator>().Play("StartRestartGame");
            _endGame = true;
        }
    }
}
