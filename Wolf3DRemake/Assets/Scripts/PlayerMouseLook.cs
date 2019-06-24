using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    Vector2 rotation = new Vector2(0, 0);
    [Header("References")]
    public GameObject player;
    [Header("Properties")]
    public float speed = 3;

    private bool cursorLocked = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }

    void Update()
    {
        if (cursorLocked)
        {
            rotation.y += Input.GetAxis("Mouse X");
            player.transform.eulerAngles = (Vector2)rotation * speed;
            transform.eulerAngles = (Vector2)rotation * speed;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && cursorLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            cursorLocked = false;
        }

        if (Input.GetMouseButtonDown(0) && !cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorLocked = true;
        }
    }
}
