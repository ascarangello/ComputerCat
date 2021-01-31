using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // bomb temp asset from: https://cdn.iconscout.com/icon/free/png-512/winrar-3-569260.png
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
