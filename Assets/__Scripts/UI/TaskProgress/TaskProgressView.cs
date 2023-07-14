using TMPro;
using UnityEngine;

public class TaskProgressView : View, IDisplayText
{
    [SerializeField] private TMP_Text _text;

    public void DisplayText(string text)
    {
        _text.text = text;
    }
}
