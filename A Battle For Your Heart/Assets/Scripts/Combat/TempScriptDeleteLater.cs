using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScriptDeleteLater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("girl be dancin");
            int hit = Random.Range(0, 2);
            if (hit == 0)
            {
                print("perfect");
                
            }
            if (hit == 1)
            {
                print("too early/too late");
            }
            if (hit == 2)
            {
                print("miss");

            }

        }
    }
}
