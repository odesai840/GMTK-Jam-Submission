using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    // Start is called before the first frame update
    private float ylowerlimit =  6.2f;
    private float yupperlimit =  70.7f;
    private float xlowerlimit =  -62.6f;
    private float xupperlimit =  41.62f;
    private float x = 0;
    private float y = 0;
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
