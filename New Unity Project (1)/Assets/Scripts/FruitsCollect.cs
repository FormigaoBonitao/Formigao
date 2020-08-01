using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitsCollect : MonoBehaviour
{
    public static int fruitsCount;
    private Text fruitsCounter;
    public GameObject final;
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        fruitsCounter = GetComponent<Text>();
        fruitsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
     //  fruitsCounter.text = "X " + fruitsCount + " /10";

        if (fruitsCount == 10)
        {
            final.gameObject.SetActive(true);
            end.gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
