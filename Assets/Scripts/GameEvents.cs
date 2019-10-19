using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class CharacterDamaged : UnityEvent<float> { }

[Serializable]
public class CharacterDefeated : UnityEvent<Character> { }

[Serializable]
public class PowerupTaken : UnityEvent { }

[Serializable]
public class SpawnPowerup : UnityEvent <Vector3> { }
