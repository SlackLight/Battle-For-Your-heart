using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject controlsPanel;
    // Start is called before the first frame update
    void Start()
    {
        controlsPanel.SetActive(false);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void ControlsMenu()
    {
        controlsPanel.SetActive(true);
    }

    void CloseControls()
    {
        controlsPanel.SetActive(false);
    }
}
