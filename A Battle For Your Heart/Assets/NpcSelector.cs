using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class NpcSelector : MonoBehaviour
{
    public enum characterSelect { Ai, Shou, Kana, Himeko, Extra};
    public enum skinToneSelect {T1,T2,T3,T4};
    public enum eyeSetSelect {open,sleepy,closed};
    public enum hairSelect { twinTail,curlyTail,bob,straightTail};
    public enum handPoseSelect { relaxRelax, relaxFist,fistRelax,fistFist};
    public enum styleSelect { sockShort,sockLong,stockingShort,stockingLong};
    public enum clubSelect { noClub,fanClub};
    public enum mouthSelect { negativeClose,negativeOpen,neutralClose,surprisedOpen,positiveClosed,positiveOpen};

    public characterSelect characterSet;
    public mouthSelect mouthSet;
    public skinToneSelect extraSkinTone;
    public eyeSetSelect extraEyes;
    public hairSelect extraHair;
    public handPoseSelect extraHandPose;
    public styleSelect extraStyle;
    public clubSelect clubSet;

    private apControlParam mouth;
    private apControlParam head;
    private apControlParam clubBand;
    [SerializeField]
    private apControlParam skinTone;
    private apControlParam frontHand;
    private apControlParam backHand;
    private apControlParam legStyle;
    private apControlParam hair;
    private apControlParam eyes;
    private apControlParam skirt;

    //[SerializeField]
    apPortrait ap;

    void Awake()
    {
      if (transform.childCount > 0)
        {
            ap = transform.GetChild(0).gameObject.GetComponent<apPortrait>();

            //connect the parameters
            mouth = ap.GetControlParam("MouthSet");
            head = ap.GetControlParam("HeadSet");
            clubBand = ap.GetControlParam("Club Member");
            skinTone = ap.GetControlParam("SkinTone");
            frontHand = ap.GetControlParam("FrontHandPose");
            backHand = ap.GetControlParam("BackHandPose");
            legStyle = ap.GetControlParam("LegTone/Style");
            hair = ap.GetControlParam("Extras hairSet");
            eyes = ap.GetControlParam("Extras EyeSet");
            skirt = ap.GetControlParam("SkirtStyle");
        }


        
    }
    private void Start()
    {
        SetNPC();
    }

    void SetNPC()
    {
        //set Ai
        if(characterSet == characterSelect.Ai)
        {
            ap.SetControlParamInt(head, -4);
            ap.SetControlParamInt(clubBand, 0);
            ap.SetControlParamInt(skinTone, -3);
            ap.SetControlParamInt(frontHand, -5);
            ap.SetControlParamInt(backHand, -6);
            ap.SetControlParamInt(legStyle, 2);
            ap.SetControlParamInt(skirt, 0);
        }

        //set Shou
        else if(characterSet == characterSelect.Shou)
        {
            ap.SetControlParamInt(head, -3);
            ap.SetControlParamInt(clubBand, 1);
            ap.SetControlParamInt(skinTone, 2);
            ap.SetControlParamInt(frontHand, -4);
            ap.SetControlParamInt(backHand, 5);
            ap.SetControlParamInt(legStyle, 3);
            ap.SetControlParamInt(skirt, 0);
        }
        //set kana
        else if (characterSet == characterSelect.Kana)
        {
            ap.SetControlParamInt(head, -2);
            ap.SetControlParamInt(clubBand, 1);
            ap.SetControlParamInt(skinTone, -1);
            ap.SetControlParamInt(frontHand, 4);
            ap.SetControlParamInt(backHand, 1);
            ap.SetControlParamInt(legStyle, 0);
            ap.SetControlParamInt(skirt, 1);
        }
        //set himeko
        else if(characterSet == characterSelect.Himeko)
        {
            ap.SetControlParamInt(head, -1);
            ap.SetControlParamInt(clubBand, 1);
            ap.SetControlParamInt(skinTone, 1);
            ap.SetControlParamInt(frontHand, -2);
            ap.SetControlParamInt(backHand, 2);
            ap.SetControlParamInt(legStyle, 1);
            ap.SetControlParamInt(skirt, 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp("q"))
        {
            SetNPC();
        }
    }
}
