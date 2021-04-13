using System.Collections;
using UnityEngine;

public class RestartGame : LoadingScenes
{
    public void OnRestartGame()
    {
        StartCoroutine(Restart(1.2f));
    }

    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        LoadScene("Main");
    }
}
