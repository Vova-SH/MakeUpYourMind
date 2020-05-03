using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoChangeScene : MonoBehaviour
{
    public string sceneName;
    private void Start()
    {
        SceneManager.LoadScene(sceneName);
    }
}
