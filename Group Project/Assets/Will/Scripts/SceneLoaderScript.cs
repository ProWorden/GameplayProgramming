using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    [SerializeField]
    Animator transition;
    [SerializeField]
    float transitionTime = 1f;
    IEnumerator ChangeScene(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string scene_name)
    {
        StartCoroutine(ChangeScene(scene_name)); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
