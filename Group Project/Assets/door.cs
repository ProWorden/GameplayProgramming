using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animation anim;
    public float timer;
    public void removeDoor()
    {
        anim.Play();
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            anim.Stop();
            timer = 1;
        }

        anim.wrapMode = WrapMode.Once;
    }
}
