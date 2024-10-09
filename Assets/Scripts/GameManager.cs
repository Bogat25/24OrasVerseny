using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Bolygók")]
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

    [Header("Ufók")]
    public UfoBehaviour BS_Genesis;
    public UfoBehaviour BC_StarTalon;
    public UfoBehaviour BS_Marduk;
    public UfoBehaviour ISS_Perilous;
    public UfoBehaviour BC_Executor;
    public UfoBehaviour BS_Invader;

    [Header("Egyéb")]
    public GameObject Boommmmmm;
    public TextMeshPro datas;

    public static Vector3 earthPosition = new();

    // Start is called before the first frame update
    void Start()
    {
        //ufo1.ChangePositionToPlanet();
        pathBS_Genesis = new() { Aldebaran, Formalhaut, HR, HR, HR, Earth };
        pathBC_StarTalon = new() { Aldebaran, Formalhaut, Formalhaut, Mars, Mars, Earth };
        pathBS_Marduk = new() { Aldebaran, Formalhaut, HR, HR, HR, Earth };
        pathISS_Perilous = new() { Aldebaran, Vega, Vega, Neptune, Moon, Earth };
        pathBC_Executor = new() { Aldebaran, Vega, Alioth, Alioth, Alioth, Earth };
        pathBS_Invader = new() { Aldebaran, Vega, Alioth, Neptune, Moon, Earth };

        earthPosition = Earth.transform.position;
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
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentFrame < pathBC_Executor.Count - 1)
        {
            currentFrame++;
            ApplyFrame();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentFrame > 0)
        {
            currentFrame--;
            ApplyFrame();
        }
    }

    void ApplyFrame()
    {
        BS_Genesis.ChangePositionToPlanet(pathBS_Genesis[currentFrame]);
        BC_StarTalon.ChangePositionToPlanet(pathBC_StarTalon[currentFrame]);
        BS_Marduk.ChangePositionToPlanet(pathBS_Marduk[currentFrame]);
        ISS_Perilous.ChangePositionToPlanet(pathISS_Perilous[currentFrame]);
        BC_Executor.ChangePositionToPlanet(pathBC_Executor[currentFrame]);
        BS_Invader.ChangePositionToPlanet(pathBS_Invader[currentFrame]);
    }
}
