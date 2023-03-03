using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{

}

[Flags]
public enum equipablePlaces
{

    HeadArea = head | eyes | face,
    TorsoArea = back | chestInner | chestOuter | abdomen | waist,
    EntireRightArm = Rightshoulder | Rightarm | RightHand,
    EntireLeftArm = Leftshoulder | LeftArm | LeftHand,
    EntireRightLeg = RightLeg | RightFoot,
    EntireLeftLeg = LeftLeg | LeftFoot,

    head = 1 << 0,
    eyes = 1 << 1,
    face = 1 << 2,
    back = 1 << 3,
    chestInner = 1 << 4,
    chestOuter = 1 << 5,
    abdomen = 1 << 6,
    waist = 1 << 7,
    Rightshoulder = 1 << 8,
    Leftshoulder = 1 << 9,
    Rightarm = 1 << 10,
    LeftArm = 1 << 11,
    RightHand = 1 << 12,
    LeftHand = 1 << 13,
    RightLeg = 1 << 14,
    LeftLeg = 1 << 15,
    RightFoot = 1 << 16,
    LeftFoot = 1 << 17
}
