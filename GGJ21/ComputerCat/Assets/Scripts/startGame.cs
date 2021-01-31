using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject video;
    public GameObject mainMenu;
    // Start is called before the first frame update

    public Button yourButton;

    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        video.SetActive(true);
        mainMenu.SetActive(false);
        yourButton.interactable = false;
        StartCoroutine(waitAndLoad());

    }

    IEnumerator waitAndLoad()
    {
        yield return new WaitForSeconds(15.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
