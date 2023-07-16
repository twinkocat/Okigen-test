using UnityEngine;


public class GameStateManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TouchInput _touchInput;

    public static GameStateManager Instance;

    private enum Scenes
    {
        GameScene
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (_touchInput == null)
            Debug.LogError("TouchInput component is not assigned!");
    }

    private void Start()
    {
        GameManager.Instance.OnGameWin += Victory;
    }


    private void Victory()
    {
        _touchInput.TurnOffInput();
    }

    public void NextLevel()
    {
        Restart();
    }    

    private void Restart()
    {
        LoadScene(Scenes.GameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void LoadScene(Scenes scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }

}
