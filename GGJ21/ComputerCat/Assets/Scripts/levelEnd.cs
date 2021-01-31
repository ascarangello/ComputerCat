using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Followed another brackeys tutorial for this:
// https://www.youtube.com/watch?v=CE9VOZivb3I
public class levelEnd : MonoBehaviour
{
    public Animator screenwipe;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, false));
        }
    }

    public IEnumerator LoadLevel(int index, bool loadDeath)
    {

        yield return new WaitForSeconds(0.5f);

        screenwipe.SetTrigger("LevelEnd");


        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);

    }
}
