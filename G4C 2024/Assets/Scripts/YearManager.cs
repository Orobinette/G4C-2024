using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class YearManager : MonoBehaviour
{
    //Member variables
    public int yearCount {get; private set;} = 0;
    public UnityEvent<int> endOfYear;

    public void YearButton(int yearsPassed)
    {
        yearCount += yearsPassed;
        endOfYear.Invoke(yearsPassed);
    }
}
