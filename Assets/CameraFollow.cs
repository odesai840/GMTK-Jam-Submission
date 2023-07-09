using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    // Start is called before the first frame update
    public float ylowerlimit =  6.2f;
    public float yupperlimit =  70.7f;
    public float xlowerlimit =  -62.6f;
    public float xupperlimit =  41.62f;
    public float x = 0;
    public float y = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTransform.position.x <= xlowerlimit) {
            x=xlowerlimit;
        } else if(followTransform.position.x >= xupperlimit) {
            x=xupperlimit;
        } else {
            x= followTransform.position.x;
        }
        if(followTransform.position.y <= ylowerlimit) {
            y=ylowerlimit;
        } else if(followTransform.position.y >= yupperlimit) {
            y=yupperlimit;
        } else {
            y= followTransform.position.y;
        }
        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
}
