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
    float speed = 5;
    SpriteRenderer m_SpriteRenderer;    //The Color to be assigned to the Renderer’s Material
    Rigidbody2D m_Rigidbody;
    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        base.Start();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.white; 
        m_Rigidbody = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        speed= 5 + Mathf.Sqrt(level);
        Debug.Log("Hunter Speed = " speed);
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if(controlled){
            m_SpriteRenderer.color = Color.gray;    
            if(Input.GetKey("w") && canJump()){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, 8, 0);
                jumps += 1;
            }
            wDown = Input.GetKey("w");

            if(Input.GetKey("a")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, velo.y, 0);
                m_SpriteRenderer.flipX= true;
            } 

            if(Input.GetKey("d")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(speed, velo.y, 0);
                m_SpriteRenderer.flipX= false;
            }
        } else {
            m_SpriteRenderer.color = Color.white;
        }
        

    }

    /*private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);

        return raycastHit.collider != null;
    }*/
    private void OnCollisionStay2D(Collision2D other) {
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
