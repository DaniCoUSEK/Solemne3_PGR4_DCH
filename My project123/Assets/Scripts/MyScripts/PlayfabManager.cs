using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TMPro.TMP_Text messageText;
    public TMPro.TMP_InputField[] emailInput;
    public TMPro.TMP_InputField[] passwordInput;
    public TMPro.TMP_InputField nameInput;
    public SceneChange sceneChange;


    [Header("Windows")]
    public GameObject nameWindow;

    public void RegisterButton()
    {
        if (passwordInput[1].text.Length < 6)
        {
            messageText.text = "Password too Short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest { 
            Email = emailInput[1].text,
            Password = passwordInput[1].text,
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
            Email = emailInput[0].text,
            Password = passwordInput[0].text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Succesful login/account create!");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        }
        if (name == null)
        {
            nameWindow.SetActive(true);
        }
        else
        {
            sceneChange.ChangeTo1Delay();
        }
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput[2].text,
            TitleId = "B1940"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordRest, OnError);
    }
    void OnPasswordRest(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
;   }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        sceneChange.ChangeTo1Delay();
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
}
