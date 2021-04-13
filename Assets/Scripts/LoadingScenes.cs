using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScenes: MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
