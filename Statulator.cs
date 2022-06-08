using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statulator : MonoBehaviour
{
    [SerializeField]
 //   private bool debugMode=false;
    public Bestiary bestiary;
    [HideInInspector]
    public float placeholder;

    public float sizeModifier;
    

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name=bestiary.nameOf+" - "+Time.time;
        sizeModifier=Random.Range((float)bestiary.size,(float)bestiary.size*1.9f);
        Instantiate(bestiary.model,transform.position,Quaternion.identity,transform.parent=transform);




        
        
        
        
        
        
        CreateAura();
        if (bestiary.nameOf == "DeBeetle") {DeBeetleSpoor();}
        //AdjustForSize();
    }
    void DeBeetleSpoor()
    /* DeBeetle to be used to DeBug */
    {
        Debug.Log("You see Bug tracks, they look like:");
        //Debug.Log("Statulator-ViewDist - "+this_viewDist);
    }
    void CreateAura()
    {
        GameObject aura = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        aura.transform.parent=gameObject.transform;
        aura.name="aura";
        aura.transform.position=gameObject.transform.position;
        float auraSize=bestiary.viewDist*sizeModifier;
        aura.transform.localScale=new Vector3(auraSize,auraSize,auraSize);
        
       // Collider auraCollider=GetComponent<Collider>;
        //aura.transform.Collider.isTrigger=true;
        
        //MeshRenderer auraMeshRender=GetComponent<MeshRenderer>;
       // auraMeshRender.isVisible=false;
    }
    void AdjustForSize()
    {
        gameObject.transform.parent.localScale=gameObject.transform.parent.localScale*sizeModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
