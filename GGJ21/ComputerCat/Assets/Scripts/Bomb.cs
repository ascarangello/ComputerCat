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

    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource explosion;


    // bomb temp asset from: https://cdn.iconscout.com/icon/free/png-512/winrar-3-569260.png
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        explosion = GetComponent<AudioSource>();
        Debug.Log("Bomb spawned!");
        rotateSpeed = Random.Range(rotateMin, rotateMax);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bomb exploded!");
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.localRotation = Quaternion.identity;
        anim.SetBool("explode", true);
        explosion.Play();
        yield return new WaitForSeconds(0.466f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
