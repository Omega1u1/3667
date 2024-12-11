using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject pin;
    Animator animator;

    private Rigidbody2D rigBod;
    private Transform playerTransform;
    private float horizMovement = 0;
    private int MOVE_SPEED = 5;
    private float JUMP_FORCE = 300.0f;
    private bool grounded = false;
    private bool facingRight = false;

    private float PIN_SPEED = 450.0f;

    Game game;

    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        rigBod= gameObject.GetComponent<Rigidbody2D>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }


    void Update()
    {
        
    }

    void FixedUpdate ()
    {
        horizMovement = Input.GetAxis("Horizontal");
        rigBod.velocity
            = new Vector2(horizMovement * MOVE_SPEED, rigBod.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rigBod.AddForce(new Vector2(0, JUMP_FORCE));
            grounded = false;
        }

        if (horizMovement > 0 && facingRight)
            facingRight = false;
        else if (horizMovement < 0 && !facingRight)
            facingRight = true;

        if (facingRight) playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        else playerTransform.rotation = Quaternion.Euler(0, 0, 0);


        if (Input.GetButtonDown("Fire1"))
            ShootPin();
    }

    void ShootPin()
    {
        GameObject card = Instantiate(pin, shootPosition.position, shootPosition.rotation);

        if (facingRight)
            card.GetComponent<Rigidbody2D>().velocity = new Vector2(-5,0);
        else
            card.GetComponent<Rigidbody2D>().velocity = new Vector2(5,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
            grounded = true;
        else if (collision.collider.CompareTag("Distractor"))
            game.reloadLevel();
    }
}
