using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class LoadSave : MonoBehaviour
{
    public bool isSucces;
    public object onSaveEnd;
    //public TMPro.TMP_Text messageText;
    //public void SaveCharacater()
    //{
    //    var request = new UpdateUserDataRequest
    //    {
    //        Data = new Dictionary<string, string> { { "Usuario", UsuarioBox[0].Re } }
    //    };
    //    PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    //}
    //void OnError(PlayFabError error)
    //{
    //    messageText.text = error.ErrorMessage;
    //    Debug.Log(error.GenerateErrorReport());
    //}
    public void SaveData<Usuario>(Usuario data, string dataKey, Action<bool> onEndSave)
    {
        string json = JsonUtility.ToJson(data);
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> 
            {
                { dataKey, json }
            }
        };
        isSucces = false;
        onSaveEnd = onEndSave;
        PlayFabClientAPI.UpdateUserData(request, OnEndSaveData, OnLoadSaveFail);
    }
    private void OnEndSaveData(UpdateUserDataResult result)
    {
        isSucces = true;
        Debug.Log("Data Saved");
    }
    public void LoadData<Usuario>(string dataKey, Action<Usuario> OnLoaded)
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, result =>
        {
            if (result.Data != null && result.Data.ContainsKey(dataKey))
            {
                string jason = result.Data[dataKey].Value;
                Usuario data = JsonUtility.FromJson<Usuario>(jason);
                OnLoaded(data);
            }
            else
            {
                OnLoaded(default);
            }
        }, OnLoadSaveFail);  
    }
    private void OnLoadSaveFail(PlayFabError msg)
    {
        Debug.Log(msg.Error);
    }
}