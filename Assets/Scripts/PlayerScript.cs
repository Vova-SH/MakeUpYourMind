using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public GameObject playerModel;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerModel.transform.rotation = Quaternion.LookRotation(GetMousePosition());
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    Vector3 GetMousePosition()
    {
        Vector3 result = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
        Vector3 mouse = Input.mousePosition;
        mouse.z = mouse.y;
        mouse.y = 0;
        return mouse - result;
    }
}
