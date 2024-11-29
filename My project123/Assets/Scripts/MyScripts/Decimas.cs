using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Decimas : MonoBehaviour
{
    public Cat cat;
    public TMPro.TMP_Text messageText;
    private void Update()
    {
        messageText.text = "Total Amount:" + cat.AddDecimas().ToString();
    }
}
