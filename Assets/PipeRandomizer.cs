using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRandomizer : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)] as Sprite;
    }

}
