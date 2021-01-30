using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLogic : MonoBehaviour
{
    public enum MemType { Gray, Blue, Green, Red, EMPTY };

    public MemType type;
    [SerializeField] private GameObject interactText;
    public Color grayColor, blueColor, greenColor, redColor;
    private bool inRadius;
    private GameObject player;
    private bool take;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer startingSprite = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case MemType.Gray:
                startingSprite.color = grayColor;
                break;
            case MemType.Green:
                startingSprite.color = greenColor;
                break;
            case MemType.Blue:
                startingSprite.color = blueColor;
                break;
            case MemType.Red:
                startingSprite.color = redColor;
                break;


        }
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRadius && Input.GetKeyDown(KeyCode.Z))
        {
            take = true;
        }
    }

    private void FixedUpdate()
    {
        if(take)
        {
            take = false;
            player.GetComponent<MemHolder>().takeMem(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            interactText.SetActive(true);
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactText.SetActive(false);
            inRadius = false;
        }
    }
}
