using UnityEngine;
using System.Collections;

public class comet : MonoBehaviour {
    public float maxMove;
    ParticleSystem p;

    float timeAlive;

    void Start()
    {
        timeAlive = 0;
        float lifetime = Random.Range(5, 10);
        Invoke("Die", lifetime);
        maxMove = 5;
        p = GetComponent<ParticleSystem>();
        //float x = (float)Random.Range(100, 255) / 255;
        Vector4 c = new Vector4((float)Random.Range(0, 255) / 255, (float)Random.Range(0, 255)/255, (float)Random.Range(0, 255)/255, 1);
        //Debug.Log(c);
        p.startColor = c;
    }

	void Update () {
        timeAlive += Time.deltaTime;
        //gameObject.transform.position = (new Vector3(transform.position.x, (Mathf.Sin(timeAlive) * .5f), transform.position.z));
        gameObject.transform.Translate(new Vector3(0, (Mathf.Sin(timeAlive) * .01f), 0));
    }

    void Die()
    {
        p.emissionRate = 0;
        StartCoroutine(fadeOut(5));
    }

    IEnumerator fadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
