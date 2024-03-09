using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProperties : MonoBehaviour
{
    [SerializeField] float weight = 1;

    public float GetWeight()
    {
        return weight;
    }
}
