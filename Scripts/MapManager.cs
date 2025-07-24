using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
   public static MapManager main;

    public Transform startPoint;
   public Transform [] path;

    private void Awake()
    {
        main = this;
    }
}
