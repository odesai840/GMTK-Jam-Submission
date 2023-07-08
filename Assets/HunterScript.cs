using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : CharacterBase
{
    public LayerMask platformLayerMask;
    bool wDown = false;
    BoxCollider2D boxCollider2d;
    int jumps = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        base.Start();
 
    } 

    // Update is called once per frame
    void Update()
    {

        if(controlled){
            if(Input.GetKey("w") && canJump()){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, 8, 0);
                jumps += 1;
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

    private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);

        return raycastHit.collider != null;
    }

    private bool canJump(){
        if(IsGrounded()){
            jumps = 0;
        }

        return jumps < 2 && !wDown;
    }
}
