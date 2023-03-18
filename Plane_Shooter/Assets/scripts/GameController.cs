using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameoverPannel;
    public GameObject levelCompletePannel;
    public GameObject EndText;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        levelCompletePannel.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameoverPannel.SetActive(false);
        EndText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale= 0f;
    }
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public IEnumerator levelComplete()
    {
        yield return new WaitForSeconds(2f);
        EndText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelCompletePannel.SetActive(true);
        
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void gameOver()
    {
        gameoverPannel.SetActive(true);
        pauseButton.SetActive(false);
    }
}
