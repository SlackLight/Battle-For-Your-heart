using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
