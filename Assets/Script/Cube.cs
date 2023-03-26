using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    public static float number = 0;
    float timefall = 3;
    static bool isDown=false; 
    float time=0;
    GameController controller;
    Rigidbody2D rb; 
    void Start()
    {
        controller= FindObjectOfType<GameController>(); 
        number+=1.0f;
        rb = GetComponent<Rigidbody2D>();
        
        if (controller.Is_Start())
        {
            Destroy(gameObject,(timefall+(number*0.3f)));
            
        }
    }
   

    // Update is called once per frame
    void Update()
    {

        if (controller.Is_Start())
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TurnDown();
                
            }
            if (transform.localPosition.y < -4)

            {
                Destroy(gameObject);
               
            }
        }
    }
    public void SetNumberZero()
    {
        number = 0;
    }
    public void TurnDown()
    {
        transform.position -=new Vector3(0,0.45f,0);
    }
    
    
    
    
    
}
