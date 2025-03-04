using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ShiftZ
{
    
    public Shape[] AvailShapes; //Shapes the player can swapp too
    
    public int currShapeIndex; 
    public Shape currShape{get; private set;}
    public bool capableOfBreaking; 
    
    public CameraAnimationTriggers cat; 
    
    public virtual void Start()
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
        currShape.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), PerspectiveShift.curr3D);
        if (PerspectiveShift.curr3D){
            currShape.Switch3D();
        }
        else {
            currShape.Switch2D();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            SwitchAnim();
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
        AudioManager.instance.playSFX(AudioManager.instance.playerSwap);
        
        
    }

    public void CallOpen(){
        currShape.Open();
    }


    private Dictionary<Fan, Vector3> addedForcePerFan = new Dictionary<Fan, Vector3>();
    public void FanEnter(Fan fan){
        currShape.FanAffect(fan);
    }
    public void FanExit(Fan fan){
        currShape.FanLeave(fan);
    }

    public float bounceVelRequirement;
    public void OnCollisionEnter(Collision collision){
       
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Wall"){
            if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > bounceVelRequirement || Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > bounceVelRequirement || Mathf.Abs(GetComponent<Rigidbody>().velocity.y) > bounceVelRequirement)
            {
                print("SOUND OFF");
                AudioManager.instance.playSFX(AudioManager.instance.playerRegCollision);
                BounceAnim();
                
            }
            
        }
    }

    public virtual void BounceAnim(){
        int picker = Random.Range(1, 3);
        print(picker);
        cat.SetTrigger("Collide" + picker);
    }

    public void SwitchAnim(){
        cat.PlayAnim("Switch");
    }
    public void SmashAnim(){
        cat.PlayAnim("Smash");
    }
    
}
