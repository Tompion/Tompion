using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCard : MonoBehaviour {
	enum CardType{
		Soldier = 0, Building = 1, Settlement = 2, KingArmour = 3, KingWeapon = 4, SoldierEquip = 5, Weather = 6, Castle = 7, Artillery = 8,None = 9
	}
	struct Card{
		int GoldCost;
		int CivilianCost;
		int Attack;
		int Defense;
		CardType Type;
		public Card(int fGoldCost,int fCivilianCost, int fAttack,int fDefense,CardType fType){
			GoldCost = fGoldCost;
			CivilianCost = fCivilianCost;
			Attack = fAttack;
			Defense = fDefense;
			Type = fType;

		}
		string ToString(){
			return "GoldCost: " + GoldCost + " CivilianCost: " + CivilianCost + " Attack: " + Attack + " Defense: " + Defense + " Type: " + Type;
		}
	}
	Card CardGenerator(int ftype){
		//Debug.Log ("word");
		switch (ftype) {
		case 0:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 1:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 2:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 3:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 4:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 5:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 6:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 7:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		case 8:
			return new Card (1, 1, 1, 1, CardType.Soldier);
			break;
		default:
			return new Card ();
			break;
		}
		//Debug.Log ("word");
	}
	void Start () {
		Debug.Log ("word");
		Card[] Deck = new Card[52];
		for (int i = 0; i < 52; i++) {
			Deck[i] = CardGenerator (Random.Range (0, 9));
			Debug.Log (Deck [i].ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
