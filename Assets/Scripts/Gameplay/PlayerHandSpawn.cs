using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandSpawn : MonoBehaviour
{
    [SerializeField] public Transform cardObject;
    [SerializeField] public Transform cardObjectParent;

    [SerializeField] public int[] testData;
    
    private CardsData _cardsData;
    public void Start()
    {
        GameObject cardsObj = GameObject.FindWithTag("Cards");
        _cardsData = cardsObj.GetComponent<CardsData>();
        
        Invoke(nameof(CardCreationTest),2f);
    }

    private void CardCreationTest()
    {
        CreateHandOf(testData);
        
    }

    public void CreateHandOf(int[] ids)
    {
        var rOffset = 10;
        var center = ids.Length / 2;
        for (int i = 0; i < ids.Length; i++)
        {
            var cardButton = Instantiate(cardObject, cardObjectParent, false);
            cardButton.transform.localPosition = new Vector3(-440,-240);
            if (i < center)
            {
                var r = (center - i) * rOffset;
                cardButton.Rotate(new Vector3(0f,0f,r));
            }
            else if (i > center)
            {
                var r = (i - center) * -rOffset;
                cardButton.Rotate(new Vector3(0f,0f,r));
            }
            var id = ids[i];
            Card card = _cardsData.GetCardByID(id);
            cardButton.GetComponent<Image>().sprite = card?.Image;
            
            cardButton.GetComponent<Button>().onClick.AddListener(delegate { CardSelect(id);  });
        }
    }
    
    

    public void CardSelect(int cardID)
    {
        Card card = _cardsData.GetCardByID(cardID);
        Debug.Log("Card Selected " + card.Name);
    }
}
