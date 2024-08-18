using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingpanSound : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private float maxV, minV, defoV, decreaseVps;
    private float v;
    // Start is called before the first frame update
    void Start()
    {
        v = maxV;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(decreaseVps * Time.deltaTime);
        if (v > minV)
        {
            Debug.Log("å∏è≠");
            v -= decreaseVps * Time.deltaTime;
            if (v < minV)
            {
                //ç≈í·ï€èÿ
                v = minV;
            }
        }
        Debug.Log(v);
        audioSource.volume = v;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("êGÇÍÇΩ");
        if (collision.gameObject.tag == "Pancake" || collision.gameObject.tag == "Topping")
        {
            if (v < (defoV + minV) / 2)
            {
                v = maxV;
                Debug.Log("ëùâ¡" + v);
            }
            else if (v < defoV)
            {

                v = defoV;
            }


        }
    }
}
