using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public CharacterBase currentPlayer;
    public CharacterBase currentGhost;
    bool currentlyGhost = true;
    bool pDown = false;
    bool _Down = false;
    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        CharacterBase[] children = GetComponentsInChildren<CharacterBase>();
        for(int i = 0; i < children.Length; i++){
            children[i].controlled = false;
        }
        currentPlayer.controlled = true;
        currentGhost = currentPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("p") && !pDown){
            if(currentlyGhost){
                CharacterBase[] children = GetComponentsInChildren<CharacterBase>();
                CharacterBase closest = currentPlayer;
                float closestdist = 1000000;
                for(int i = 0; i < children.Length; i++){
                    if(!children[i].isGhost && children[i].level <= currentPlayer.level){
                        float distance = Vector3.Distance(currentPlayer.transform.position, children[i].transform.position);
                        if(distance < closestdist){
                            closest = children[i];
                            closestdist = distance;
                        }
                    }
                }
                if(closestdist <= 2){
                    currentlyGhost = false;
                    currentGhost = currentPlayer;
                    currentPlayer = closest;
                    currentPlayer.controlled = true;
                    currentGhost.gameObject.SetActive(false);
                }
            } else {
                currentGhost.transform.position = currentPlayer.transform.position;
                currentPlayer.controlled = false;
                currentPlayer = currentGhost;
                currentPlayer.gameObject.SetActive(true);
                currentPlayer.controlled = true; 
                currentlyGhost = true;
            }
        } 
        pDown = Input.GetKey("p");

            //animator.SetBool("Attack1", true);
        if(Input.GetKey("space") && !_Down){
            if(!currentPlayer.isGhost){
                CharacterBase[] children = GetComponentsInChildren<CharacterBase>();
                CharacterBase closest = currentPlayer;
                float closestdist = 1000000;
                for(int i = 0; i < children.Length; i++){
                    if(children[i].isGhost && children[i].level <= currentPlayer.level){
                        float distance = Vector3.Distance(currentPlayer.transform.position, children[i].transform.position);
                        if(distance < closestdist){
                            closest = children[i];
                            closestdist = distance;
                            //animator.SetBool("Attack2", true);
                            //Debug.Log("Attack 2");
                        }
                    }
                }

                if(closestdist <= 3 && closestdist > 0){
                    currentGhost.level += closest.level;
                    closest.gameObject.SetActive(false);
                }

            }
        } else if(Input.GetKey("space")) {
            //animator.SetBool("Attack1", true);
            //Debug.Log("Attack 1");
        } 
        /*animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        */
        _Down = Input.GetKey("space");

        CharacterBase[] childrenToCheck = GetComponentsInChildren<CharacterBase>();
        
        for(int i = 0; i < childrenToCheck.Length; i++){
            float distance = Vector3.Distance(currentPlayer.transform.position, childrenToCheck[i].transform.position);
            if(childrenToCheck[i].isGhost && !currentPlayer.isGhost && distance <= 2 && childrenToCheck[i].level > currentGhost.level){
                currentPlayer.controlled = false;
                currentPlayer = currentGhost;
                currentGhost.gameObject.SetActive(true);
                currentPlayer.controlled = true;
                currentPlayer.transform.position = childrenToCheck[i].transform.position;
            }
        }

        if(Input.GetKey("q")){
            print(currentPlayer.transform.position);
        }


        currentGhost.transform.position = currentPlayer.transform.position;
    }
}
