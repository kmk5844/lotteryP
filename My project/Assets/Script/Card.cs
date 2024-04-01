using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour,IPointerClickHandler
{
    public GameObject Text;
    public GameObject button;
    public Image targetImage;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Animator Anim;

    public void OnPointerClick(PointerEventData eventData)
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.SetBool("Turn",true);
       // targetImage.sprite = frontSprite;

      //  Text.SetActive(true);
       // button.SetActive(true);
    }

    public void OnAllOpen()
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.SetBool("Turn", true);
        // targetImage.sprite = frontSprite;
       // Text.SetActive(true);
       // button.SetActive(true);
    }

    public void OnChangeButton()
    {
      //  Anim.SetBool("Turn", true);
        Anim = gameObject.GetComponent<Animator>();
        Anim.SetBool("Turn", false);
        //  targetImage.sprite = backSprite;
       // Text.SetActive(false);
       // button.SetActive(false);
        Director directorObject = GameObject.Find("Director").GetComponent<Director>();
        directorObject.ChangeList(transform.gameObject);
    }

    public void Reset(PointerEventData eventData)
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.SetBool("Turn", false);
        // targetImage.sprite = frontSprite;

        //  Text.SetActive(true);
        // button.SetActive(true);
    }
}
