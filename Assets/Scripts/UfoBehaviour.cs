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

    public void ChangePositionToPlanet()
    {

        var célPlanet = new Vector3(0, 0, 0);
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }
}
