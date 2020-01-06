using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}