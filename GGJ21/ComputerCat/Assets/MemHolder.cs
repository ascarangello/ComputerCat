using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject heldMem = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeMem(GameObject mem)
    {
        if (heldMem == null)
        {
            heldMem = mem;
            heldMem.SetActive(false);
        }
    }

    public void dropMem()
    {
        if (heldMem != null)
        {
            heldMem.transform.position = transform.position;
            heldMem.SetActive(true);
            heldMem = null;
        }
    }

    public void insertMem()
    {
        if (heldMem != null)
        {
            heldMem = null;
        }
    }

    public MemoryLogic.MemType getMemType()
    {   if (heldMem == null)
        {
            return MemoryLogic.MemType.EMPTY;
        }
        return heldMem.GetComponent<MemoryLogic>().type;
    }
}
