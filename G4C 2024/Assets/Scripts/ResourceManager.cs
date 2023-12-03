using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    //Object and Component References
    [SerializeField] YearManager yearManager;

    [SerializeField] TextMeshProUGUI foodCountText;
    [SerializeField] TextMeshProUGUI waterCountText;
    [SerializeField] TextMeshProUGUI populationCountText;

    //Member Variables
    Resource food;
    Resource water;
    Resource population;

    Resource[] resourceList;

    void Start()
    {
        yearManager.endOfYear.AddListener(UpdateResources);

        food = new Resource(10,  "Food:", foodCountText);
        water = new Resource(10, "Water:", waterCountText);
        population = new Resource(10, "Population:", populationCountText);

        resourceList = new Resource[]{food, water, population};
    }

    void UpdateResources(int yearCount)
    {
        for(int i = 0; i < yearCount; i++)
        {
            foreach(Resource resource in resourceList)
            {
                resource.UpdateResource();
            }
        }
    }

    public class Resource
    {  
        //Member Variables
        public int count {get; private set;}
        int modifiedRateOfChange;
        int baseRateOfChange;

        string textCounterLabel;
        TextMeshProUGUI textCounter;

        //Constructors
        public Resource(int rateOfChange, string label, TextMeshProUGUI txtCounter)
        {
            baseRateOfChange = rateOfChange;
            modifiedRateOfChange = baseRateOfChange;
            count = 0;

            textCounterLabel = label;
            textCounter = txtCounter;
            textCounter.text = label + " " + count;
        }

        public Resource(int initialCount, int rateOfChange, string label, TextMeshProUGUI txtCounter)
        {
            baseRateOfChange = rateOfChange;
            modifiedRateOfChange = baseRateOfChange;
            count = initialCount;

            textCounterLabel = label;
            textCounter = txtCounter;
            textCounter.text = label + " " + count;
        }

        //Setters
        public void setRateOfChange(int amount, string modifierOperator)
        {
            switch(modifierOperator)
            {
                case "+":
                    modifiedRateOfChange += amount;
                    break;
                case "*":
                    modifiedRateOfChange *= amount;
                    break;
            }
        }
        

        //Mutators
        public void UpdateResource()
        {
            count += modifiedRateOfChange;
            textCounter.text = textCounterLabel + " " + count;
        }
    }
}
