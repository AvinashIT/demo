using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    [SerializeField] private float sensitivity;
private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        rotate();
    }
    private void rotate()
    {
        float mouse_x = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        parent.Rotate(Vector3.up,mouse_x);
    }

}
