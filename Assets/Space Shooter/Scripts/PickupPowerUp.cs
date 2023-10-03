using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    public PowerUp PowerUp;
    // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            PowerManager.instance.AddPower(PowerUp);
            Destroy(gameObject);
        }
    }
}
