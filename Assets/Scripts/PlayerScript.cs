using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    
    public GameObject playerModel;
    [Header("Player characterisic")]
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public int lives = 5;
    [Header("Sound settings")]
    public AudioSource jumpSound;
    public AudioSource stepSound;


    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private ParticleSystem[] particleSystems;
    private float initialLives = 5;
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
        float forward = Input.GetAxis("Vertical") * speed;
        float right = Input.GetAxis("Horizontal") * speed;
        moveDirection = (transform.forward * forward) + (transform.right * right) + transform.up * moveDirection.y;

        if (characterController.isGrounded)
        {

            if (jumpSound.isPlaying) jumpSound.Stop();
            if(moveDirection.Equals(Vector3.zero) && stepSound.isPlaying) stepSound.Stop();
            else if (!moveDirection.Equals(Vector3.zero) && !stepSound.isPlaying && !jumpSound.isPlaying) stepSound.Play();

            if (Input.GetButton("Jump"))
            {
                jumpSound.Play();
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
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
