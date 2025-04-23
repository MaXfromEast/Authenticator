using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public void FirstMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSceneNo(int no)
    {
        SceneManager.LoadScene(no);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public int CurrentScene()
    {
        int scene;
        scene = SceneManager.GetActiveScene().buildIndex;
        return scene;
    }
}
