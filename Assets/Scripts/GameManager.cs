using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //MUST INCLUDE THIS OR NO UI STUFF

public class GameManager : MonoBehaviour
{
    public int scoreA = 0;
    public int scoreB = 0;
    
    //These must be assigned by drag and dropping out in Unity
    public Text scoreTextA;
    public Text scoreTextB;
    
    void Update()
    {
        scoreTextA.text = scoreA.ToString();
        scoreTextB.text = scoreB.ToString();
    }
}
