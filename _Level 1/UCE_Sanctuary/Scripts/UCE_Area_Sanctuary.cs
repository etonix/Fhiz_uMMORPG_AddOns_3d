// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using Mirror;
using UnityEngine;

// SIMPLE SANCTUARY

[RequireComponent(typeof(BoxCollider))]
public class UCE_Area_Sanctuary : NetworkBehaviour
{
    [Header("-=-=- UCE SANCTUARY -=-=-")]
    [Tooltip("One click deactivation")]
    public bool isActive = true;

    [Tooltip("[Optional] Seconds spent offline to recover 1 Health")]
    public int SecondsPerHealth = 60;

    [Tooltip("[Optional] Seconds spent offline to recover 1 Mana")]
    public int SecondsPerMana = 60;

    [Tooltip("[Optional] Seconds spent offline to gain 1 Experience")]
    public int SecondsPerExp = 60;

    [Tooltip("[Optional] Seconds spent offline to gain 1 Skill Experience")]
    public int SecondsPerSkillExp = 60;

    [Tooltip("[Optional] Seconds spent offline to gain 1 Gold")]
    public int SecondsPerGold = 60;

    [Tooltip("[Optional] Seconds spent offline to gain 1 Coin")]
    public int SecondsPerCoins = 60;

    [Tooltip("[Optional] Max. Exp gain cap offline per session (set 0 to disable)")]
    public int MaxExp = 5;

    [Tooltip("[Optional] Max. Skill Exp gain cap offline per session (set 0 to disable)")]
    public int MaxSkillExp = 5;

    [Tooltip("[Optional] Max. Gold gain cap offline per session (set 0 to disable)")]
    public int MaxGold = 5;

    [Tooltip("[Optional] Max. Coins gain cap offline per session (set 0 to disable)")]
    public int MaxCoins = 5;

#if _iMMOHONORSHOP
    public UCE_Sanctuary_HonorCurrency[] honorCurrencies;
#endif

    [Header("-=-=- Messages -=-=-")]
    public string messageOnEnter = "You just entered a Sanctuary!";

    public string MSG_HEALTH = "[Sanctuary] Recovered health while being offline: ";
    public string MSG_MANA = "[Sanctuary] Recovered mana while being offline: ";
    public string MSG_STAMINA = "[Sanctuary] Recovered stamina while being offline: ";
    public string MSG_EXP = "[Sanctuary] Gained experience while being offline: ";
    public string MSG_SKILLEXP = "[Sanctuary] Gained skill experience while being offline: ";
    public string MSG_GOLD = "[Sanctuary] Earned gold while being offline: ";
    public string MSG_COINS = "[Sanctuary] Earned Coins while being offline: ";
#if _iMMOHONORSHOP
    public string MSG_CURRENCY = "[Sanctuary] Earned while being offline: ";
#endif

    // -----------------------------------------------------------------------------------
    // OnTriggerEnter
    // -----------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider co)
    {
        Player player = co.GetComponentInParent<Player>();
        if (player && isActive)
        {
            player.UCE_RecoverOverTime(this);
#if _iMMOTOOLS
            player.UCE_ShowPopup(messageOnEnter);
#endif
        }
    }
}

// -----------------------------------------------------------------------------------