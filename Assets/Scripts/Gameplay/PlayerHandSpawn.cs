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
        var xOffset = 10;
        var rOffset = 10;
        var yOffset = 2f;
        for (int i = 0; i < ids.Length; i++)
        {
            var cardButton = Instantiate(cardObject, cardObjectParent, false);
            if (i < ids.Length / 2)
            {
                var x = -440 - (ids.Length / 2 - i) * xOffset;
                var y = -240 - (ids.Length / 2 - i) * yOffset;
                var r = (ids.Length / 2 - i) * rOffset;
                cardButton.transform.localPosition = new Vector3(x,y);
                //Debug.Log($"Spawning Card at ({x},{y})");
                cardButton.Rotate(new Vector3(0f,0f,r));
            }
            else if (i > ids.Length / 2)
            {
                var x = -440 + (i - ids.Length / 2) * xOffset;
                var y = -240 - (i - ids.Length / 2) * yOffset;
                var r = (i - ids.Length / 2) * -rOffset;
                cardButton.transform.localPosition = new Vector3(x,y);
                //Debug.Log($"Spawning Card at ({x},{y})");
                cardButton.Rotate(new Vector3(0f,0f,r));
            }
            else
            {
                cardButton.transform.localPosition = new Vector3(-440,-240);
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
