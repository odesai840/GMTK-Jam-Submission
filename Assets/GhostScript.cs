using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GhostScript : CharacterBase
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        isGhost = true;
        base.Start();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.white;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(controlled){
            m_SpriteRenderer.color = Color.blue;

            if(Input.GetKey("w")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, speed, 0);
            } else if(Input.GetKey("s")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, -speed, 0);
            } else {
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(velo.x, 0, 0);
            }
    
            if(Input.GetKey("a")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, velo.y, 0);
                m_SpriteRenderer.flipX= true;

            } else if(Input.GetKey("d")){
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(speed, velo.y, 0);
                m_SpriteRenderer.flipX= false;
            } else {
                Vector3 velo = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, velo.y, 0);
            }
        }
        else{
                m_SpriteRenderer.color = Color.white;
            }
         base.Update();

    }
}
