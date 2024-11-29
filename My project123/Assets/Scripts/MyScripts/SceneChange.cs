using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeTo0()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeTo1()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeTo2()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeTo1Delay()
    {
        Invoke("ChangeTo1", 1);
    }
}
