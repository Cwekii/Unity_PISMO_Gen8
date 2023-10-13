using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuthUI : MonoBehaviour
{
    [Header("Login data")]
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;

    [Header("Register data")]
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    public TMP_InputField registerPasswordConfirm;
    public TMP_InputField registerName;
    public TMP_InputField registerLastName;

    [Header("Panels")]
    public GameObject loginPanel, registerPanel, loggedInPanel;

    public void ShowLoginPanel()
    {
        ShowPanel(loginPanel);
    }

    public void ShowRegisterPanel()
    {
        ShowPanel(registerPanel);
    }

    public void ShowInGamePanel()
    {
        ShowPanel(loggedInPanel);
    }

    void ShowPanel(GameObject activePanel)
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        loggedInPanel.SetActive(false);

        activePanel.SetActive(true);
        Debug.Log("Active panel is: " + activePanel.name);
    }
}
