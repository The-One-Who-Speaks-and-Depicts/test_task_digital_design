using System;
using System.Collections.Generic;
using System.Linq;

namespace freqDictCountMaker
{
    public class freqDictCountMaker
    {
    	private Dictionary<string,int> freqDictMake (List<string> words)
    	{
    		Dictionary<string, int> words_with_frequencies = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
            	if (words_with_frequencies.ContainsKey(words[i]))
            	{
            		words_with_frequencies[words[i]]++;
            	}
            	else
            	{
            		words_with_frequencies[words[i]] = 1;
            	}
            }
            var words_with_frequencies_list = words_with_frequencies.ToList();
            words_with_frequencies_list.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            words_with_frequencies_list.Reverse();
            var finalList = words_with_frequencies_list.ToDictionary(keyItem => keyItem.Key, valueItem => valueItem.Value);
            return finalList;
    	}
    }
}
