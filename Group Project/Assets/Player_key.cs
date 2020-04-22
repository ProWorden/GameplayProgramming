using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_key : MonoBehaviour
{
    public bool hasKey = false;

    void Start()
    {
        hasKey = globalControl.Instance.hasKey;

    }

    private void OnDestroy()
    {
        globalControl.Instance.hasKey = hasKey;
    }
}
