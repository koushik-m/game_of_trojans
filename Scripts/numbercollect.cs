using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numbercollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            string val = gameObject.GetComponent<TextMesh>().text;
            Debug.Log("player collected number - " + val);
            //scoreCalc.score += int.Parse(val);
            Destroy(gameObject);
        }
    }
}
