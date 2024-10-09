
using UnityEditor.Build.Content;
using UnityEngine;

public class UfoBehaviour : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        scale = Random.Range(40, 60);
        r = Random.Range(-limits, limits);
    }

    // Update is called once per frame
    const float limits = 15;
    float scale = 20;

    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, NewBehaviourScript.earthPosition);

        r += Time.deltaTime * scale;

        transform.eulerAngles = new(0, 0, r);

        if (r > limits && scale > 0)
            scale *= -1;
        if (r < -limits && scale < 0)
            scale *= -1;
    }

    public float r = 0;

    const float targetTime = 1;
    const float randomRange = 1;

    public Vector3 lastRealCoordinate = Vector3.zero;
    public Vector3 currentRealCoordinate = Vector3.zero;

    public Vector3 RealPosition2d = Vector3.zero;
    public Vector3 RealLastPosition2d = Vector3.zero;

    public async void ChangePositionToPlanet(GameObject targetObj)
    {
        Vector3 newRealCoordinate = targetObj.GetComponent<Planet>().coordinate;

        Vector3 target2D = targetObj.transform.position;
        Vector3 oldPosition = transform.position;
        Vector3 oldPosition2D = RealPosition2d;
        target2D.z = oldPosition2D.z;
        Vector3 target = new(target2D.x + Random.Range(-randomRange, randomRange), target2D.y + Random.Range(-randomRange, randomRange), oldPosition.z);
        float now = 0;
        while (now < targetTime)
        {
            await Awaitable.FixedUpdateAsync();
            now += Time.fixedDeltaTime;
            Debug.Log(now);

            if (now > targetTime)
                now = targetTime;
            transform.position = Vector3.Lerp(oldPosition, target, now / targetTime);

            RealPosition2d = Vector3.Lerp(oldPosition2D, target2D, now / targetTime);

            currentRealCoordinate = Vector3.Lerp(lastRealCoordinate, newRealCoordinate, now / targetTime);
        }

        RealLastPosition2d = target2D;
        lastRealCoordinate = newRealCoordinate;
    }
}
