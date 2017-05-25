## Stuart's challenge

Given a file with 100,000 words, write a program that will 

* group words that are anagrams of each other into sets
* find the set with the most words and the longest length

Presumably the last one means that if there is more than one set with the max number of words, then pick the one with the longest length.

Or it could be the other way round.

Oh - and it's got to run in < 2 seconds (presumably this will decrease as processors get faster)

Also let's assume the words are in a text file with one word per line - for example https://raw.githubusercontent.com/dwyl/english-words/master/words.txt

### Update
Actually just used a dictionary keyed by alphabetically sorted word, and kept running reference to the 'winning' set of anagrams.

Takes < 1.3 seconds with 354985 words (i3 CPU).

### Design

try to do fastest thing first, so build a kind of multi-level tree.

1st level = word length
2nd level = quick count of each letter

which means 

* create 26 buckets initially zero
* enumerate the chars in the string
* increment bucket[char]
* scoop up the non-zero bucket indices and counts

eg

	"books" -> {b, 1}{k, 1}{o, 2}{s, 1}

should be faster than sorting. Maybe just turn into a big number
