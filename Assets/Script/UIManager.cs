using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public GameObject pannelstart; 
    public GameObject pannelreplay;
    public Text Result; 


    void Start()
    {
        pannelreplay.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int score)
    {
        if(Score)
            Score.text=(score).ToString();
    }
    public void SetResult(int score)
    {
        Result.text = "Your score: ";
        Result.text+=(score).ToString();

    }
    public void DropStartPannel()
    {
        pannelstart.SetActive(false);
    }
    public void DropReplayPanel()
    {
        pannelreplay.SetActive(false);
    }
    public void ShowReplayPanel()
    {
        pannelreplay.SetActive(true); 
    }
    
}
