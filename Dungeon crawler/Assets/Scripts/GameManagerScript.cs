using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript instance;
    public static GameManagerScript Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Game manager is null");
            }
            return instance;
        }
    }

    public bool hasKeyToCastle { get; set; }

    private void Awake()
    {
        instance = this;
    }
}
