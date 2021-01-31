using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MemoryLogic;

public class MemorySlotLogic : MonoBehaviour
{
    public MemoryLogic.MemType thisType;
    public GameObject platformToActivate;
    public Sprite Purple, Aqua, Orange, Magenta;
    [SerializeField] private GameObject interactText;
    private bool inRadius;
    private GameObject player;
    private bool filled = false;
    private bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        SpriteRenderer startingSprite = GetComponent<SpriteRenderer>();
        switch (thisType)
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
    }

    // Update is called once per frame
    void Update()
    {
        if(inRadius && !filled && Input.GetKeyDown(KeyCode.Z))
        {
            interact = true;
        }
    }

    private void FixedUpdate()
    {
        if(interact)
        {
            MemHolder playerInv = player.GetComponent<MemHolder>();
            if(playerInv.getMemType() == thisType)
            {
                playerInv.insertMem();
                interact = false;
                filled = true;
                interactText.SetActive(false);
                platformToActivate.GetComponent<MemPlatformLogic>().activate();
            }
            interact = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!filled && collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            interactText.SetActive(true);
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!filled && collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactText.SetActive(false);
            inRadius = false;
        }
    }
}
