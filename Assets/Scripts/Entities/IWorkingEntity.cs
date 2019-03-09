using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkingEntity: ISelectionableEntity
{
    void resumeWork(Player player);

    void stopWork(Player player);

    void finishWork(Player player);
}
