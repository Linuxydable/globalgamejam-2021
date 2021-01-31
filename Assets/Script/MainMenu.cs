using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    //public Transform soundManagerPrefab;

    //private MenuSelection menuSelection;
    List<Button> buttons;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("SoundManager") == null)
        {
            //Instantiate(soundManagerPrefab);
        }

        //menuSelection = new MenuSelection();
        buttons = new List<Button>();
        GetComponentsInChildren(/*menuSelection.*/buttons);
        foreach (Button button in /*menuSelection.*/buttons)
        {
            switch (button.name)
            {
                case "PlayButton":
                    button.onClick.AddListener(OnPlayClick);
                    break;
                case "QuitButton":
                    button.onClick.AddListener(OnQuitClick);
                    break;
                default:
                    Debug.LogWarning("No listener for " + button.name);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //menuSelection.UpdateSelection();
    }

    void OnPlayClick()
    {
        //SoundManager.instance.PlaySelectSound();
        SceneManager.LoadScene("LevelSelection");
    }

    void OnQuitClick()
    {
        //SoundManager.instance.PlaySelectSound();
        Application.Quit();
    }
}
