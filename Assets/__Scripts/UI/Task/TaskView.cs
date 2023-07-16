using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskView : View, IDisplayImage, IDisplayText
{
    [Header("Dependencies")]
    [SerializeField] private TMP_Text    _text;
    [SerializeField] private Image       _image;


    public void DisplayText(string text)
    {
        _text.text = text;
    }

    public void DisplayImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
