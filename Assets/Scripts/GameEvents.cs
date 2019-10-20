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
public class DisableCharacter : UnityEvent { }

[Serializable]
public class PowerupTaken : UnityEvent { }

[Serializable]
public class SpawnPowerup : UnityEvent<Vector3> { }

[Serializable]
public class PlayerDataUpdated : UnityEvent<Player> { }

[Serializable]
public class LivesUpdated : UnityEvent<int> { }

[Serializable]
public class UpdateUi : UnityEvent<Player> { }

[Serializable]
public class UpdateLivesUi : UnityEvent<int> { }