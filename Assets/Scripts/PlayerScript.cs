using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public GameObject playerModel;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public int lives = 5;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    public ParticleSystem[] particleSystems;
    public float initialLives = 5;

    void Start()
    {
        initialLives = lives;
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        characterController = GetComponent<CharacterController>();
        var emission = particleSystems[0].emission;
        emission.enabled = false;
        emission = particleSystems[1].emission;
        emission.enabled = false;
    }

    void Update()
    {
        playerModel.transform.rotation = Quaternion.LookRotation(GetMousePosition());
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
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

    public void SetDamage(int damage)
    {
        lives -= damage;
        var emission = particleSystems[1].emission;
        emission.enabled = false;
        emission.rateOverTime = 100 * (1 - lives / initialLives);
        emission.enabled = true;
        if (lives / initialLives < 0.5f)
        {
            emission = particleSystems[0].emission;
            emission.enabled = false;
            emission.rateOverTime = 100 * (1 - lives / initialLives);
            emission.enabled = true;
        }
        //todo: add end level
        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
