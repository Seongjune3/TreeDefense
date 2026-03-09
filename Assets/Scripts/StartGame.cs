using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.tutorialClear = true;
        GameManager.Instance.treeCoin += 1;
    }
}
