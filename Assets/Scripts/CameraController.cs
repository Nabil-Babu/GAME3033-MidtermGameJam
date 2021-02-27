using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private float horizontalDamping = 1f;
    private Transform _followTargetTransform;

    private Vector2 _previousMouseInput; 
        
    // Start is called before the first frame update
    void Start()
    {
        _followTargetTransform = followTarget.transform;
        _previousMouseInput = Vector2.zero;
    }

    public void OnLook(InputValue delta)
    {
        if (Time.timeScale == 0) return;
        Vector2 aimValue = delta.Get<Vector2>();
        _followTargetTransform.rotation *=
            Quaternion.AngleAxis(
                Mathf.Lerp(_previousMouseInput.x, aimValue.x, 1f / horizontalDamping) * rotationSpeed,
                transform.up
            );
            
        transform.rotation = Quaternion.Euler(0, _followTargetTransform.transform.rotation.eulerAngles.y, 0);
            
        _followTargetTransform.localEulerAngles = Vector3.zero;

        _previousMouseInput = aimValue;
    }
}
