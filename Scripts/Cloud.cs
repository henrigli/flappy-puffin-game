using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void AnimateSprite() {
        spriteIndex = Random.Range(0,7);
        spriteRenderer.sprite = sprites[spriteIndex];

    }

    private void Start() {
        Invoke(nameof(AnimateSprite), 0.15f);
    }
    
}
