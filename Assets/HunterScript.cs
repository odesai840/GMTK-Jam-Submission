using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : CharacterBase
{
    public LayerMask platformLayerMask;
    bool wDown = false;
    BoxCollider2D boxCollider2d;
    int jumps = 0;
    int jumpcount = 2; //jumps per ground contact
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        base.Start();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.white;
 
    } 

    // Update is called once per frame
    void Update()
    {

        if(controlled){
            m_SpriteRenderer.color = Color.blue;    
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
        } else {
            m_SpriteRenderer.color = Color.white;
        }
        

    }

    /*private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);

        return raycastHit.collider != null;
    }*/
    private void OnCollisionEnter2D(Collision2D other) {
        jumps=0;
        Debug.Log("jumps count reset");
    }

    private bool canJump(){
        /*if(IsGrounded()){
            jumps = 0;
        }*/

        return jumps < jumpcount && !wDown;
    }
}
