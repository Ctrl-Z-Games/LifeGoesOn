using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypressAnimate : MonoBehaviour
{
    public Sprite[] frames;
    public KeyCode key;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = frames[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            spriteRenderer.sprite = frames[1];
        }

        if (Input.GetKeyUp(key)) {
            spriteRenderer.sprite = frames[0];
        }
    }
}
