using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed;
    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start(){
        StartCoroutine(nameof(AnimationIncreaseSpeed));
    }

    private void Update(){
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

    private IEnumerator AnimationIncreaseSpeed(){
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(2f);
            animationSpeed+=0.005f;
            
        }
    }
}
