using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float gravity = 20.0f;
    public bool acceptInput = true;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!acceptInput) return;

        float horizInput = Input.GetAxis("Horizontal") * speed;
        float vertInput = Input.GetAxis("Vertical") * speed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        characterController.SimpleMove(forwardMovement + rightMovement);
    }
}
