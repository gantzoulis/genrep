using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ruleset
{
    public class ClassMechanics
    {
        public RulesetGlossary ruleset = new RulesetGlossary();


        #region Ability, Attacks and Defence related Methods
        public static int GetBaseDeflection(int agilityScore,  int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();
            
            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseDeflection = ruleset.baseDeflectionScore;
            int perLevel = ruleset.DeflectionPerLvl;

            int fromLevel = charLevel * perLevel;
            fromPrimaryAbility = ReturnAbilityModifier(agilityScore);
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseDeflection;
            ruleset = null;
            return retVal;
        }

        public static int GetBaseWill (int intellectScore, int presenceScore, int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();

            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseWill = ruleset.baseWillScore;
            int perLevel = ruleset.WillPerLvl;

            int fromLevel = charLevel * perLevel;
            fromPrimaryAbility = ReturnAbilityModifier(intellectScore);
            fromSecondaryAbility = ReturnAbilityModifier(presenceScore);
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseWill;
            ruleset = null;
            return retVal;
        }

        public static int GetBaseFort(int mightScore, int enduranceScore, int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();

            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseFort = ruleset.baseFortitudeScore;
            int perLevel = ruleset.FortitudePerLvl;

            int fromLevel = charLevel * perLevel;
            fromPrimaryAbility = ReturnAbilityModifier(mightScore);
            fromSecondaryAbility = ReturnAbilityModifier(enduranceScore);
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseFort;
            ruleset = null;
            return retVal;
        }

        public static int GetBaseReflex(int agilityScore, int perceptionScore, int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();

            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseReflex = ruleset.baseReflexScore;
            int perLevel = ruleset.ReflexPerLvl;

            int fromLevel = charLevel * perLevel;
            fromPrimaryAbility = ReturnAbilityModifier(agilityScore);
            fromSecondaryAbility = ReturnAbilityModifier(perceptionScore);
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseReflex;
            ruleset = null;
            return retVal;
        }
        public static int GetBaseAttackScore(int perceptionScore, int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();

            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseAttack = ruleset.baseAttackScore;
            int perLevel = ruleset.attackGainPerLevel;
            int fromLevel = charLevel * perLevel;
            fromPrimaryAbility = ReturnAbilityModifier(perceptionScore);
            
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseAttack;
            ruleset = null;
            return retVal;
        }

        public static int GetBaseAdvantageScore(int perceptionScore, int agilityScore, int charLevel)
        {
            RulesetGlossary ruleset = new RulesetGlossary();

            int retVal = 0;
            int fromPrimaryAbility = 0;
            int fromSecondaryAbility = 0;
            int baseAdvantage = ruleset.baseAdvantageScore;
            int perLevel = ruleset.advantageGainPerLevel;
            int fromLevel = Mathf.RoundToInt((charLevel * perLevel)/2);
            fromPrimaryAbility = ReturnAbilityModifier(perceptionScore);
            fromSecondaryAbility = ReturnAbilityModifier(agilityScore);
            retVal = fromLevel + fromPrimaryAbility + fromSecondaryAbility + baseAdvantage;
            ruleset = null;
            return retVal;
        }

        public static int ReturnAbilityModifier(int abilityScore)
        {
            RulesetGlossary RG = new RulesetGlossary();
            int abilityPoints;
            int retVal = 0;
            if (abilityScore > 10)
            {
                abilityPoints = abilityScore - 10;
                retVal = abilityPoints * RG.abilityPerPointPlus;
            }
            else if (abilityScore < 10)
            {
                abilityPoints = 10 - abilityScore;
                retVal = abilityPoints * RG.abilityPerPointMinus;
                retVal = -retVal;
            }
            RG = null;
            return retVal;
        }
        #endregion


        #region XP and Level Related Methods
        public static int GetCurrentLevel(int currentEXP)
        {
            var XPList = GameMaster.Instance.rulesetExperienceLevels.expTable;
            int retVal = 0;
            for (int i = 0; i < XPList.Count; i++)
            {
                if (XPList[i].expNeeded > currentEXP)
                {
                    retVal = XPList[i - 1].levelIndex;
                    break;
                }
            }
            return retVal;
        }

        public static int GetXP(int level)
        {
            var XPList = GameMaster.Instance.rulesetExperienceLevels.expTable;
            int retVal = 0;
            retVal = XPList[level - 1].expNeeded;
            return retVal;
        }

        public static int GetXPtoLevelUp(int currentXP)
        {
            var XPList = GameMaster.Instance.rulesetExperienceLevels.expTable;

            int currentLevel = GetCurrentLevel(currentXP);
            int xpNeededToLevel = XPList[currentLevel].expNeeded - currentXP;
            return xpNeededToLevel;
        }

        #endregion

        #region Ability Scores Rolls
        public static int RollAbilityScore()
        {
            int d6Roll;
            int[] rolls = new int[4];
            int totalScore = 0;

            for (int i = 0; i < 4; i++)
            {
                d6Roll = Random.Range(0, 7);
                rolls[i] = d6Roll;
            }

            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] != rolls.Min())
                {
                    totalScore += rolls[i];
                }
            }

            return totalScore;
        }
        #endregion
    }
}


