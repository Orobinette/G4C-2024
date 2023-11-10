using UnityEngine;
using UnityEngine.Events;

public class YearManager : MonoBehaviour
{
    public int yearCount {get; private set;} = 0;
    public UnityEvent<int> endOfYear;

    public void YearButton(int yearsPassed)
    {
        yearCount += yearsPassed;
        Debug.Log("Year = "  + yearCount);
        endOfYear.Invoke(yearsPassed);
    }
}
