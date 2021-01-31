using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Bomb spawned!");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bomb exploded!");
        Destroy(gameObject);
    }
}
