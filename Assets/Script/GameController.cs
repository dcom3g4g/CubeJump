using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    public GameObject Mainplayer;
    Cube cube;
    UIManager uIManager;
    public AudioSource audioSource;
    public GameObject MainCube;
    static bool IsStart = false;
    int Score = 0;
    public int[] CubePosition = new int[10000];
    public int Position = 0;
    public Vector3 Firstpos = new Vector3(0.06f, -3.82f, 0);
    int x = 0;
    void Start()
    {

        cube = FindObjectOfType<Cube>();
        uIManager = FindObjectOfType<UIManager>();
        audioSource = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        IsStart = true;
       
        uIManager.DropStartPannel();
        CreatPlayer();
        player = FindObjectOfType<Player>();
        
        CreatePosition();
        CreatFirstCube();
        //player.SetIsDown();


    }
    public void CreatPlayer()
    {
        if (x == 0)
        {
            Instantiate(Mainplayer, new Vector3(0.08f, -2.0f, 0), Quaternion.identity);
            x = 1;
        }

    }
    public void DeleteAllCube()
    {

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject a in allObjects)
        {
            Destroy(a);
        }
    }
    public bool Is_Start()
    {
        return IsStart;
    }
    public void SetStart(bool isstart)
    {
        IsStart = isstart;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Is_Start())
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                audioSource.Play();
                player.MoveRight();
            }

            else if (touch.position.x <= Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                audioSource.Play();
                player.MoveLeft();
            }

        }
    }
    public void CreatePosition()
    {
        int left = 0, right = 0;
        for (int i = 1; i < 1000; i++)
        {
            CubePosition[i] = Random.Range(1, 3);
            if (CubePosition[i] == 1)
            {
                left++;

            }
            else
            {
                right++;
            }
            if (right - left >= 3)
            {
                CubePosition[i] = 1;
                left++;
                right--;
            }
            if (left - right >= 3)
            {
                CubePosition[i] = 2;
                right++;
                left--;
            }


        }
    }
    public void CreatFirstCube()
    {
        Firstpos = new Vector3(0.06f, -3.82f, 0);
        if (Position == 0)
        { 
        
        Instantiate(MainCube, Firstpos, Quaternion.identity);
        }
        for (int i = 0; i < 1000; i++)
        {
            if (CubePosition[i] == 1)
            {
                Firstpos = new Vector3(Firstpos.x - 0.5f, Firstpos.y + 0.45f, Firstpos.z);
                Instantiate(MainCube, Firstpos, Quaternion.identity);
                Debug.Log(Firstpos);
            }
            else if (CubePosition[i] == 2)
            {
                Firstpos = new Vector3(Firstpos.x + 0.5f, Firstpos.y + 0.45f, Firstpos.z);
                Instantiate(MainCube, Firstpos, Quaternion.identity);
            }
        }
        Firstpos.y += 0.45f;

    }
    public void UpdateScore()
    {
        Score++;
        uIManager.SetScore(Score);
    }
    public int GetScore()
    {
        return Score;
    }
    public void SetScore(int score)
    {
        Score = score;
    }
    public void Replay()
    {
        //IsStart = true;
        Position = 1;
        uIManager.DropReplayPanel();
        Instantiate(MainCube, new Vector3(0.06f, -3.82f, 0), Quaternion.identity);
        StartGame();
        player.MoveBack();
    }
    public void CreateNextCube()
    {

        if (CubePosition[Score+102] == 1)
        {
            
            Firstpos = new Vector3(Firstpos.x - 0.5f, Firstpos.y , Firstpos.z);
            Instantiate(MainCube, Firstpos, Quaternion.identity);
            //Debug.Log(Firstpos);
        }
        else if (CubePosition[102+Score] == 2)
        {
            Firstpos = new Vector3(Firstpos.x + 0.5f, Firstpos.y , Firstpos.z);
            Instantiate(MainCube, Firstpos, Quaternion.identity);
        }
    }
}
