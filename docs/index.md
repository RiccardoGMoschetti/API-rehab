# Do you know the limits of your APIs?
This is a study to orientate the software architect / infrastructure expert in the solution of these classical cloud performance problems: 
- _what pricing tier should I use to serve a certain number of calls?_
- _should I use a single powerful service, or more smaller services?_
- _is Linux better than Windows_?

This study focuses (so far) on:
- Azure Functions (both Linux and Windows)
- .NET workloads

## What did we find?
Nothing that we did not expect: more expensive Azure tiers guarantee better performance. However, the performance levels of some services surprised us because they were much better (and, sometimes, much worse) than we thought.

## How did we measure the API performance?
This very repo hosts (in the /src) folder a .NET 7 isolated process project. This was deployed to all of the Azure Function production ready tiers (S\*, P\*V2, P\*V3)

