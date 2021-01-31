using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float
        rotateMin = 10.0f,
        rotateMax = 40.0f;
    private float rotateSpeed;

    // bomb temp asset from: https://cdn.iconscout.com/icon/free/png-512/winrar-3-569260.png
    private void Start()
    {
        Debug.Log("Bomb spawned!");
        rotateSpeed = Random.Range(rotateMin, rotateMax);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bomb exploded!");
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
