using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFaces;
	public GameObject cardPrefab;

    private GameObject[] deck;

    // Start is called before the first frame update
    void Start() {
       Shuffle(cardFaces);
       deck = GenerateDeck(GenerateCardNames());
    }

    // Update is called once per frame
    void Update() {
        
    }

    public string[] GenerateCardNames() {
        string[] suits = new string[] {"C", "D", "H", "S"};
        string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        string[] cardNames = new string[52];
        int i = 0;
        foreach (string s in suits) {
            foreach (string v in values) {
                cardNames[i++] = s + v;
            }
        }
        Shuffle(cardNames);
        return cardNames;
    }

    public GameObject[] GenerateDeck(string[] cardNames) {
        GameObject[] newDeck = new GameObject[52];
        float x = -8F;
        float z = 0F;
        int i = 0;
        foreach (string s in cardNames) {
            x += 0.3F;
            z -= 0.01F;
            GameObject card = Instantiate(cardPrefab, new Vector3(x, 0, z), Quaternion.identity);
            card.name = s;
            SpriteRenderer sr = card.GetComponent<SpriteRenderer>();
            sr.sprite = cardFaces[i++];
        }
        return newDeck;
    }

    // Shuffling code taken from https://stackoverflow.com/questions/273313/randomize-a-listt
    public static void Shuffle<T>(IList<T> list)  
    {  
        int seed = 696969; // Seed the random number generator so deck and cardFaces are in same order.
        System.Random random = new System.Random(seed);
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}
