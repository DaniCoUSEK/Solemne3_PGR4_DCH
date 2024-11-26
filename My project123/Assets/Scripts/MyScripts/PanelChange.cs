using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject SignupPanel;
    public GameObject RecoveryPanel;
    public void ChangeToSignupPanel()
    {
        SignupPanel.SetActive(true);
        loginPanel.SetActive(false);
        RecoveryPanel.SetActive(false);
        Debug.Log("button pressed");
    }
    public void ChangeToLoginPanel()
    {
        SignupPanel.SetActive(false);
        loginPanel.SetActive(true);
        RecoveryPanel.SetActive(false);
        Debug.Log("button pressed");
    }
    public void ChangeToRecoveryPanel()
    {
        SignupPanel.SetActive(false);
        loginPanel.SetActive(false);
        RecoveryPanel.SetActive(true);
        Debug.Log("button pressed");
    }
}
