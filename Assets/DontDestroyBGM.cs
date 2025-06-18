using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    //set the script DontDestroyBGM attached to this object as anyBGM
    private static DontDestroyBGM anyBGM;

    void Awake()
    {
        if (!anyBGM) //check if there is any object set as anyBGM
        {
            //set this object as anyBGM
            anyBGM = this;
            //keep this object when loading different scene
            DontDestroyOnLoad(this.gameObject);
        }
        else if (anyBGM) //check if there is any other object with anyBGM other than this object
        {
            //destroy this object if anyBGM already existed
            Destroy(this.gameObject);
        }

    }
}
