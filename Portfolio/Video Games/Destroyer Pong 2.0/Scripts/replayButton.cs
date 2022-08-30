using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class replayButton : MonoBehaviour
{
    public void replay()
    {
        SceneManager.LoadScene("play");
    }
}
