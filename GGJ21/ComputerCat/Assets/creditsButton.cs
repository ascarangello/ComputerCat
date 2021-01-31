using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditsButton : MonoBehaviour
{
    public GameObject creditsPage;
    public GameObject mainMenu;
    // Start is called before the first frame update

    public Button yourButton;

    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        creditsPage.SetActive(true);
        mainMenu.SetActive(false);

    }
}
