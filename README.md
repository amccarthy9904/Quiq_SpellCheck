# Quiq_SpellCheck
Spell Check coding Exercise for Quick

In order to run the solution words.txt and wordsCommon.txt must be in the working directory and a file path to the input file must be specified as a command line argument. 

SOLUTION HIGHLIGHTS
	My spell checker uses a HashTable to store the dictionary for quick lookups. The HashTable consists of <string, bool> Key
	/Value pairs. The string is the word and the bool indicates if the word is common. To decide what words are common I 
	found a smaller dictionary of ~100,000 words online and stored these words in wordsCommon.txt. This smaller subset of 
	words represents more commonly used words in the English Vernacular. I made a HashTable for this file as well and 
	changed all values for all common keys between the two Hashtables to true.	This boolean is used when suggesting words 
	as words in the HashTable with a true value will be selected before words with a false vale.

	My solution uses Levenshtein Distance to determine which word to suggest when it encounters an incorrectly spelled word. 
	Levenshtein Distance is a metric for determining the similarity of strings. It is calculated by finding the number of 
	transformations (insertions, deletions, or substitutions) required to change one string to another. My solution finds 
	all words in the dictionary whose Levenshtein Distance from the misspelled word is less than 4. From this set of 
	suggestions my solution first searches for the suggestion with the lowest Levenshtein Distance that has also been 
	labeled as a common word. If no common word is found then it suggests the first word in the suggestion set that has the 
	minimum Levenshtein Distance. If there are no suggestions with a Levenshtein Distance of less than 4 then my solution 
	classifies the word as incorrect.

ASSUMPTIONS
	For this solution I assumed that the word in the dictionary with the lowest Levenshtein Distance is the best to suggest. 
	However often there are multiple words that are tied for the lowest Levenshtein Distance and I had to classify every 
	word as common or not in order to provide better suggestions.

If you have any questions send me an email at amccarthy9904@gmail.com