using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class MenuView : View
{
    [SerializeField] private Button     _nextLevelButton;
    [SerializeField] private Button     _exitButton;

    public event UnityAction            OnNextLevelButtonClick;
    public event UnityAction            OnExitButtonClick;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public override void Display()
    {
        AddListeners();
        gameObject.SetActive(true);
    }

    private void AddListeners()
    {
        _nextLevelButton.onClick.AddListener(() => OnNextLevelButtonClick?.Invoke());
        _exitButton.onClick.AddListener(() => OnExitButtonClick?.Invoke());
    }

    private void OnDestroy()
    {
        _nextLevelButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }
}
