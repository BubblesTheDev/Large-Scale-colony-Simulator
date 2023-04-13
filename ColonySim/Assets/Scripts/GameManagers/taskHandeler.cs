using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskHandeler : MonoBehaviour
{
    public List<task> combatTasks = new List<task>();
    public List<task> creationTasks = new List<task>();
    public List<task> organicTasks = new List<task>();
    public List<task> craftingTasks = new List<task>();
    public List<task> academicTasks = new List<task>();


    public void addTask(taskSkill skillRequired, Vector2Int[] cellIdsOfTask, int minimumSkillRequired, int workToComplete, bool canBeLeftWithoutCompletion, bool requiresSpectral)
    {
        task tempTask = new task(skillRequired, cellIdsOfTask, minimumSkillRequired, workToComplete, canBeLeftWithoutCompletion, requiresSpectral);

        switch (tempTask.skillRequired)
        {
            case taskSkill.shooting:
                combatTasks.Add(tempTask);
                break;
            case taskSkill.fighting:
                combatTasks.Add(tempTask);
                break;
            case taskSkill.magics:
                combatTasks.Add(tempTask);
                break;


            case taskSkill.creation:
                creationTasks.Add(tempTask);
                break;
            case taskSkill.destruction:
                creationTasks.Add(tempTask);
                break;
            case taskSkill.excavation:
                creationTasks.Add(tempTask);
                break;


            case taskSkill.botany:
                organicTasks.Add(tempTask);
                break;
            case taskSkill.preparation:
                organicTasks.Add(tempTask);
                break;
            case taskSkill.magicraft:
                organicTasks.Add(tempTask);
                break;


            case taskSkill.artifice:
                craftingTasks.Add(tempTask);
                break;
            case taskSkill.fabrication:
                craftingTasks.Add(tempTask);
                break;


            case taskSkill.medical:
                academicTasks.Add(tempTask);
                break;
            case taskSkill.transmutation:
                academicTasks.Add(tempTask);
                break;
            case taskSkill.investigation:
                academicTasks.Add(tempTask);
                break;
        }

    }

}


[System.Serializable]
public class task
{
    public taskSkill skillRequired;
    public Vector2Int[] cellIdsOfTask;
    public pawn taskReserved;
    public taskReward reward;
    
    public int minimumSkillRequired;
    public int workToComplete;
    public int[] workLeft;
    public bool canBeLeftWithoutCompletion;
    public bool requiresSpectral;
    public itemScriptableObj itemRequired;
    public int requiredItemAmmount;
    //Building its done at

    public task(taskSkill skillToDo, Vector2Int[] cellIds, int minSkillReq, int workTofinish, bool canBeLeftUnfinished, bool requiresSpectralRealm)
    {
        skillRequired = skillToDo;
        cellIdsOfTask = cellIds;
        minimumSkillRequired = minSkillReq;
        workToComplete = workTofinish;
        for (int i = 0; i < workLeft.Length; i++)
        {
            workLeft[i] = workTofinish;
        }
        canBeLeftWithoutCompletion = canBeLeftUnfinished;
        requiresSpectral = requiresSpectralRealm;
    }

    public void doTask()
    {
        
    }

}

[System.Serializable]
public class taskReward{
    public itemScriptableObj itemReward;
    public int ammountOfItemsToGive;
    public itemQuality qualityOfReward;

    public taskReward(itemScriptableObj itemReward, int ammountOfItems, itemQuality qualityOfItem)
    {
        this.itemReward = itemReward;
        this.ammountOfItemsToGive = ammountOfItems;
        this.qualityOfReward = qualityOfItem;
    }
}

public enum taskSkill
{
    //Combat
    shooting,
    fighting,
    magics,

    //Creation and destruction
    creation,
    destruction,
    excavation,
    
    //Organic Manipulation
    botany,
    preparation,
    magicraft,
    
    //Non organic crafting
    artifice,
    fabrication,

    //Academics
    medical,
    transmutation,
    investigation

}
