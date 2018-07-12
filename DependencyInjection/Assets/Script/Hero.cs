using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero:MonoBehaviour {

    AllWeapons allWeapons;
    AllCharacters allCharacters;

    public AAttack aattack;
    public AHitted ahitted;
    public AMove amove;

    //之後再用ScriptableObeject作記錄
    public int CharacterID = 0;
    public int WeaponTypeID = 0;
    public int MoveTypeID = 0;
    //
    public GameObject Hand;
    GameObject WeaponOnHand;

    AllWeapons.WeaponsItem ChosedWeapon;
    AllCharacters.CharactersItem ChosedCharacter;

    public string characterName;
    public int hp;
    public float atkPower;
    public string occupation;

    private void Start() {
        GetCharacterInfo();
        ChoseAttackType();
        GetWeapon();
        ChoseMoveType();
        ahitted = gameObject.AddComponent<Hitted1>();
        }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Attack();
            }
        if(Input.GetKeyDown(KeyCode.Z)) {
            GetCharacterInfo();
            ChoseAttackType();
            GetWeapon();
            print("角色狀態刷新");
            }
        }


    void GetCharacterInfo() {
        allCharacters = Resources.Load("CharacterSO/Characters") as AllCharacters;
        ChosedCharacter = allCharacters.Characters[CharacterID];

        characterName = ChosedCharacter.CharacterName;
        hp = int.Parse(ChosedCharacter.Hp);
        atkPower = float.Parse(ChosedCharacter.AtkPower);
        occupation = ChosedCharacter.Occupation;
        }

    void ChoseAttackType() {
        allWeapons = Resources.Load("WeaponSO/Weapons") as AllWeapons;
        ChosedWeapon = allWeapons.Weapons[WeaponTypeID];
        aattack = gameObject.AddComponent<Attack2>();
        }

    void GetWeapon() {
        for(int i = 0;i < Hand.transform.GetChild(0).childCount;i++) {
            Hand.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
        WeaponOnHand = Hand.transform.GetChild(0).GetChild(int.Parse(ChosedWeapon.ID)).gameObject;
        WeaponOnHand.SetActive(true);
        }

    void ChoseMoveType() {
        switch(MoveTypeID) {
            case 1:
            amove = gameObject.AddComponent<Move2>();
            amove.GetParam(5);
            break;
            case 2:
            amove = gameObject.AddComponent<Move3>();
            amove.GetParam(5);
            break;
            default:
            amove = gameObject.AddComponent<Move1>();
            break;
            }
        }

    public void Attack() {
        aattack.GetParam(WeaponOnHand,ChosedWeapon.Name,float.Parse(ChosedWeapon.damage),float.Parse(ChosedWeapon.range),(ChosedWeapon.elementType));
        WeaponOnHand.GetComponent<Collider>().enabled = true;
        }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Weapon"&&other.transform.root!=transform) {
            ahitted.GetParam(other.transform.root.gameObject,other.transform.root.GetComponent<Hero>().aattack);
            hp -= (int)other.transform.root.GetComponent<Hero>().aattack._damage;
            }
        }

    }//End
