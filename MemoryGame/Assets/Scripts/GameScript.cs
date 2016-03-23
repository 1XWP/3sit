using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
    List<Card> arrayCardsFlipped;
    bool playerCanClick; //flag to prevent clicking
    bool playerHasWon = false;

    // Use this for initialization
    void Start()
    {
        playerCanClick = true;
        gridOfCards = new Card[rows, columns];
        arrayCardsFlipped = new List<Card>();
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
                string img;
                if (card.isFaceUp)
                {
                    img = card.img;
                }
                else
                {
                    img = "wrench";
                }
                if (GUILayout.Button(Resources.Load(img) as Texture2D, GUILayout.Width(cardWidth)))
                {
                    if (playerCanClick)
                    {
                        FlipCardFaceUp(card);
                        //Thread.Sleep(2000);
                       // SetDown(card);
                    }
                    Debug.Log(card.img);
                }
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }

    private void FlipCardFaceUp(Card card)
    {
        card.isFaceUp = true;
        if (arrayCardsFlipped.Contains(card) == false)
        {
            arrayCardsFlipped.Add(card);
            if (arrayCardsFlipped.Count > 2)
            {
                playerCanClick = false;
               // Thread.Sleep(1000);
                arrayCardsFlipped.ForEach(SetDown);
                arrayCardsFlipped = new List<Card>();
                playerCanClick = true;
            }
        }
    }

    private void SetDown(Card obj)
    {
        obj.isFaceUp = false;
    }

    class Card : System.Object
    {
        public bool isFaceUp = false;
        bool isMatched = false;
        public String img;
     
        public Card(string choosedCard)
        {
            this.img = choosedCard;
        }
    }
}
