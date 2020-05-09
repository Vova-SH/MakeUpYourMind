using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
