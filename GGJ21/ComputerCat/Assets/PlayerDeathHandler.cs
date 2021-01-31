using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    private Animator anims;
    private Rigidbody2D rb;
    public AudioSource footsteps;
    public levelEnd loader;

    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (footsteps.isPlaying)
            {
                footsteps.Stop();
            }

            anims.SetTrigger("Sad");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(loader.LoadLevel(SceneManager.GetActiveScene().buildIndex, true));
        }
    }
}
