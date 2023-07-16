using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskView : View, IDisplayImage, IDisplayText
{
    [Header("Dependencies")]
    [SerializeField] private TMP_Text    _text;
    [SerializeField] private Image       _image;

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public override void Display()
    {
        gameObject.SetActive(true);
    }
}
