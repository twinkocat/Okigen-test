using UnityEngine;


public class TaskController : Controller
{
    [Header("Dependencies")]
    [SerializeField] private TaskView       _view;

    private void Start()
    {
        SendDataToView();
        GameManager.Instance.OnGameWin += DisableIfWin;
    }

    protected override void SendDataToView()
    {
        _view.SetText
            (
                $"Collect {GameManager.Instance.FoodValueForCompleteTask} {GameManager.Instance.FoodForTask.FoodName}"
            ) ;
        _view.SetImage(GameManager.Instance.FoodForTask.Sprite);
        _view.Display();
    }

    private void DisableIfWin()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameWin -= DisableIfWin;
    }
}
