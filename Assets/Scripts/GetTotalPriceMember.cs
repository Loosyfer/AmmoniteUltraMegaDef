using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTotalPriceMember : MonoBehaviour
{
    private string traitPrice;
    private string profPrice;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        traitPrice = this.transform.parent.transform.parent.GetComponent<MemberHUD>().traitPrice.text;
        profPrice = this.transform.parent.transform.parent.GetComponent<MemberHUD>().profPrice.text;
        int sum1;
        int sum2;
        int sum;
        int.TryParse(traitPrice, out sum1);
        int.TryParse(profPrice, out sum2);
        sum = sum1 + sum2;
        this.GetComponent<Text>().text = "Trait Price (" + sum1 + ") + Prof Price (" + sum2 + ") = " + sum;
    }
}
