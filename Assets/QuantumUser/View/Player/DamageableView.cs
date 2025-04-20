using System.Collections;
using System.Collections.Generic;
using Photon.Deterministic;
using Quantum;
using UnityEngine;
using UnityEngine.UI;

public class DamageableView : QuantumEntityViewComponent
{
    [SerializeField] private Image healthImage;

    public override void OnActivate(Frame frame)
    {
        base.OnActivate(frame);
        QuantumEvent.Subscribe<EventOnDamageHit>(this, OnDamageHit);
    }

    private void OnDamageHit(EventOnDamageHit callback)
    {
        if(EntityRef != callback.entityRef)
            return;
        
        StartCoroutine(UpdateHealthBar(callback.maxHealth, callback.currentHealth));
    }

    private IEnumerator UpdateHealthBar(FP callbackMaxHealth, FP callbackCurrentHealth)
    {
        float fill = (callbackCurrentHealth / callbackMaxHealth).AsFloat;
        while (Mathf.Approximately(fill, healthImage.fillAmount) == false)
        {
            healthImage.fillAmount = Mathf.Lerp(fill, healthImage.fillAmount, 0.1f);
            yield return null;
        }
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        QuantumEvent.UnsubscribeListener(this);
    }
}
