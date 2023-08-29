using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    //Login panel
    [Header("Login Panel")]
    public Text usernameText;
    public InputField passwordLogin;

    [Header("Registration Panel")]
    public InputField email;
    public InputField username;
    public InputField password;
    public InputField repeatPassword;

   public void LoginMethod()
    {
        if (usernameText.text == null)
        {
            Debug.Log("Write your username dickhead");
        }
        else if (usernameText.text == " ")
        {
            Debug.Log("You can't fool the fool, fool");
        }
        else if (usernameText.text.Length < 3)
        {
            Debug.Log("You need more then 3 viagras to work");
        }
        else if (passwordLogin.text != PlayerPrefs.GetString("password" + usernameText.text) ||
            usernameText.text != PlayerPrefs.GetString("username" + usernameText.text))
        {
            Debug.Log("Wrong user name or password? -.- ");
        }
        else if ((usernameText.text == PlayerPrefs.GetString("username" + usernameText.text) ||
           usernameText.text == PlayerPrefs.GetString("email" + usernameText.text)) && 
           passwordLogin.text == PlayerPrefs.GetString("password" + usernameText.text))
        {
            Debug.Log("I'm in. B)");
        }

        else
        {
            Debug.Log("Oh boy, you fucked up");
        }
    }

    public void RegisterMethod()
    {
        if (email.text == null)
        {
            Debug.Log("Write email");
        }
        else if (username.text == null)
        {
            Debug.Log("Write your username God dam it");
        }
        else if (password.text == null)
        {
            Debug.Log("Enter your password, mother fucker");
        }
        else if (repeatPassword.text == null)
        {
            Debug.Log("Rewrite your mother fucking pass fucking word, dog");
        }
        else if (password.text.Length < 8)
        {
            Debug.Log("To enter you need it at least 8 inches long");
        }
        else if (password.text != repeatPassword.text)
        {
            Debug.Log("When you make a mistake suffer the consequences. *evil laugh of devs*");
            email.text = null;
            username.text = null;
            password.text = null;
            repeatPassword.text = null;
        }
        else if (PlayerPrefs.GetString("username" + username.text) == username.text ||
           ( email.text == PlayerPrefs.GetString("email" + username.text)))
        {
            Debug.Log("This username is already is being used by someone");
        }

        else
        {
            PlayerPrefs.SetString("email" + username.text, email.text);
            PlayerPrefs.SetString("username" + username.text, username.text);
            PlayerPrefs.SetString("password" + username.text, password.text);
            Debug.Log("You have registred account");
        }
    }
}
