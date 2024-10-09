using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Mars;
    public GameObject HR;
    public GameObject Jupiter;
    public GameObject Aldebaran;
    public GameObject Alioth;
    public GameObject Polaris;
    public GameObject Alkaid;
    public GameObject Vega;
    public GameObject Neptune;
    public GameObject Formalhaut;
    public GameObject Moon;

    public UfoBehaviour BS_Genesis;
    public UfoBehaviour BC_StarTalon;
    public UfoBehaviour BS_Marduk;
    public UfoBehaviour ISS_Perilous;
    public UfoBehaviour BC_Executor;
    public UfoBehaviour BS_Invader;
    // Start is called before the first frame update
    void Start()
    {
        //ufo1.ChangePositionToPlanet();
        pathBSGenesis = new() {  };
    }

    private List<GameObject> pathBSGenesis;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            BS_Genesis.ChangePositionToPlanet(Moon.transform.position);
            Debug.Log("Quitting");
        }
    }
}
