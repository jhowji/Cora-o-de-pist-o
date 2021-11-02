using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;
    public static int oneScore = 0;
    public static int twoScore = 0;
    public static int oneHealth = 100;
    public static int twoHealth = 150;
    public Text oneScoreText;
    public Text twoScoreText;
    public Text oneHealthText;
    public Text twoHealthText;

    public GameObject canv;

    private void Awake()
    {
        setScoreText();
        instance = this;
    }

    void setScoreText()
    {
        oneScoreText.text = oneScore.ToString();
        oneHealthText.text = oneHealth.ToString();
        twoScoreText.text = twoScore.ToString();
        twoHealthText.text = twoHealth.ToString();
    }
    void Update()
    {
        setScoreText();
       if(Jogador2.j2win == true)
        {
            canv.SetActive(true);
            twoHealthText.text = "VENCEDOR";
            oneHealthText.text = "PERDEDOR";
        }
        if (Jogador.j1win == true)
        {
            canv.SetActive(true);
            twoHealthText.text = "PERDEDOR";
            oneHealthText.text = "VENCEDOR";
        }
    }

}
