using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsData : MonoBehaviour
{
	public Sprite Back;
	public Sprite KS; public Sprite QS; public Sprite JS; public Sprite S10; 
	public Sprite KH; public Sprite QH; public Sprite JH; public Sprite H10;
	public Sprite KD; public Sprite QD; public Sprite JD; public Sprite D10;
	public Sprite KC; public Sprite QC; public Sprite JC; public Sprite C10;
	
	public Sprite S9; public Sprite S8; public Sprite S7; public Sprite S6;
	public Sprite H9; public Sprite H8; public Sprite H7; public Sprite H6;
	public Sprite D9; public Sprite D8; public Sprite D7; public Sprite D6;
	public Sprite C9; public Sprite C8; public Sprite C7; public Sprite C6;
	
	public Sprite S5; public Sprite S4; public Sprite S3; public Sprite S2;
	public Sprite H5; public Sprite H4; public Sprite H3; public Sprite H2;
	public Sprite D5; public Sprite D4; public Sprite D3; public Sprite D2;
	public Sprite C5; public Sprite C4; public Sprite C3; public Sprite C2;
	
	public Sprite AS;
	public Sprite AH;
	public Sprite AD;
	public Sprite AC;

	public Card CardBack;
	
	public Card KingOfSpades  ; public Card QueenOfSpades  ; public Card JackOfSpades  ;
	public Card KingOfHearts  ; public Card QueenOfHearts  ; public Card JackOfHearts  ;
	public Card KingOfDiamonds; public Card QueenOfDiamonds; public Card JackOfDiamonds;
	public Card KingOfClovers ; public Card QueenOfClovers ; public Card JackOfClovers ;
	
	public Card TenOfSpades  ; public Card NineOfSpades  ; public Card EightOfSpades  ;
	public Card TenOfHearts  ; public Card NineOfHearts  ; public Card EightOfHearts  ;
	public Card TenOfDiamonds; public Card NineOfDiamonds; public Card EightOfDiamonds;
	public Card TenOfClovers ; public Card NineOfClovers ; public Card EightOfClovers ;
	
	public Card SevenOfSpades  ; public Card SixOfSpades  ; public Card FiveOfSpades  ;
	public Card SevenOfHearts  ; public Card SixOfHearts  ; public Card FiveOfHearts  ;
	public Card SevenOfDiamonds; public Card SixOfDiamonds; public Card FiveOfDiamonds;
	public Card SevenOfClovers ; public Card SixOfClovers ; public Card FiveOfClovers ;
	
	public Card FourOfSpades  ; public Card ThreeOfSpades  ; public Card TwoOfSpades  ;
	public Card FourOfHearts  ; public Card ThreeOfHearts  ; public Card TwoOfHearts  ;
	public Card FourOfDiamonds; public Card ThreeOfDiamonds; public Card TwoOfDiamonds;
	public Card FourOfClovers ; public Card ThreeOfClovers ; public Card TwoOfClovers ;
	
	public Card AceOfSpades  ;
	public Card AceOfHearts  ;
	public Card AceOfDiamonds;
	public Card AceOfClovers ;

	private ArrayList cards = new ArrayList();
	private Dictionary<int, Card> _allCards = new Dictionary<int, Card>();

	private void Awake()
	{
	    CardBack = new Card("Card Back", Back, 0, Decks.NONE);
	    
	    AceOfSpades   = new Card("Ace of Spades",         AS,        14,        Decks.SPADES);
	    AceOfHearts   = new Card("Ace of Hearts",         AH,        14,        Decks.HEART);
	    AceOfDiamonds = new Card("Ace of Diamonds",       AD,        14,        Decks.DIAMOND);
	    AceOfClovers  = new Card("Ace of Clovers",        AC,        14,        Decks.CLOVER);
	    
	    KingOfSpades   = new Card("King of Spades",         KS,    13,       Decks.SPADES);
	    KingOfHearts   = new Card("King of Hearts",         KH,    13,        Decks.HEART);
	    KingOfDiamonds = new Card("King of Diamonds",     KD,    13,        Decks.DIAMOND);
	    KingOfClovers   = new Card("King of Clovers",        KC,    13,        Decks.CLOVER);
	    
	    QueenOfSpades   = new Card("Queen of Spades",         QS,    12,        Decks.SPADES);
	    QueenOfHearts   = new Card("Queen of Hearts",         QH,    12,        Decks.HEART);
	    QueenOfDiamonds = new Card("Queen of Diamonds",     QD,    12,        Decks.DIAMOND);
	    QueenOfClovers  = new Card("Queen of Clovers",        QC,    12,        Decks.CLOVER);
	    
	    JackOfSpades   = new Card("Jack of Spades",         JS,    11,        Decks.SPADES);
	    JackOfHearts   = new Card("Jack of Hearts",         JH,    11,        Decks.HEART);
	    JackOfDiamonds = new Card("Jack of Diamonds",     JD,    11,        Decks.DIAMOND);
	    JackOfClovers  = new Card("Jack of Clovers",        JC,    11,        Decks.CLOVER);
	    
	    TenOfSpades   = new Card("10 of Spades",         S10,    10,        Decks.SPADES);
	    TenOfHearts   = new Card("10 of Hearts",         H10,    10,        Decks.HEART);
	    TenOfDiamonds = new Card("10 of Diamonds",     D10,    10,        Decks.DIAMOND);
	    TenOfClovers  = new Card("10 of Clovers",        C10,    10,        Decks.CLOVER);
	    
	    NineOfSpades   = new Card("9 of Spades",         S9,        9,        Decks.SPADES);
	    NineOfHearts   = new Card("9 of Hearts",         H9,        9,        Decks.HEART);
	    NineOfDiamonds = new Card("9 of Diamonds",       D9,        9,        Decks.DIAMOND);
	    NineOfClovers  = new Card("9 of Clovers",        C9,        9,        Decks.CLOVER);
	    
	    EightOfSpades   = new Card("8 of Spades",         S8,        8,        Decks.SPADES);
	    EightOfHearts   = new Card("8 of Hearts",         H8,        8,        Decks.HEART);
	    EightOfDiamonds = new Card("8 of Diamonds",       D8,        8,        Decks.DIAMOND);
	    EightOfClovers  = new Card("8 of Clovers",        C8,        8,        Decks.CLOVER);
	    
	    SevenOfSpades   = new Card("7 of Spades",         S7,        7,        Decks.SPADES);
	    SevenOfHearts   = new Card("7 of Hearts",         H7,        7,        Decks.HEART);
	    SevenOfDiamonds = new Card("7 of Diamonds",       D7,        7,        Decks.DIAMOND);
	    SevenOfClovers  = new Card("7 of Clovers",        C7,        7,        Decks.CLOVER);
	    
	    SixOfSpades   = new Card("6 of Spades",         S6,        6,        Decks.SPADES);
	    SixOfHearts   = new Card("6 of Hearts",         H6,        6,        Decks.HEART);
	    SixOfDiamonds = new Card("6 of Diamonds",       D6,        6,        Decks.DIAMOND);
	    SixOfClovers  = new Card("6 of Clovers",        C6,        6,        Decks.CLOVER);
	    
	    FiveOfSpades   = new Card("5 of Spades",         S5,        5,        Decks.SPADES);
	    FiveOfHearts   = new Card("5 of Hearts",         H5,        5,        Decks.HEART);
	    FiveOfDiamonds = new Card("5 of Diamonds",       D5,        5,        Decks.DIAMOND);
	    FiveOfClovers  = new Card("5 of Clovers",        C5,        5,        Decks.CLOVER);
	    
	    FourOfSpades   = new Card("4 of Spades",         S4,        4,        Decks.SPADES);
	    FourOfHearts   = new Card("4 of Hearts",         H4,        4,        Decks.HEART);
	    FourOfDiamonds = new Card("4 of Diamonds",       D4,        4,        Decks.DIAMOND);
	    FourOfClovers  = new Card("4 of Clovers",        C4,        4,        Decks.CLOVER);
	    
	    ThreeOfSpades   = new Card("3 of Spades",         S3,        3,        Decks.SPADES);
	    ThreeOfHearts   = new Card("3 of Hearts",         H3,        3,        Decks.HEART);
	    ThreeOfDiamonds = new Card("3 of Diamonds",       D3,        3,        Decks.DIAMOND);
	    ThreeOfClovers  = new Card("3 of Clovers",        C3,        3,        Decks.CLOVER);
	    
	    TwoOfSpades   = new Card("2 of Spades",         S2,        2,        Decks.SPADES);
	    TwoOfHearts   = new Card("2 of Hearts",         H2,        2,        Decks.HEART);
	    TwoOfDiamonds = new Card("2 of Diamonds",       D2,        2,        Decks.DIAMOND);
	    TwoOfClovers  = new Card("2 of Clovers",        C2,        2,        Decks.CLOVER);

	}


	public void Start()
	{
		ResetCards();
		foreach (Card card in cards)
		{
			_allCards.Add(card.ID, card);
		}
	}

	public void ResetCards()
	{
		cards.Add(KingOfSpades);
		cards.Add(KingOfHearts);
		cards.Add(KingOfDiamonds);
		cards.Add(KingOfClovers);
		
		cards.Add(QueenOfSpades);
		cards.Add(QueenOfHearts);
		cards.Add(QueenOfDiamonds);
		cards.Add(QueenOfClovers);
		
		cards.Add(JackOfSpades);
		cards.Add(JackOfHearts);
		cards.Add(JackOfDiamonds);
		cards.Add(JackOfClovers);
		
		cards.Add(TenOfSpades);
		cards.Add(TenOfHearts);
		cards.Add(TenOfDiamonds);
		cards.Add(TenOfClovers);
		
		cards.Add(NineOfSpades);
		cards.Add(NineOfHearts);
		cards.Add(NineOfDiamonds);
		cards.Add(NineOfClovers);
		
		cards.Add(EightOfSpades);
		cards.Add(EightOfHearts);
		cards.Add(EightOfDiamonds);
		cards.Add(EightOfClovers);
		
		cards.Add(SevenOfSpades);
		cards.Add(SevenOfHearts);
		cards.Add(SevenOfDiamonds);
		cards.Add(SevenOfClovers);
		
		cards.Add(SixOfSpades);
		cards.Add(SixOfHearts);
		cards.Add(SixOfDiamonds);
		cards.Add(SixOfClovers);
		
		cards.Add(FiveOfSpades);
		cards.Add(FiveOfHearts);
		cards.Add(FiveOfDiamonds);
		cards.Add(FiveOfClovers);
		
		cards.Add(FourOfSpades);
		cards.Add(FourOfHearts);
		cards.Add(FourOfDiamonds);
		cards.Add(FourOfClovers);
		
		cards.Add(ThreeOfSpades);
		cards.Add(ThreeOfHearts);
		cards.Add(ThreeOfDiamonds);
		cards.Add(ThreeOfClovers);
		
		cards.Add(TwoOfSpades);
		cards.Add(TwoOfHearts);
		cards.Add(TwoOfDiamonds);
		cards.Add(TwoOfClovers);
		
		cards.Add(AceOfSpades);
		cards.Add(AceOfHearts);
		cards.Add(AceOfDiamonds);
		cards.Add(AceOfClovers);
	}

	public Card GetRandomCard()
	{
		if (cards.Count < 1) return null;
		int x = Random.Range(0, cards.Count);
		Card c = (Card) cards[x];
		cards.RemoveAt(x);
		return c;
	}

	public Card GetCardByID(int id)
	{
		Card card;
		_allCards.TryGetValue(id, out card);
		return card;
	}
}
    