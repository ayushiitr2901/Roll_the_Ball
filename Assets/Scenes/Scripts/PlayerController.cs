using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text wintext;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setcountText();
        wintext.text = "";
        
    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick_Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setcountText();
            if(count >= 12)
            {
                wintext.text = "You Win!";
            }
        }
    }
    void setcountText()
    {
        countText.text = "Count : " + count.ToString();
    }
}
