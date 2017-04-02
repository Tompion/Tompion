using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomCard : MonoBehaviour {
    public enum CardType
    {
        Soldier, Building, Settlement, KingArmour, KingWeapon, SoldierEquip, Weather, Castle, Artillery, None
    }
    public class Card
    {

        public int GoldCost;
        public int CivilianCost;
        public int Attack;
        public int Defense;
        public CardType Type;
        public string Description;
        void SetCard(int fGoldCost, int fCivilianCost, int fAttack, int fDefense, CardType fType, string fDescription)
        {
            GoldCost = fGoldCost;
            CivilianCost = fCivilianCost;
            Attack = fAttack;
            Defense = fDefense;
            Type = fType;
            Description = fDescription;
        }
        public Card()
        {
            SetCard(0, 0, 0, 0, CardType.None, "Nothing here of interest");

        }
        public Card(int fGoldCost, int fCivilianCost, int fAttack, int fDefense, CardType fType, string fDescription)
        {
            SetCard(fGoldCost, fCivilianCost, fAttack, fDefense, fType, fDescription);

        }
        string ToString()
        {
            return "GoldCost: " + GoldCost + " CivilianCost: " + CivilianCost + " Attack: " + Attack + " Defense: " + Defense + " Type: " + Type;
        }
    }
    GameObject topCard, secondCard;
    public GameObject CardGO;
    int curIndex = 0;
    Card[] Deck = new Card[52];
   
	Card CardGenerator(int ftype){
		//Debug.Log ("word");
		switch (ftype) {
		case 0:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 1:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 2:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 3:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 4:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 5:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 6:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 7:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		case 8:
			return new Card (1, 1, 1, 1, CardType.Soldier, "A Common warrior seen in all armies");
			break;
		default:
			return new Card ();
			break;
		}
		//Debug.Log ("word");
	}
    void SetTextOfGameObjectToCardText(ref GameObject tCard, Card fCard) {
        foreach(Transform child in tCard.transform)
        {
            if (child.name == "Card Title")
            {
                child.gameObject.GetComponent<Text>().text = fCard.Type.ToString();
            }
            else if (child.name == "Card Description")
            {
                child.gameObject.GetComponent<Text>().text = fCard.Description + "\n"
                                                            + "Atk/Def = " + fCard.Attack + "/" + fCard.Defense + "\n"
                                                            + "Gld/Civ = " + fCard.GoldCost + "/" + fCard.CivilianCost + "\n";
            }

        }
    }
    GameObject InstantiateCard(Card fCard) {
        GameObject tCard = GameObject.Instantiate(CardGO,this.transform);
        tCard.transform.position += tCard.transform.localScale / 2;
        SetTextOfGameObjectToCardText(ref tCard, fCard);
        return tCard;
    }
	void Start () {
		Debug.Log ("word");
        curIndex = 0;
		for (int i = 0; i < 52; i++) {
			Deck[i] = CardGenerator (Random.Range (0, 9));
			Debug.Log (Deck [i].ToString());
		}
        secondCard = InstantiateCard(Deck[curIndex + 1]);
        secondCard.transform.SetParent(this.transform);
        secondCard.GetComponent<Draggable>().enabled = false;
        secondCard.name = "Second Card";
        foreach (Transform child in secondCard.transform) Destroy(child.gameObject);
    }
    int oldChildCount = -1;
	// Update is called once per frame
	void Update () {
        if (curIndex > 50) {
            curIndex = 0;
            for (int i = 0; i < 52; i++)
            {
                Deck[i] = CardGenerator(Random.Range(0, 9));
                Debug.Log(Deck[i].ToString());
            }
        }
        if (oldChildCount != this.transform.childCount) {
           if (!topCard || (!topCard.GetComponent<Draggable>().isDragging && topCard.transform.parent != this.transform))
            {
                
                topCard = InstantiateCard(Deck[curIndex]);
                topCard.GetComponent<CanvasGroup>().alpha = 0.0f;
                
                topCard.transform.SetParent(this.transform);
                secondCard.transform.SetAsFirstSibling();
                oldChildCount = this.transform.childCount;
                curIndex++;
                //SetTextOfGameObjectToCardText(ref secondCard, Deck[curIndex]);*/
            }
        }
        if (topCard.GetComponent<Draggable>().isDragging) {
            topCard.GetComponent<CanvasGroup>().alpha = 1.0f;

        }
        else  {
            if (topCard.transform.parent == this.transform)
            {
                topCard.GetComponent<CanvasGroup>().alpha = 0.0f;
                topCard.transform.position = this.transform.position;
                secondCard.transform.SetAsFirstSibling();
            }
        }
	}
}
