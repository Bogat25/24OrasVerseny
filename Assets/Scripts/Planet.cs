using TMPro;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Vector3 coordinate;

    public void Start()
    {
        TextMeshPro txt = transform.GetChild(1).GetComponent<TextMeshPro>();
        txt.text = $"({coordinate.x:0.00}, {coordinate.y:0.00}, {coordinate.z:0.00})";
    }
}
