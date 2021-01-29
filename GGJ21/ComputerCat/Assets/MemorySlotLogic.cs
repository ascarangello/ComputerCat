using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySlotLogic : MonoBehaviour
{
    public MemoryLogic.MemType thisType;
    [SerializeField] private GameObject interactText;
    private bool inRadius;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactText.SetActive(false);
            inRadius = false;
        }
    }
}
