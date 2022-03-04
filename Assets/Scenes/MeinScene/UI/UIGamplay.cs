using UnityEngine;
using UnityEngine.UI;

public class UIGamplay : MonoBehaviour
{
    public StarshipController starshipController;
    public Text coordinatesTextInfo;
    public Text angleTextInfo;
    public Text instantaneousSpeedTextInfo;
    public Text LaserChargesTextInfo;
    public Text RechargeTextInfo;

    void Update()
    {
        if (starshipController != null)
        {
            coordinatesTextInfo.text = "—oordinates " + starshipController.Get—oordinates();
            angleTextInfo.text = "Angle " + -(int)starshipController.GetAngle();
            instantaneousSpeedTextInfo.text = "Speed " + starshipController.GetSpeed();
            LaserChargesTextInfo.text = "Charges " + starshipController.GetCharges();
            RechargeTextInfo.text = "Recharge " + starshipController.GetRecharge() + "%";
        }            
    }
}
