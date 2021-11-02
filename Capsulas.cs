using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsulas : MonoBehaviour
{
    public GameObject Capsula;

    public float sec = 10f;
    public Capsulas Capsul;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Capsula.SetActive(false);
            Capsul.StartCoroutine(LateCall(sec));

        }
    }

    IEnumerator LateCall(float seconds)
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);

        yield return new WaitForSeconds(seconds);

        Capsula.SetActive(true);
        //Do Function here...
    }

}
