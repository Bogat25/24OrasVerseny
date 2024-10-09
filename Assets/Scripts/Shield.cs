using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static Vector3 moon = new(0.5608007994f, -4.953f, -2.435f);
    public static Vector3 ShieldPosition(Vector3 vec)
    {
        return RescaleVector(vec, moon.magnitude);
    }
    public static Vector3 RescaleVector(Vector3 vec, float targetLength)
    {
        float scale = targetLength / vec.magnitude;
        return vec * scale;
    }
}
