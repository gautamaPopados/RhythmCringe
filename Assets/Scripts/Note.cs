using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{
    Note Instance;
    double timeInstantiated;
    public float yPos;
    public float yPosDot;
    public float assignedTime;
    public GameObject shadowPrefab;
    public GameObject dotPrefab;
    void Start()
    {
        Instance = this;
        timeInstantiated = SongManager.GetAudioSourceTime();
        Instantiate(shadowPrefab, new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z), Quaternion.identity, Instance.transform);
        Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y + yPosDot, transform.position.z), Quaternion.identity, Instance.transform);
    }

    private IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        if (t > 5)
        {
            gameObject.GetComponent<Animator>().SetTrigger("destruct");
            StartCoroutine(delay(0.3f));
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.right * SongManager.Instance.noteSpawnX, Vector3.right * SongManager.Instance.noteDespawnX, t);
            //shadowPrefab.transform.position = transform.position;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void LateUpdate()
    {
        
    }
}