using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    public string animalToHunt;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitHuntedAnimal(string animalTag)
    {
        if (animalTag != animalToHunt)
        {
            score -= 1;
        }
        else score += 1;
    }
}
