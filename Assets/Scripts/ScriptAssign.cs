
using UnityEngine;
using UnityEngine.UI;

public class ScriptAssign : MonoBehaviour
{
	// Start is called before the first frame update
    void Start()
    {
	    
	    //CardsData.card 
    }

    // Update is called once per frame
    void Update()
    {
	    GameObject cardsObj = GameObject.FindWithTag("Cards");
	    CardsData cardsData = cardsObj.GetComponent<CardsData>();
	    Debug.Log(cardsData);
	    Card c = cardsData.GetRandomCard();
	    if(c != null)
			GetComponent<Image>().sprite = c.Image;
    }
}
