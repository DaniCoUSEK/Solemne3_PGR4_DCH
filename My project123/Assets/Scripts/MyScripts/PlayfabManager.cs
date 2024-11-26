using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TMPro.TMP_Text messageText;
    public TMPro.TMP_InputField emailInput;
    public TMPro.TMP_InputField passwordInput;
    //public Text messageText;
    //public InputField emailInput;
    //public InputField passwordInput;
    
    public void RegisterButton()
    {
        if(passwordInput.text.Length < 6)
        {
            messageText.text = "Password too Short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest { 
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest { 
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Succesful login/account create!");
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "B1940"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordRest, OnError);
    }
    void OnPasswordRest(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
;   }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
}
