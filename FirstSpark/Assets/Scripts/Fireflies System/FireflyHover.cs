using UnityEngine;

public class FireflyHover : MonoBehaviour
{
    public float floatStrength = 0.3f;
    public float speed = 1f;
    public float noiseAmplitude = 0.2f;
    public float noiseSpeed = 1f;

    private Vector3 startPos;
    private float noiseOffset;

    void Start()
    {
        startPos = transform.position;
        noiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float sinY = Mathf.Sin(Time.time * speed) * floatStrength;
        float noiseX = Mathf.PerlinNoise(Time.time * noiseSpeed + noiseOffset, 0f) - 0.5f;
        float noiseZ = Mathf.PerlinNoise(0f, Time.time * noiseSpeed + noiseOffset) - 0.5f;
        Vector3 noiseOffsetVec = new Vector3(noiseX, 0f, noiseZ) * noiseAmplitude;

        transform.position = startPos + new Vector3(0, sinY, 0) + noiseOffsetVec;
    }
}
