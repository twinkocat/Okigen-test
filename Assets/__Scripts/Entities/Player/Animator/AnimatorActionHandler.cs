using System;
using UnityEngine;

public class AnimatorActionHandler : MonoBehaviour
{
    public event Action OnTrowingAnimationAction;


    public void TrowingAction()
    {
        OnTrowingAnimationAction?.Invoke();
    }
}
