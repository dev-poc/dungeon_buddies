using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aura : MonoBehaviour
{
    Bestiary parentBestiary;
    Statulator parentStatulator;
    DynamicStats parentDynamicStats;
    public GameObject[] inAura;
    
    private float auraSize=1;
    // Start is called before the first frame update
    void Start()
    {
        //parentBestiary=gameObject.GetComponentInParent<Bestiary>();
        parentStatulator=gameObject.GetComponentInParent<Statulator>();
        parentDynamicStats=gameObject.GetComponentInParent<DynamicStats>();

        ResizeAura();
        gameObject.name="aura";
        if (parentStatulator.bestiary.nameOf!="DeBeetle") {SetUpTriggering();}
    }
    void ResizeAura()
    {
        if (parentStatulator.sizeModifier==0)
        {
            Debug.Log("Aura forcing sizeModifier for parent");
            parentStatulator.sizeModifier=Random.Range((float)parentStatulator.bestiary.size,(float)parentStatulator.bestiary.size*1.9f);
        }
        auraSize=parentStatulator.bestiary.viewDist*parentStatulator.sizeModifier;
        gameObject.transform.localScale=new Vector3(auraSize,auraSize,auraSize);

    }
    void SetUpTriggering()
    {
        gameObject.GetComponent<Renderer>().enabled=false;
        gameObject.GetComponent<Collider>().isTrigger=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.transform.parent.name +" Entered Aura of "+parentStatulator.name);
        parentStatulator.otherNear=true;
        parentDynamicStats.nearbyThings.Add(other);
        Debug.Log(parentDynamicStats.nearbyThings);
    }



}
