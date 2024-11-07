using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
 
    private Transform balloonTransform;
    private Rigidbody2D body;

    private Vector3 ballonScaleGrowth;

    private float SPEED = 3;
    void Start ()
    {
        balloonTransform = gameObject.GetComponent<Transform>();
        body = gameObject.GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, SPEED);
    }

    void Update()
    {

    }

    void FixedUpdate ()
    {

        if (balloonTransform.position.y > 3)
            body.velocity = new Vector2(0, -1*SPEED);
        else if (balloonTransform.position.y < -3)
            body.velocity = new Vector2(0, SPEED);
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pin")
            gameObject.SetActive(false);
        
    }

}
