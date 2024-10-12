using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float speed = 10.5f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(-speed * GameManager.Instance.GetLevel(), rb2d.velocity.y);

        if(GameManager.Instance.isGameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
