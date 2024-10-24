using UnityEngine;

public class Seagull : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void AnimateSprite() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];

    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
}
