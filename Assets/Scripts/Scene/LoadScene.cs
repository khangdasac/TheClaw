using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Animator animator;
    public float waitForSeconds;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            LoadNextScene(0);
        }
    }

    public void LoadNextScene(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int index)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(waitForSeconds);
        SceneManager.LoadScene(index);
    }
}
