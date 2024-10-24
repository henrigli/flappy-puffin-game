using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(nameof(Transition));
    }

    public IEnumerator Transition(){
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("SampleScene");
    }
}
