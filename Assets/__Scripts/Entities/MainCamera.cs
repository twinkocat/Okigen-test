using System.Collections;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [Header("VictoryTransitionPoint")]
    [SerializeField] private Transform  _transitionPoint;
    [SerializeField] private Transform  _lookAtPoint;

    [SerializeField] private float      _transitionTime;
    private Vector3                     _velocity = Vector3.zero;

    private void Start()
    {
        GameManager.Instance.OnGameWin += TransitionToVictoryPoint;
    }

    private void TransitionToVictoryPoint()
    {
        StartCoroutine(TransitionToPoint(_transitionPoint.position));
    }

    IEnumerator TransitionToPoint(Vector3 point)
    {
        while(Vector3.Distance(transform.position, _transitionPoint.position) > 0.01f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, point, ref _velocity, _transitionTime);
            transform.LookAt(_lookAtPoint);
            yield return null;
        }
    }

}
