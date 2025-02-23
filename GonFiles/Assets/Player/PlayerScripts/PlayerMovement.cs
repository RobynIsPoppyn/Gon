using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Shape[] AvailShapes; //Shapes the player can swapp too
    
    public int currShapeIndex; 
    public Shape currShape; 
    // Start is called before the first frame update
    void Start()
    {
       
        currShape = AvailShapes[0]; 
        currShapeIndex = 0;
        Invoke("CallOpen", 0.1f);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        

        currShape.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Shift();
        }   

        if (Input.GetKeyDown(KeyCode.Space)){
            print("Action");
            currShape.Action();
        }
    }

    public void Shift(){
        currShape.Close();
        currShapeIndex = currShapeIndex + 1 >= AvailShapes.Length ? 0 : ++currShapeIndex; 
        currShape = AvailShapes[currShapeIndex];
        print("Switched");
        
    }

    public void CallOpen(){
        currShape.Open();
    }
    
}
