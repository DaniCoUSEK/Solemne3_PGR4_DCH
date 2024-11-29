using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class Usuario
{
    //public string name;
    public float decimas;

    public Usuario(UsuarioStruct usuarioStruct)
    {
        decimas = usuarioStruct.decimas;
    }
    //public Usuario(string name, string decimas)
    //{
    //    this.name = name;
    //    this.decimas = decimas;
    //}
}
public struct UsuarioStruct
{
    public float decimas;

    public UsuarioStruct(float decimas)
    {
        this.decimas = decimas;
    }
}
//public class UsuarioBox : MonoBehaviour
//{
//    public TMPro.TMP_InputField nameInput;
//    public TMPro.TMP_Text decimasText;
//    public Usuario ReturnClass()
//    {
//        return new Usuario(nameInput.text, decimasText.text);
//    }
//    public void SetUi(Usuario usuario)
//    {
//        nameInput.text = usuario.name;
//        decimasText.text = usuario.decimas;
//    }
//}