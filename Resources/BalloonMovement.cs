using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    public int score = 0;
    private Game game;
 
    private Transform balloonTransform;
    private Rigidbody2D body;

    private float balloonScaleGrowth = 1.05f;
    private float balloonScaleLimit = 0.16f;

    private float potential = 1.0f;
    private float SPEED = 3;
    void Start ()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        balloonTransform = gameObject.GetComponent<Transform>();
        body = gameObject.GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, SPEED);
        game.setEnemy();
        InvokeRepeating("GrowSize", 5.0f, 0.25f);
    }

    public int GetScore()
    {
        return (int)(score * potential);
    }

    void Update()
    {
        if (balloonTransform.localScale.x >= balloonScaleLimit)
        {   game.reloadDelayed();
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate ()
    {
        if (balloonTransform.position.y > 3)
            body.velocity = new Vector2(0, -1*SPEED);
        else if (balloonTransform.position.y < -3)
            body.velocity = new Vector2(0, SPEED);
    }
    private void GrowSize ()
    {
        balloonTransform.localScale =
        new Vector3
        (balloonTransform.localScale.x*balloonScaleGrowth,
        balloonTransform.localScale.y*balloonScaleGrowth,
        balloonTransform.localScale.z*balloonScaleGrowth);

        potential -= 0.1f;
    }
}
