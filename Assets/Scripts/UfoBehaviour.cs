using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class UfoBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    const float targetTime = 1;

    public async void ChangePositionToPlanet(Vector3 target)
    {
        Vector3 oldPosition = transform.position;
        float now = 0;
        while (now < targetTime)
        {
            await Awaitable.FixedUpdateAsync();
            now += Time.fixedDeltaTime;
            Debug.Log(now);
            
            if(now > targetTime)
                now = targetTime;
            transform.position = Vector3.Lerp(oldPosition, target, now / targetTime);
        }
    }
}
