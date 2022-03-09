using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystemGenerator : MonoBehaviour
{
    public Rule[] rules;
    public string rootSentence;
    [Range(0,10)]
    public int iterationLimite = 1;

    public string GenerateSentence(string word = null)
    {
        if(word == null)
            word = rootSentence;

        return GrowRecursive(word);
    }

    public string GrowRecursive(string word, int iterationIndex = 0)
    {
        if (iterationIndex >= iterationLimite)
            return word;

        StringBuilder newWord = new StringBuilder();

        foreach (char c in word)
        {
            newWord.Append(c);
            ProcessRulesRecusively(newWord, c, iterationIndex);
        }

        return newWord.ToString();
    }

    private void ProcessRulesRecusively(StringBuilder newWord, char c, int iterationIndex)
    {
        foreach(var rule in rules)
        {
            if(rule.letter == c.ToString())
            {
                newWord.Append(GrowRecursive(rule.GetResult(), iterationIndex + 1));
            }
        }
    }
}
