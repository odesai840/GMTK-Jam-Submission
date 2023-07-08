using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : CharacterBase
{
    bool wDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(controlled){
            if(Input.GetKey("w") && !wDown){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, 5, 0);
            }
            wDown = Input.GetKey("w");

            if(Input.GetKey("a")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(-3, velo.y, 0);
            } 

            if(Input.GetKey("d")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(3, velo.y, 0);
            }
        }
        

    }
}
