### Continents-finder

Continents finder algorithm, able to discover a number of islands/continents lying on a 2D map.

#### Prerequisites

Linux/OSX:
 - Mono/netcore 2.*
 - F# 4.1^
 
Windows:
 - .NET/netcore 2.*
 - F# 4.1^
 
 #### How to run
 
Linux/OSX:
```bash
fsharpi continents.fsx
```
 
Windows:
```bash
fsi continents.fsx
```
#### Time complexity of the algorithm
Time complexity of this algorithm is `O(mn)` where _m_ stands for count of rows and _n_ stands of count of columns

#### Possible improvements
I think we can get few improvements by using _BFS_/_DFS_/_Disjoint Sets_ approaches. This kind of algorithms suits better immutable environments rather than the holy of immutable lambda environment such as _F#_.

#### Where are my tests, what the heck man?
In the true life, I don't write such kind of code, and all my code is tested in general. For example, [this old project](https://github.com/vba/NBlast) reflects in better way my professional approaches in terms of software design, development and testing. I have more recent projects but made in Scala if you want to have a look at.
