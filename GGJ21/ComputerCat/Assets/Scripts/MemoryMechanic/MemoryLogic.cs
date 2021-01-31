using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLogic : MonoBehaviour
{
    public enum MemType { Purple, Orange, Aqua, Magenta, EMPTY };

    public MemType type;
    [SerializeField] private GameObject interactText;
    public Sprite Purple, Aqua, Orange, Magenta;
    private bool inRadius;
    private GameObject player;
    private bool take;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer startingSprite = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case MemType.Purple:
                startingSprite.sprite = Purple;
                break;
            case MemType.Aqua:
                startingSprite.sprite = Aqua;
                break;
            case MemType.Orange:
                startingSprite.sprite = Orange;
                break;
            case MemType.Magenta:
                startingSprite.sprite = Magenta;
                break;


        }
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRadius && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Z)))
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
