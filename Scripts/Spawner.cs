using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_fish;
    public GameObject prefab_seagull;
    public GameObject prefab_cloud;
    public GameObject prefab_eagle;
    
    public float delayFish;
    public float delaySeagull;
    public float delayEagle;

    public float spawnRateFish;
    public float spawnRateSeagulls;
    public float spawnRateClouds;
    public float spawnRateEagles;

    public float minHeight;
    public float maxHeight;

    public float fishSpeed;
    public float seagullSpeed;
    public float cloudSpeed;
    public float eagleSpeed;


    private void OnEnable() {
        InvokeRepeating(nameof(SpawnFish), delayFish, spawnRateFish);
        InvokeRepeating(nameof(SpawnSeagulls), delaySeagull, spawnRateSeagulls);
        InvokeRepeating(nameof(SpawnCloud), spawnRateClouds, spawnRateClouds);
        InvokeRepeating(nameof(SpawnEagles), delayEagle, spawnRateEagles);

    }
    private void OnDisable() {
        CancelInvoke(nameof(SpawnFish));
        CancelInvoke(nameof(SpawnSeagulls));
        CancelInvoke(nameof(SpawnCloud));
        CancelInvoke(nameof(SpawnEagles));
    }
    
    private void Start() {
        StartCoroutine(nameof(FishIncreaseSpeed));
        StartCoroutine(nameof(SeagullIncreaseSpeed));
        StartCoroutine(nameof(CloudIncreaseSpeed));
    }

    private void SpawnCloud(){
        Clouds clouds = Instantiate(prefab_cloud, transform.position, Quaternion.identity).GetComponent<Clouds>();
        clouds.speed = cloudSpeed;
        clouds.transform.position += Vector3.up * Random.Range(minHeight+2, maxHeight);
        spawnRateClouds = Random.Range(10,15);
        CancelInvoke(nameof(SpawnCloud));
        Invoke(nameof(SpawnCloud), spawnRateClouds);
    }

    private void SpawnFish(){
        Fishes fishes = Instantiate(prefab_fish, transform.position, Quaternion.identity).GetComponent<Fishes>();
        fishes.speed = fishSpeed;
        fishes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        spawnRateFish = Random.Range(2,4);
        CancelInvoke(nameof(SpawnFish));
        Invoke(nameof(SpawnFish), spawnRateFish);
    }

    private void SpawnSeagulls(){
        Seagulls seagulls = Instantiate(prefab_seagull, transform.position, Quaternion.identity).GetComponent<Seagulls>();
        seagulls.speed = seagullSpeed;
        seagulls.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        spawnRateSeagulls = Random.Range(3,6);
        CancelInvoke(nameof(SpawnSeagulls));
        Invoke(nameof(SpawnSeagulls), spawnRateSeagulls);
    }

    private void SpawnEagles(){
        SoundManager.PlaySound("eagle_screech");
        Eagles eagles = Instantiate(prefab_eagle, transform.position, Quaternion.identity).GetComponent<Eagles>();
        eagles.speed = eagleSpeed;
        eagles.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        spawnRateEagles = Random.Range(15,25);
        CancelInvoke(nameof(SpawnEagles));
        Invoke(nameof(SpawnEagles), spawnRateEagles);
    }

    private IEnumerator FishIncreaseSpeed(){
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(10f);
            fishSpeed+=0.5f;
            
        }
    }

    private IEnumerator SeagullIncreaseSpeed(){
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(15f);
            seagullSpeed+=0.5f;
            
        }
    }

    private IEnumerator CloudIncreaseSpeed(){
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(10f);
            cloudSpeed+=0.5f;
            
        }
    }
}
