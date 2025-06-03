using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSignal(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
