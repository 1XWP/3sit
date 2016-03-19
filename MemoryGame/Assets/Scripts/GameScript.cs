using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
    public GUISkin customSkin;
    static int columns = 4;
    static int rows = 4;
    static int totalCards = columns * rows;
    int matchesNeededToWin = totalCards / 2;
    int machesMade = 0;
    int cardWidth = 100;
    int cardHeight = 100;
    List<Object[]> arrayCards;
    Object[,] gridOfCards;
    ArrayList arrayCardsFlipped;
    bool playerCanClick; //flag to prevent clicking
    bool playerHasWon = false; 

    // Use this for initialization
    void Start()
    {
        playerCanClick = true;
        arrayCards = new List<Object[]>();
        gridOfCards = new Object[rows, columns];
        arrayCardsFlipped = new ArrayList();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gridOfCards[i,j] = new Object();
            }
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        BuildGrid();
        GUILayout.EndArea();
    }

    private void BuildGrid()
    {
        GUILayout.BeginVertical();
        for (int i = 0; i < rows; i++)
        {
            GUILayout.BeginHorizontal();
            for (int j = 0; j < columns; j++)
            {
                Object card= gridOfCards[i,j];
                if (GUILayout.Button(Resources.Load(card.img) as Texture2D, GUILayout.Width(cardWidth)))
                {
                    Debug.Log(card.img);
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }

    class Object : System.Object
    {
        bool isFaceUp = false;
        bool isMatched = false;
        public String img;
        public Object()
        {
            img = "robot";
        }
    }
}
