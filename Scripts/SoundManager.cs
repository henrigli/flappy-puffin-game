using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip chirpSound, flapSound, gameOverSound, eagleScreechSound;
    static AudioSource audioSrc;

    void Start() {
        chirpSound = Resources.Load<AudioClip> ("chirp");
        flapSound = Resources.Load<AudioClip> ("flap");
        gameOverSound = Resources.Load<AudioClip> ("gameover");
        eagleScreechSound = Resources.Load<AudioClip> ("eagle_screech");

        audioSrc = GetComponent<AudioSource> ();
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case "chirp":
                audioSrc.PlayOneShot (chirpSound);
                break;
            case "flap":
                audioSrc.PlayOneShot(flapSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "eagle_screech":
                audioSrc.PlayOneShot(eagleScreechSound);
                break;
        }
    }
}
