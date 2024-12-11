using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DistractorMovement : MonoBehaviour
{

    public float SPEED = -100f;
    private Transform tr;
    Rigidbody2D rb;

    private readonly float[] maximaPosition =
    { -2.0f, 4.0f };


    void Start ()
    {
        tr = gameObject.GetComponent<Transform>();
        System.Random gen = new System.Random();
        tr.position = new Vector3(10f, Random.Range(maximaPosition[0], maximaPosition[1]), 0f);
        rb = gameObject.GetComponent<Rigidbody2D>();

        Invoke("Summon", Random.Range(0, 5));
    }
    
    void Summon ()
    {
        rb.AddForce(new Vector2(SPEED, 0));
    }
}
