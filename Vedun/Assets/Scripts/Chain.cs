using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public int numbers;
    public GameObject ball;
    private void Start()
    {
        for (int i = 0; i < numbers; i++)
        {
            float y = 0;
            Instantiate(ball, new Vector3(0, 0.5f + y, 0), Quaternion.identity) ;
            y += 0.1f;
        }
    }
}
