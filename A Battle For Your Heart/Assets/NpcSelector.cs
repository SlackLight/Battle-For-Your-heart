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
    public enum mouthSelect { neutralClose, surprisedOpen, negativeClose,negativeOpen,positiveClose,positiveOpen};

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
    private apControlParam skinTone;
    private apControlParam frontHand;
    private apControlParam backHand;
    private apControlParam legStyle;
    private apControlParam hair;
    private apControlParam eyes;
    private apControlParam skirt;

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
        SetMouth();
    }

    void SetNPC()
    {
        //set Ai
        if (characterSet == characterSelect.Ai)
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
        else if (characterSet == characterSelect.Shou)
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
        else if (characterSet == characterSelect.Himeko)
        {
            ap.SetControlParamInt(head, -1);
            ap.SetControlParamInt(clubBand, 1);
            ap.SetControlParamInt(skinTone, 1);
            ap.SetControlParamInt(frontHand, -2);
            ap.SetControlParamInt(backHand, 4);
            ap.SetControlParamInt(legStyle, 1);
            ap.SetControlParamInt(skirt, 0);
        }
        //set extras
        else
        {
            SetExtras();
        }
    }

    void SetHands(int toneModifier)
    {
        /////////////
        //set hands//
        /////////////

        if (extraHandPose == handPoseSelect.relaxRelax)
        {
            ap.SetControlParamInt(frontHand, -5 + toneModifier);
            ap.SetControlParamInt(backHand, -6 + toneModifier);
        }
        else if (extraHandPose == handPoseSelect.relaxFist)
        {
            ap.SetControlParamInt(frontHand, -5 + toneModifier);
            if (toneModifier>1)
                ap.SetControlParamInt(backHand, -2 + toneModifier +1);
            else
                ap.SetControlParamInt(backHand, -2 + toneModifier);
        }
        else if (extraHandPose == handPoseSelect.fistRelax)
        {
            ap.SetControlParamInt(frontHand, 0 + toneModifier);
            ap.SetControlParamInt(backHand, -6 + toneModifier);
        }
        else
        {
            ap.SetControlParamInt(frontHand, 0 + toneModifier);
            if (toneModifier > 1)
                ap.SetControlParamInt(backHand, -2 + toneModifier + 1);
            else
                ap.SetControlParamInt(backHand, -2 + toneModifier);
        }
    }

    void SetExtras()
    {
        ////////////////////
        //set skin & hands//
        ////////////////////

        if (extraSkinTone == skinToneSelect.T1)
        {
            ap.SetControlParamInt(head, 1);
            ap.SetControlParamInt(skinTone, -3);
            SetHands(0);
        }
        else if (extraSkinTone == skinToneSelect.T2)
        {
            ap.SetControlParamInt(head, 2);
            ap.SetControlParamInt(skinTone, -2);
            SetHands(1);
        }
        else if (extraSkinTone == skinToneSelect.T3)
        {
            ap.SetControlParamInt(head, 3);
            ap.SetControlParamInt(skinTone, -1);
            SetHands(2);
        }
        else if (extraSkinTone == skinToneSelect.T4)
        {
            ap.SetControlParamInt(head, 4);
            ap.SetControlParamInt(skinTone, 1);
            SetHands(3);
        }

        ////////////
        //set eyes//
        ////////////

        if (extraEyes == eyeSetSelect.closed)
            ap.SetControlParamInt(eyes, 3);
        else if (extraEyes == eyeSetSelect.sleepy)
            ap.SetControlParamInt(eyes, 2);
        else
            ap.SetControlParamInt(eyes, 1);
        ////////////
        //set hair//
        ////////////

        if (extraHair == hairSelect.twinTail)
            ap.SetControlParamInt(hair, 1);
        else if (extraHair == hairSelect.curlyTail)
            ap.SetControlParamInt(hair, 2);
        else if (extraHair == hairSelect.bob)
            ap.SetControlParamInt(hair, 3);
        else
            ap.SetControlParamInt(hair, 4);

        ////////////////////
        //set skirt + legs//
        ////////////////////

        if (extraStyle == styleSelect.stockingLong || extraStyle == styleSelect.stockingShort)
        {
            ap.SetControlParamInt(legStyle, 3);
            if (extraStyle == styleSelect.stockingLong)
                ap.SetControlParamInt(skirt, 1);
            else
                ap.SetControlParamInt(skirt, 0);
        }
        else
        {
            //leg skin tones
            if (extraSkinTone == skinToneSelect.T1)
                ap.SetControlParamInt(legStyle, -3);
            else if (extraSkinTone == skinToneSelect.T2)
                ap.SetControlParamInt(legStyle, -2);
            else if (extraSkinTone == skinToneSelect.T3)
                ap.SetControlParamInt(legStyle, -1);
            else if (extraSkinTone == skinToneSelect.T4)
                ap.SetControlParamInt(legStyle, 1);

            //skirt
            if (extraStyle == styleSelect.sockLong)
                ap.SetControlParamInt(skirt, 1);
            else
                ap.SetControlParamInt(skirt, 0);
        }

        ///////////////
        //set armband//
        ///////////////
        if (clubSet == clubSelect.fanClub)
            ap.SetControlParamInt(clubBand, 1);
        else
            ap.SetControlParamInt(clubBand, 0);
    }

    public void SetMouth()
    {
        if (mouthSet == mouthSelect.neutralClose)
            ap.SetControlParamInt(mouth, 0);
        else if (mouthSet == mouthSelect.surprisedOpen)
            ap.SetControlParamInt(mouth, 1);
        else if (mouthSet == mouthSelect.negativeClose)
            ap.SetControlParamInt(mouth, -3);
        else if (mouthSet == mouthSelect.negativeOpen)
            ap.SetControlParamInt(mouth, -2);
        else if (mouthSet == mouthSelect.positiveClose)
            ap.SetControlParamInt(mouth, 2);
        else if (mouthSet == mouthSelect.positiveOpen)
            ap.SetControlParamInt(mouth, 3);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp("q"))
    //    {
    //        SetNPC();
    //        SetMouth();
    //    }
    //}
}
