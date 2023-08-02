using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Skripta služi loadanju određenih scena, koje se odabiru prema njihovim imenima
    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel() //preko GetActiveScene metode dobivamo koja je scena trenutačno aktivna i reloadamo je
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame() //izlazimo iz aplikacije, NE RADI U EDITORU
    {
        Application.Quit();
    }

}
