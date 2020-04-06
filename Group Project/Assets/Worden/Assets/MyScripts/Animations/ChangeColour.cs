using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Material matRed;
    public Material matGreen;
    public PlayButtonAnim button;
    private void Start()
    {
        GetComponent<Renderer>().material = matRed;
    }
    private void Update()
    {
        if(this.button.animTimer > 0.6)
        {
            GetComponent<Renderer>().material = matGreen;
        }
     
    }
}
