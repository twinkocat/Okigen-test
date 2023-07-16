using TMPro;
using UnityEngine;

public class TaskProgressView : View, IDisplayText
{
    [SerializeField] private TMP_Text _text;

    public override void Display()
    {
        gameObject.SetActive(true);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
