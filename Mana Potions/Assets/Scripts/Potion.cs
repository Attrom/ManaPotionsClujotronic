using System;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Color color;
    private Effect effect;


    public Color GetColor()
    {
        return this.color;
    }

    public Effect GetEffect()
    {
        return this.effect;
    }

    private void CalculateEffect()
    {
        short target = (short)Math.Floor(this.color.r * 6);
        if (this.color.r == 1)
        {
            target -= 1;
        }

        short side = (short)Math.Floor(this.color.g * 8);        
        if (this.color.g == 1)
        {
            side -= 1;
        }
        side = (short)(side % 2);

        short type = (short)Math.Floor(this.color.b * 5);
        if (this.color.b == 1)
        {
            type -= 1;
        }

        short effectCode = (short)(type * 12 - 1 + (target + 1) * (side + 1));

        this.effect = new Effect();

        this.effect.effectName = (Effect.Effects)effectCode;
        this.effect.redComponent = (Effect.Target)target;
        this.effect.greenComponent = (Effect.Side)side;
        this.effect.blueComponent = (Effect.Type)type;
    }

    internal void Init(Color color)
    {
        this.color = color;
        this.CalculateEffect();
    }

    private void Start()
    {
        this.CalculateEffect();
    }


    //Locks access to special effect potions until the player loses smell sense
    public bool IsDrinkable()
    {
        if (this.effect.blueComponent == Effect.Type.Special)
        {
            if (!EffectsManager.Instance.HasEffect(Effect.Effects.SmellLess))
            {
                return false;
            }
        }

        return true;
    }
}
