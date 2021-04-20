using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Join()
    {
        Debug.Log("Join CALLED");
    }
    
    public void Host()
    {
        SceneManager.LoadScene("Hosting");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
