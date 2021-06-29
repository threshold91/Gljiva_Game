using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    public static int currentHealth = 100;
    public Slider healthBar;

    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {
            numberOfCoins = 0;

            gameOver = false;
   
        }
    }

    // Update is called once per frame
    void Update()
    {

        //display coins
        numberOfCoinsText.text = "coins: " + numberOfCoins;

        Debug.Log("coins" + numberOfCoins);

        //update healthbar
        healthBar.value = currentHealth;

        //game over
        if(currentHealth < 0)
        {
            gameOver = true;
        }
    }
}
