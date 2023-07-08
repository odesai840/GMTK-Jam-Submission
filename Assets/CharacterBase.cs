using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    public bool controlled = false;
    public float level = 0;
    public bool isGhost = false;


    // Start is called before the first frame update
    protected void Start()
    {
        TextMeshProUGUI a = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        a.text = "LVL " + level;
    }

    // Update is called once per frame
    protected void Update()
    {
        TextMeshProUGUI a = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        a.text = "LVL " + level;
    }
}
