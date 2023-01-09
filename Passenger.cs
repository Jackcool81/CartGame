using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Passenger", order = 1)]
public class Passenger : ScriptableObject
{

    //For these maps the first string will be like, dislike, nuetral indicating their relationship towards 
    // public Map<String, String> dialouge = new Map<String, String>(); 
    // //A keyword of dialouge

    // public Map<String, String> partners = new Map<String, String>();
    // //Another monster type

    // public Map<String, String> items = new Map<String, String>();
    //Items 

    public int seating; //1-4 indicating which seat they like, 0 for none

    public int[] distanceRange = new int[2]; 

}
