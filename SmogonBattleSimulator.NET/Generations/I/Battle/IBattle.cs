﻿using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public interface IBattle
    {
        IIndexedSet<ITrainer> Trainers { get; }
    }
}