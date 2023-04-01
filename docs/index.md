# How many calls will my API support?
This is a question that has bugged IT professionals for a while. Of course, the two main variables that 
This is a study to orientate the software architect / infrastructure expert in the solution of these classical cloud performance problems: 
- _what pricing tier is needed to sustain a certain number of API calls?_
- _should I use a single powerful service, or more smaller services?_
- _is Linux better than Windows_?
- _What cloud provider is more cost-effective_?

This pages focuses on these technologies:
- Azure Functions on App Service Plans (both Linux and Windows)
- .NET workloads

## What did we find?
Nothing that we did not expect: more expensive Azure Functions guaranteed better performance. However, how better and how expensive suprised us in some cases.

## How did we measure the API performance?
This very repo hosts (in the /src) folder a .NET 7 isolated process project. 
This is the architecture we used for tests. To summarise, the calls

## What hardware did we test?
We tested all of the Azure Function production-ready tiers available in West Europe (S\*, P\*V2, P\*V3) in both OSs available (Linux and Windows)
The client was a

#What load tool did you use?
We used Vegeta

#What is better, Linux or Windows?
They are very similar. However, Linux is cheaper.

