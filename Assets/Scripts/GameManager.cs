using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

    public Sprite[] cardFaces;
	public GameObject cardPrefab;

    private GameObject[] deck = new GameObject[52];

    // Start is called before the first frame update
    void Start() {
       deck = GenerateDeck();
    //    Shuffle(deck);
       foreach (GameObject card in deck) {
            print(card.name);
       }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject[] GenerateDeck() {
        GameObject[] newDeck = new GameObject[52];
        int i = 0;
        foreach (string s in suits) {
            foreach (string v in values) {
                GameObject newCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newCard.name = v + s;
                // newCard.addComponent<Sprite>(cardFaces[i]);
                deck[i] = newCard;
                i++;
            }
        }
        return newDeck;
    }

    // Shuffling code taken from https://stackoverflow.com/questions/273313/randomize-a-listt
    public static void Shuffle<T>(IList<T> list)  
    {  
        System.Random random = new System.Random();
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

    // public static void DealCards() {
    //     foreach (string card in deck) {
    //         GameObject newCard = new GameObject();
    //         // newCard.name = card;
    //     }
    // }
}
