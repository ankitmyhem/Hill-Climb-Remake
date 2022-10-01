using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
