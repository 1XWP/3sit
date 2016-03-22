using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

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
    Card[,] gridOfCards;
    ArrayList arrayCardsFlipped;
    bool playerCanClick; //flag to prevent clicking
    bool playerHasWon = false;

    // Use this for initialization
    void Start()
    {
        playerCanClick = true;
        gridOfCards = new Card[rows, columns];
        arrayCardsFlipped = new ArrayList();
        System.Random rnd = new System.Random();
        List<string> fruits = new List<string>(new string[] { "apple", "orange", "cherry", "carrot", "pinneaple", "watermelon", "raspberry", "strawberry", "apple", "orange", "cherry", "carrot", "pinneaple", "watermelon", "raspberry", "strawberry" });
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {  
                 int someNum = rnd.Next(0, fruits.Count);
                 gridOfCards[i, j] = new Card(fruits.ElementAt(someNum));
                 fruits.RemoveAt(someNum);   
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
        GUILayout.FlexibleSpace();
        for (int i = 0; i < rows; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            for (int j = 0; j < columns; j++)
            {
                Card card= gridOfCards[i,j];
                if (GUILayout.Button(Resources.Load(card.img) as Texture2D, GUILayout.Width(cardWidth)))
                {
                    Debug.Log(card.img);
                }
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }

    class Card : System.Object
    {
        bool isFaceUp = false;
        bool isMatched = false;
        public String img;
     
        public Card(string choosedCard)
        {
            this.img = choosedCard;
        }
    }
}
