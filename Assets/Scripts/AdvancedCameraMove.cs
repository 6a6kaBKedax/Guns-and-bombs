using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraMove : MonoBehaviour
{
    public float mouseSensetive = 100f;
    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;
    public PlayerMovement move;

    public bool isLocked = false;
    void Update()
    {
        if (isLocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensetive;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensetive;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(xRotation, 0f, 0f), 0.5f);

            playerBody.rotation = Quaternion.Lerp(playerBody.rotation, Quaternion.Euler(0f, yRotation, 0f), 0.5f);
        }
    }

    public void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isLocked = true;
        move.enabled = true;
    }

    public void releaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        isLocked = false;
        move.enabled = false;
    }

    void Start()
	{
        lockCursor();
    }

}