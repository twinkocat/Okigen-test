using UnityEngine;


public class TaskController : Controller
{
    [Header("Dependencies")]
    [SerializeField] private TaskView       _view;

    private void Start()
    {
        SendDataToView();
    }

    protected override void SendDataToView()
    {
        _view.DisplayImage(GameManager.Instance.FoodForTask.Sprite);
        _view.DisplayText
            (
                $"Collect {GameManager.Instance.FoodValueForCompleteTask} {GameManager.Instance.FoodForTask.FoodName}"
            ) ;
    }
}
