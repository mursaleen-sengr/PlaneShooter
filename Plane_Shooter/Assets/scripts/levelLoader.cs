using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class levelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reload()
    {
        SceneManager.LoadScene("GameLevel1");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
