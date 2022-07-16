using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    Statulator statulator;
    Bestiary bestiary;
    // Start is called before the first frame update
    void Start()
    {
    statulator=gameObject.GetComponentInParent<Statulator>();
    bestiary=statulator.bestiary;
        Instantiate(bestiary.model,transform.position,Quaternion.identity,transform.parent=transform);//Statulator script is probably not the best place for this.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
