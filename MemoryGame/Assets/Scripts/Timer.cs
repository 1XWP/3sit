using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public float interval;

    public GameScript gameScript;

    void Awake()
    {
        gameScript = GetComponent<GameScript>();
    }

    public void Update()
    {
        if (gameScript.arrayCardsFlipped.Count == 2)
        {
            if (interval > 0)
            {
                interval -= Time.deltaTime;
            }
            if (interval <= 0)
            {
                gameScript.arrayCardsFlipped.ForEach(gameScript.SetDown);
                gameScript.arrayCardsFlipped = new List<GameScript.Card>();
                interval = 2;
            }
        }
    }
}