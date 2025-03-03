using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : ShiftZ
{
    public MeshRenderer rend; 
    public Material[] materials; 
    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Player"){
            
            Transform temp = collision.collider.transform;
            while (!temp.name.Equals("Player")){
                temp = temp.parent;
                if (temp == null) return;
            }
            
            if (temp.GetComponent<PlayerMovement>().capableOfBreaking){
                if (transform.GetComponent<ShiftZ>()){
                    ShiftZ.allShiftZ.Remove(transform.GetComponent<ShiftZ>());
                }
                transform.GetChild(0).gameObject.SetActive(true);
                //transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                transform.GetChild(0).parent = null;
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    protected override void Start(){
        base.Start();
        rend = GetComponent<MeshRenderer>();
        StartCoroutine(StartHelper());
        
        
    }
    private IEnumerator StartHelper(){
        yield return new WaitForSeconds(0.02f);
        
        rend.material = materials[PerspectiveShift.curr3D ? 1 : 0];
    }

    public override void beginShift(){
        base.beginShift();
        rend.material = materials[0];
    }
     public override void resetShift(){
        base.beginShift();
        rend.material = materials[1];
    }


}