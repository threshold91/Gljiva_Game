using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {
            numberOfCoins = 0;
   
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("coins" + numberOfCoins);
    }
}
