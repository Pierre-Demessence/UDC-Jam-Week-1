using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour
{
    public void GoGame()
    {
        SceneManager.LoadScene("Game");
    }
}