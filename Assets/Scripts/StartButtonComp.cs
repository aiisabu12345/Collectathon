using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonComp : MonoBehaviour
{
    
    public void OnpressStartButton()
    {
        SceneManager.LoadScene("gameplay");
    }
}
