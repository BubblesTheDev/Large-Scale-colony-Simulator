using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "World Assets/Item/Create New Item")]
public class itemScriptableObj : ScriptableObject
{
    [Header("Base Item Stats")]
    public Texture2D itemTexture;
    public itemType type;
    public itemQuality quality;
    public int maxStack;
    public int maxHp;
    public bool requiresConnection;
    ////Deterioration Tags

    //For any weaponry or magic
    public damageType dmgType;
    public float damagePerSecond;
    public float attackCooldown;
    public float manaPerCast;
    public float hitChance;
    public float projectileSpeed;
    public float armorPenetration;


    //For anything armor/clothing
    public equipablePlaces canEquipTo;
    public float bluntAbsorbtion, slashingAbsorbtion, peircingAbsorbtion, forceAbsorbtion, heatAbsorbtion, coldAbsorbtion;
    public float moveSpeedPenalty;
    ////List of base stat increases or decreases


}

[CustomEditor(typeof(itemScriptableObj))]
public class itemScriptableObjEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        itemScriptableObj script = (itemScriptableObj)target;

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        
        GUILayout.Label("General Statistics",EditorStyles.boldLabel);
        script.type = (itemType)EditorGUILayout.EnumPopup("Item Type", script.type);
        if(script.type == itemType.magicWeapon || script.type == itemType.meleeWeapon || script.type == itemType.rangedWeapon || script.type == itemType.utility || script.type == itemType.armor || script.type == itemType.craftable)
        {
            script.quality = (itemQuality)EditorGUILayout.EnumPopup("Item Quality", script.quality);
        }
        script.requiresConnection = EditorGUILayout.Toggle("Requires Connection To Heart", script.requiresConnection);
        script.maxStack = EditorGUILayout.IntField("Maximum Stack Size", script.maxStack);
        script.maxHp = EditorGUILayout.IntField("Maximum Hp", script.maxHp);
        GUILayout.EndVertical();
        script.itemTexture = TextureField("Item Texture", script.itemTexture);
        GUILayout.EndHorizontal();




        
        if (script.type == itemType.armor)
        {
            GUILayout.Label("List Of Places This item Can Equip To", EditorStyles.boldLabel);
            script.canEquipTo = (equipablePlaces)EditorGUILayout.EnumFlagsField(script.canEquipTo);
            EditorGUILayout.Space();

            GUILayout.Label("Armor Absorbtion Values");
            script.bluntAbsorbtion = EditorGUILayout.Slider("Blunt Absorbtion Percentage", script.bluntAbsorbtion, 0f, 100f);
            script.slashingAbsorbtion = EditorGUILayout.Slider("Slashing Absorbtion Percentage", script.slashingAbsorbtion, 0f, 100f);
            script.peircingAbsorbtion = EditorGUILayout.Slider("Peircing Absorbtion Percentage", script.peircingAbsorbtion, 0f, 100f);
            script.forceAbsorbtion = EditorGUILayout.Slider("Magic Absorbtion Percentage", script.forceAbsorbtion, 0f, 100f);
            script.heatAbsorbtion = EditorGUILayout.Slider("Heat Absorbtion Percentage", script.heatAbsorbtion, 0f, 100f);

            GUILayout.Label("General Stat Changes");
            script.moveSpeedPenalty = EditorGUILayout.FloatField("Movement Speed Penalty", script.moveSpeedPenalty);
        }
        if (script.type == itemType.rangedWeapon || script.type == itemType.meleeWeapon || script.type == itemType.magicWeapon)
        {
            script.dmgType = (damageType)EditorGUILayout.EnumFlagsField("Weapon Damage Type", script.dmgType);
            script.damagePerSecond = EditorGUILayout.FloatField("Damage Per Second", script.damagePerSecond);
            script.attackCooldown = EditorGUILayout.FloatField("Attack Cooldown", script.attackCooldown);
            script.hitChance = EditorGUILayout.Slider("Hit Chance", script.hitChance, 1f, 100f);
            script.armorPenetration = EditorGUILayout.Slider("Armor Penetration", script.armorPenetration, 1f, 100f);
            if (script.type == itemType.magicWeapon) script.manaPerCast = EditorGUILayout.FloatField("Mana Per Cast", script.manaPerCast);
            if (script.type == itemType.rangedWeapon) script.projectileSpeed = EditorGUILayout.FloatField("Projectile Speed", script.projectileSpeed);
        }

    }


    private static Texture2D TextureField(string name, Texture2D texture)
    {
        GUILayout.BeginVertical();
        var style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.UpperCenter;
        style.fixedWidth = 100;
        GUILayout.Label(name, style);
        var result = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), false, GUILayout.Width(100), GUILayout.Height(100));
        GUILayout.EndVertical();
        return result;
    }
}


public enum itemType
{

    item =1<<0,
    primeItem = 1 << 1,
    rangedWeapon = 1 << 2,
    meleeWeapon = 1 << 3,
    magicWeapon = 1 << 4,
    seed = 1 << 5,
    resource = 1 << 6,
    craftable = 1 << 7,
    armor = 1 << 8,
    utility = 1 << 9,
    corpse = 1 << 10
}

public enum itemQuality
{
    ruined,
    substandard,
    adequate,
    good,
    excelent,
    perfect,
    unfathomable
}

[Flags]
public enum damageType
{
    AllPhysicalDamage = blunt | slashing | peircing,
    AllMagicDamage = force | heat | cold | psychic | necrotic | light | dark,

    blunt = 1<<0,
    slashing = 1<<1,
    peircing = 1<<2,


    force = 1<<3,
    heat = 1<<4,
    cold = 1 <<5,
    psychic = 1 << 6,
    necrotic = 1 <<7,
    light = 1 << 8,
    dark = 1 << 9
}
