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
        pathBS_Genesis =   new() { Aldebaran, Formalhaut };
        pathBC_StarTalon = new() { Aldebaran, Formalhaut };
        pathBS_Marduk =    new() { Aldebaran, Formalhaut };
        pathISS_Perilous = new() { Aldebaran, Vega };
        pathBC_Executor =  new() { Aldebaran, Vega };
        pathBS_Invader =   new() { Aldebaran, Vega };


        ApplyFrame();
    }

    private List<GameObject> pathBS_Genesis;
    private List<GameObject> pathBC_StarTalon;
    private List<GameObject> pathBS_Marduk;
    private List<GameObject> pathISS_Perilous;
    private List<GameObject> pathBC_Executor;
    private List<GameObject> pathBS_Invader;

    public int currentFrame = 0;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            currentFrame++;

            ApplyFrame();
        }
    }

    void ApplyFrame()
    {
        BS_Genesis.ChangePositionToPlanet(pathBS_Genesis[currentFrame].transform.position);
    }
}
