using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameController gameController;
    UIManager uiManager;
    Cube cube;
    Rigidbody2D m_rigidbody2D; 
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        uiManager = FindObjectOfType<UIManager>();
        cube = FindObjectOfType<Cube>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cube") && gameController.Is_Start())
        {
            Debug.Log("aaa");
            gameController.UpdateScore();
            gameController.CreateNextCube();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            gameController.SetStart(false);
            uiManager.SetResult(gameController.GetScore());
            uiManager.ShowReplayPanel();
            cube=FindObjectOfType<Cube>();
            cube.SetNumberZero();
            gameController.DeleteAllCube();
            
            gameController.SetScore(-1);
        }
        
    }
    public void MoveLeft()
    {
        //m_rigidbody2D.AddForce(new Vector2(-0f, 40f));
        this.transform.position += new Vector3(-0.45f,0,0);
       
    }
    public void MoveRight()
    {
        //m_rigidbody2D.AddForce(new Vector2(0f, 40f));
        this.transform.position += new Vector3(0.45f, 0, 0);
        
    }
    public void MoveBack()
    {
        this.transform.position = new Vector3(0.08f, -2.82f, 0);
    }
    

}
