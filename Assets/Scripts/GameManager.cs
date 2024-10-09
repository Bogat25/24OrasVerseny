using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public List<GameObject> shieldsObj;

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

        UfoBehavs = new() { BS_Genesis, BC_StarTalon, BS_Marduk, ISS_Perilous, BC_Executor, BS_Invader };

        earthPosition = Earth.transform.position;
        ApplyFrame();
    }

    private List<GameObject> pathBS_Genesis;
    private List<GameObject> pathBC_StarTalon;
    private List<GameObject> pathBS_Marduk;
    private List<GameObject> pathISS_Perilous;
    private List<GameObject> pathBC_Executor;
    private List<GameObject> pathBS_Invader;

    private List<UfoBehaviour> UfoBehavs;

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
    private void FixedUpdate()
    {
        Vector3[] shieldsCoords = UfoBehavs.Select(x => x.RealPosition2d)
                .Select(x => Shield.ShieldPosition(x))
                .Where(x => !float.IsNaN(x.x))
                .Distinct()
                .ToArray();

        shieldsObj.ForEach(x => x.SetActive(false));

        for (int i = 0; i < shieldsCoords.Length && i < shieldsObj.Count; i++)
        {
            Vector2 coord = shieldsCoords[i];
            float angle = Vector2.SignedAngle(new(0, 1), coord - (Vector2)Earth.transform.position);
            Console.WriteLine(angle);
            shieldsObj[i].SetActive(true);
            shieldsObj[i].transform.eulerAngles = new(0, 0, angle);
        }

        string[] shields = UfoBehavs.Select(x => x.currentRealCoordinate)
                .Select(x => Shield.ShieldPosition(x))
                .Where(x => !float.IsNaN(x.x))
                .Distinct()
                .Select(x => $"({x.x:0.00}, {x.y:0.00}, {x.z:0.00})")
                .ToArray();

        StringBuilder bd = new();
        for (int i = 0; i < shields.Length; i++)
            bd.AppendLine($"{i + 1} : {shields[i]}");
        datas.text = bd.ToString();
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
