using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float minYPos = -2.5f;
    [SerializeField] private float maxYPos = 2.5f;
    // Update is called once per frame

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed * GameManager.Instance.GetLevel());
    }

    void Update()
    {
        if(!GameManager.Instance.isGameOver)
        {
            if(transform.position.y <= minYPos)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, speed * GameManager.Instance.GetLevel());
            }
            else if(transform.position.y >= maxYPos)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -speed * GameManager.Instance.GetLevel());
            }
        }
    }
}
