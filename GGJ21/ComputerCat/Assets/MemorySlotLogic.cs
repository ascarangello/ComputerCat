using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySlotLogic : MonoBehaviour
{
    public MemoryLogic.MemType thisType;
    public Sprite spriteOnInsert;
    public GameObject platformToActivate;
    [SerializeField] private GameObject interactText;
    private bool inRadius;
    private GameObject player;
    private bool filled = false;
    private bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        platformToActivate.SetActive(false);
        interactText.SetActive(false);
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
                GetComponent<SpriteRenderer>().sprite = spriteOnInsert;
                interactText.SetActive(false);
                platformToActivate.SetActive(true);
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
