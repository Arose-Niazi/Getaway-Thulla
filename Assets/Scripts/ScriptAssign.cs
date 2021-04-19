
using UnityEngine;
using UnityEngine.UI;

public class ScriptAssign : MonoBehaviour
{
	// Start is called before the first frame update
    void Start()
    {
	    GameObject cardsObj = GameObject.FindWithTag("Cards");
	    CardsData cardsData = cardsObj.GetComponent<CardsData>();
	    GetComponent<Image>().sprite = cardsData.CardBack.Image;
	    //CardsData.card 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
