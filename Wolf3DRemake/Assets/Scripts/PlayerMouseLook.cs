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

        //if (Input.GetKeyDown(KeyCode.Escape) && cursorLocked)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    cursorLocked = false;
        //}

        //if (Input.GetMouseButtonDown(0) && !cursorLocked
        //    && !(GameObject.Find("Manager").GetComponent<LevelManager>().IsPauseMenuOpen()))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //    cursorLocked = true;
        //}
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
    }
}
