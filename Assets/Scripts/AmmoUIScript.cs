using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUIScript : MonoBehaviour
{
    public TextMeshProUGUI AmmoUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshAmmoDisplay(int ammoCount,int ammoMax) {
        AmmoUI.text = ammoCount + "/" + ammoMax;
    }
}
