using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_collected : MonoBehaviour
{
    public Text coin_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin_text.text = "" + globalControl.Instance.coins;
    }
}
