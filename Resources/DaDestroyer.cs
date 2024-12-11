using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaDestroyer : MonoBehaviour
{
    Game game;
    [SerializeField] AudioClip clip;

    GameObject destroy;

    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            game.gotEnemy();
            game.addScore(collision.gameObject.GetComponent<BalloonMovement>().GetScore());
            
            AudioSource.PlayClipAtPoint(clip, new Vector3 (0, 0, -5f), PlayerPrefs.GetFloat("CurrentVolume"));
            collision.gameObject.GetComponent<Animator>().SetBool("hit", true);

            destroy = collision.gameObject;
            Invoke("SelfDestruct",0.35f);
        }
    }

    private void SelfDestruct ()
    {
        Destroy(destroy);
        Destroy(this.gameObject);
    }
}
