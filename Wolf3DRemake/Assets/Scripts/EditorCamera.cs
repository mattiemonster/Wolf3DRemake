using UnityEngine;

public class EditorCamera : MonoBehaviour
{
    [Header("Camera Properties")]
    public float zoomAmount = 3f;
    public float moveSpeed = 2f;
    public bool acceptInput = true;

    [Header("Keybinds")]
    public KeyCode toggleProjection = KeyCode.P;

    private float mouseWheel;
    private float horizontal;
    private float vertical;
    private bool projection = false; // False = perspective, true = orthrographic

    // Input polling 
    void Update()
    {
        if (!acceptInput) return;
        
        mouseWheel = Input.mouseScrollDelta.y;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(toggleProjection))
        {
            projection = !projection;
            GetComponent<Camera>().orthographic = projection;
        }
    }

    // Perform camera movement here
    void FixedUpdate()
    {
        if (mouseWheel != 0)
        {
            if (projection)
            {
                GetComponent<Camera>().orthographicSize += zoomAmount * -mouseWheel * 0.5f;
            } else
            {
                Vector3 pos = transform.position;
                pos.y += zoomAmount * -mouseWheel;
                transform.position = pos;
            }
        }

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 pos = transform.position;
            pos.x += horizontal * moveSpeed;
            pos.z += vertical * moveSpeed;
            transform.position = pos;
        }
    }

    public void ResetInput()
    {
        vertical = 0;
        horizontal = 0;
        mouseWheel = 0;
    }

}
