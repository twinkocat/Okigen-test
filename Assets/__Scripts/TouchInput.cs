using System;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private LayerMask _rayCastTargetMask;

    private bool                        _enabled;
    private Camera                      _cameraMain;
    private Ray                         _ray;

    public static TouchInput            Instance;

    public event Action<Vector3>        OnLayerMaskTargetTouch;
    public event Action                 OnLayerMaskTargetUntouch;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _cameraMain = Camera.main;
        if (_cameraMain == null)
        {
            Debug.LogError("No main camera found!");
        }

        TurnOnInput();
    }

    public void TurnOnInput()
    {
        _enabled = true;
    }

    public void TurnOffInput()
    {
        _enabled = false;
    }

    void Update()
    {

        if (!_enabled || Input.touchCount == 0)
        {
            OnLayerMaskTargetUntouch?.Invoke();
            return;
        }

        _ray = _cameraMain.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        
        if (Physics.Raycast(_ray, out hit, float.MaxValue, _rayCastTargetMask))
        {
            OnLayerMaskTargetTouch?.Invoke(hit.point);
        }
    }
}
