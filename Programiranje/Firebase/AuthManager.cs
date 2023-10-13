using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class AuthManager : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseUser user;
    AuthUI authUI;

    private void Start()
    {
        authUI = GetComponent<AuthUI>();
        //inicijalizacija firebasea
        InitializeFirebase();
        authUI.ShowLoginPanel();
    }

    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        // Skraæeni zapis
        //bool signedIn;
        //if(user != auth.CurrentUser && auth.CurrentUser != null)
        //{
        //    signedIn = true;
        //}
        //else
        //{
        //    signedIn = false;
        //}

        bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
        if (!signedIn && user != null)
        {
            Debug.Log("Signed out " + user.UserId);
        }

        user = auth.CurrentUser;
        if (signedIn)
        {
            Debug.Log("Signed in " + user.UserId);
            authUI.ShowInGamePanel();
        }
    }

    //Metoda za login na button
    public void OnLoginButton()
    {
        TryLoginWithFirebase(authUI.loginEmail.text, authUI.loginPassword.text);
    }

    public void OnRegisterButton()
    {
        TryRegisterWithFirebaseAuth(authUI.registerEmail.text, authUI.registerPassword.text, authUI.registerPasswordConfirm.text);
    }

    public void OnLogoutButton()
    {
        auth.SignOut();
        //Prikaži ekran
        authUI.ShowLoginPanel();
    }

    void TryLoginWithFirebase(string emailFromUserInUnity, string passwordFromUserInUnity)
    {
        auth.SignInWithEmailAndPasswordAsync(emailFromUserInUnity, passwordFromUserInUnity).ContinueWith(task => {
            //Prijava prekine
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            //Prijava nije uspijela iz nekog razloga, npr. intrenet pukao, ugasio app, kriva lozinka
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            //Prijava je uspješna
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
            //authUI prkaži logged in panel
            authUI.ShowInGamePanel();
        });
    }

    void TryRegisterWithFirebaseAuth(string userEmailFromUnity, string userPasswordFromUnity, string userPasswordRepeat)
    {
        auth.CreateUserWithEmailAndPasswordAsync(userEmailFromUnity, userPasswordFromUnity).ContinueWith(task => {
            //korisnik odustao od izrade raèuna
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            //neuspiješno kreiranje accounta
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            else
            {
                if(userPasswordFromUnity == userPasswordRepeat)
                {
                    // Firebase user has been created.
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
                    authUI.ShowLoginPanel();
                }
                else if(userPasswordFromUnity != userPasswordRepeat)
                {
                    Debug.Log("Password do not match");
                    return;
                }
            }
        });
    }
}
