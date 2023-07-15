using UnityEngine;
using UnityEngine.SceneManagement;




public class GameStateManager : MonoBehaviour
{
    public enum Scenes
    {
        GameScene
    }

    private void Start()
    {
        GameManager.Instance.OnGameWin += Victory;
    }


    private void Victory()
    {
        TouchInput.Instance.TurnOffInput();
    }

    public void NextLevel()
    {
        Restart();
    }    

    private void Restart()
    {
        SceneManager.LoadScene((int)Scenes.GameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
