using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class coincount : MonoBehaviour
{
    public Text coinountText;
    int count = 0;
    public Text coinsText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinountText.text = count.ToString();
        coinsText.text = "Coins"+count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}
