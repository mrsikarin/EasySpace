using UnityEngine;

public class PowerUp : ScriptableObject
{
   public Sprite Icon;
   public float Duration = 1f;
   
   public virtual void Active(){
   }
   
   public virtual void Deactive(){

   }


}
