using UnityEngine;

public class Fish : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public new Rigidbody2D rigidbody;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.3f, 0.3f);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void AnimateSprite() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length-1){
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];

    }

    private void DeadFishSprite() {
        CancelInvoke(nameof(AnimateSprite));
        spriteIndex = 2;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            DeadFishSprite();
            rigidbody.gravityScale = 1f;
            rigidbody.angularVelocity = 45f;
        }
    }

}
