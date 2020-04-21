using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Animation anim;
    public float timer;
   public  void removeBarrier()
    {
        anim.Play();
        timer += Time.deltaTime;

        if (timer >=2)
        {
            anim.Stop();
            timer = 2;
        }

        anim.wrapMode = WrapMode.Once;
    }
   
}
