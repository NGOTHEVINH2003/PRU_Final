using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject p1Win;
    public GameObject p2Win;
    // Start is called before the first frame update
    public void PlayerScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void EndGame()
    {
        if(GlobalVarieties.global.p1Death || GlobalVarieties.global.p2Death)
        {
            GameOverUI.SetActive(true);
            if (GlobalVarieties.global.p1Death)
            {
                p2Win.SetActive(true);
            }
            if (GlobalVarieties.global.p2Death)
            {
                p1Win.SetActive(true);
            }
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
