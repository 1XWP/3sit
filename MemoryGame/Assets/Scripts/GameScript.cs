using UnityEngine;
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
    public List<Card> arrayCardsFlipped;
    bool playerCanClick; //flag to prevent clicking
    bool playerHasWon = false;
    Timer timer;

    void Awake()
    {
        timer = GetComponent<Timer>();
    }

    // Use this for initialization
    void Start()
    {
        playerCanClick = true;
        gridOfCards = new Card[rows, columns];
        arrayCardsFlipped = new List<Card>();
        System.Random rnd = new System.Random();
        int id = 0;
        List<string> fruits = new List<string>(new string[] { "apple", "orange", "cherry", "carrot", "pinneaple", "watermelon", "raspberry", "strawberry", "apple", "orange", "cherry", "carrot", "pinneaple", "watermelon", "raspberry", "strawberry" });
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int someNum = rnd.Next(0, fruits.Count);
                gridOfCards[i, j] = new Card(fruits.ElementAt(someNum), id);
                id++;
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
                Card card = gridOfCards[i, j];
                string img;
                if (card.isFaceUp)
                {
                    img = card.img;
                }
                else
                {
                    img = "wrench";
                }

                GUI.enabled = !card.isMatched;
                if (GUILayout.Button(Resources.Load(img) as Texture2D, GUILayout.Width(cardWidth)))
                {
                    if (playerCanClick)
                    {
                        FlipCardFaceUp(card);
                    }
                }
                GUI.enabled = true;
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
            if (arrayCardsFlipped.Count == 2)
            {
                if (arrayCardsFlipped[0].img.ToString() == arrayCardsFlipped[1].img.ToString())
                {
                    playerCanClick = false;
                    arrayCardsFlipped.ForEach(SetMatch);
                    arrayCardsFlipped = new List<Card>();
                    playerCanClick = true;
                }
            }
            if (arrayCardsFlipped.Count > 2)
            {
                playerCanClick = false;
                arrayCardsFlipped.ForEach(SetDown);
                arrayCardsFlipped = new List<Card>();
                playerCanClick = true;
            }
        }
    }

    public void SetMatch(Card obj)
    {
        obj.isMatched = true;
    }

    public void SetDown(Card obj)
    {
        obj.isFaceUp = false;
    }

    public class Card : System.Object
    {
        public bool isFaceUp = false;
        public bool isMatched = false;
        public String img;
        public int id;

        public Card(string choosedCard, int id)
        {
            this.img = choosedCard;
            this.id = id;
        }
    }
}
