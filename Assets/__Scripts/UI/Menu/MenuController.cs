using UnityEngine;

public class MenuController : Controller
{
    [SerializeField] private MenuView   _menuView;

    private void Start()
    {
        GameManager.Instance.OnGameWin += SendDataToView;
    }

    protected override void SendDataToView()
    {
        _menuView.Display();
        _menuView.OnNextLevelButtonClick += GameStateManager.Instance.NextLevel;
        _menuView.OnExitButtonClick += GameStateManager.Instance.ExitGame;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameWin -= SendDataToView;

        _menuView.OnNextLevelButtonClick -= GameStateManager.Instance.NextLevel;
        _menuView.OnExitButtonClick -= GameStateManager.Instance.ExitGame;
    }
}
