using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale0CoRoutine{
     public static IEnumerator WaitForRealTime(float delay){
         while(true){
             float pauseEndTime = Time.realtimeSinceStartup + delay;
             while (Time.realtimeSinceStartup < pauseEndTime){
                 yield return 0;
             }
             break;
         }
     }
 }