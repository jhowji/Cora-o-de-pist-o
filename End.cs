using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class End : MonoBehaviourPunCallbacks
{
    public void OnClickBack()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
