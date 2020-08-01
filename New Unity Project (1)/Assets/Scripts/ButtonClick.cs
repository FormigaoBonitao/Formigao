
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
     


    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)

               
{

        if (gameObject.name == "up")
        {
            GameObject.Find("Character").GetComponent<CharacterController>().Jump();
        }

        if (gameObject.name == "right")
        {

            GameObject.Find("Character").GetComponent<CharacterController>().anim.SetBool("Run", true);

            GameObject.Find("Character").GetComponent<CharacterController>().move = 1;
        }
        else if (gameObject.name == "left")
        {
            GameObject.Find("Character").GetComponent<CharacterController>().move = -1;
            GameObject.Find("Character").GetComponent<CharacterController>().anim.SetBool("Run", true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        GameObject.Find("Character").GetComponent<CharacterController>().move = 0;
        GameObject.Find("Character").GetComponent<CharacterController>().anim.SetBool("Run", false);


    }        






    // Update is called once per frame
   
}
