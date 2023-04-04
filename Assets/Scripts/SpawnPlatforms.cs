using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    BallController ball = new BallController();
    [SerializeField] GameObject platformTemplate;
    [SerializeField] GameObject startPlatform;

    float old;
    float time;
    bool timer;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        old = 0;
        time = 0;
        GameObject clone;
        for (int i = 0; i < 20; i++) {
          
                Vector3 worldSpawnPoint = new Vector3(startPlatform.transform.position.x + startPlatform.transform.lossyScale.x, 0f, startPlatform.transform.position.z + startPlatform.transform.lossyScale.z) - platformTemplate.transform.lossyScale;
                clone = Instantiate(platformTemplate, worldSpawnPoint, new Quaternion(0, 0, 0, 0));
                startPlatform = platformTemplate;
            
          
        }
         
    }

    bool checkTime()
    {
        if(timer)
        {
            Debug.Log(true);
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {

         ;
        
        
    }
}
