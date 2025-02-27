using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ShiftZ
{
    
    public Shape[] AvailShapes; //Shapes the player can swapp too
    
    public int currShapeIndex; 
    public Shape currShape; 
    public bool capableOfBreaking; 
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currShape = AvailShapes[0]; 
        currShapeIndex = 0;
        Invoke("CallOpen", 0.1f);
    }
    

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        
        base.FixedUpdate();
        currShape.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), Camera.main.GetComponent<PerspectiveShift>().curr3D);
        if (Camera.main.GetComponent<PerspectiveShift>().curr3D){
            currShape.Switch3D();
        }
        else {
            currShape.Switch2D();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Switch();
        }   

        if (Input.GetKeyDown(KeyCode.Space)){
            
            currShape.Action();
        }
        if (currShape.GetComponent<CubeShape>() != null){
            capableOfBreaking = currShape.GetComponent<CubeShape>().thresholdReached;
        }
        else capableOfBreaking = false;
    }

    public void Switch(){
        currShape.Close();
        currShapeIndex = currShapeIndex + 1 >= AvailShapes.Length ? 0 : ++currShapeIndex; 
        currShape = AvailShapes[currShapeIndex];
        
        
    }

    public void CallOpen(){
        currShape.Open();
    }
    
}
