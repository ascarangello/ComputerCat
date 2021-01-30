using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemPlatformLogic : MonoBehaviour
{
    public Sprite afterActivation;
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        GetComponent<SpriteRenderer>().sprite = afterActivation;
        col.enabled = true;
    }
}
