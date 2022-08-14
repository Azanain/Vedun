using UnityEngine;

public class Bridge : MonoBehaviour
{
    private int numberBrokenChains;
    private int needBrokenChains;

    [SerializeField] private GameObject[] cheins;

    public void BrokeChain()
    {
        numberBrokenChains++;
        
        if (numberBrokenChains >= needBrokenChains)
        {
            for (int i = 0; i < cheins.Length; i++)
            {
                Destroy(cheins[i]);
            }
        }
    }
}