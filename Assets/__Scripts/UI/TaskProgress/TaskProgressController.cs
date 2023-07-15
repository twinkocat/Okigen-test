using UnityEngine;

public class TaskProgressController : Controller
{
    [Header("Dependencies")]
    [SerializeField] private TaskProgressView       _view;
    [SerializeField] private FoodCollectCounter     _counter;


    private void Start()
    {
        GameManager.Instance.OnCollectedFoodValueChange += OnCollectedTasksFoodEventListener;
        SendDataToView();

    }

    protected override void SendDataToView()
    {
        _view.DisplayText
            (
                $"Progress: {GameManager.Instance.CurrentFoodCollected}/{GameManager.Instance.FoodValueForCompleteTask}"
            );
    }

    private void OnCollectedTasksFoodEventListener()
    {
        SendDataToView();
    }

    private void OnDestroy()
    {
        _counter.OnCollectedTasksFood -= OnCollectedTasksFoodEventListener;
    }
}
