using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SyncText : MonoBehaviour
{
    public TextMeshProUGUI target; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = target.text;
    }
}
