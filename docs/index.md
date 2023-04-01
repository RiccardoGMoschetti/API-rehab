# How many calls will my API support in production?
This is a question that has bugged IT professionals ever since.
Two main variables determine the answer:
- what hardware you'll be using
- the scalability of the software you'll be writing

Whereas the second factor is difficult to determine, you can work on the first, and try to know what are the upper limits of the first.

This site presents some pointers to orientate the architect / infrastructure expert to answer these problems: 
- _what pricing tier is needed to sustain a certain number of API calls?_
- _should I use a single powerful service, or more smaller services?_
- _is Linux better than Windows_?
- _what cloud provider is more cost-effective_?

This one page focuses on these technologies:
- Azure Functions on App Service Plans (both Linux and Windows)
- .NET workloads

## What did we find?
Nothing that we did not expect: more expensive Azure Functions guaranteed better performance. However, how better and how expensive suprised us in some cases.

## How did we measure the API performance?
This very repo hosts (in the /src folder) a .NET 7 isolated process project. 
That rroject used three main types of APIs to determine the upper limits of the infrastructure
- APIs that only handle in memory objects, without (the basic)
- APIs that on purpose waste some time before returing an answer
- (more realistic) APIs that read and write data from a Redis Cache and a SQL DB \[the result parsing of these is a WIP]

## What hardware and archtect did we test?
We tested all of the Azure Function production-ready tiers available in West Europe (S\*, P\*V2, P\*V3) in both OSs available (Linux and Windows).
The client machine generating the load was a (costly) Ubuntu 22.04 VM.
The Azure functions were in the same virtual network of the VM via private endpoints.
Also the Azure Redis Cache and the SQL Database were in the same 

#What load tool did you use?
We used <a href="https://github.com/tsenart/vegeta">Vegeta</a>, a neat tool which can easily generate a big amount of concurrent calls. We used the version 12.8.3 as the latest did not seem to have been built for ARM64.

##What is better, Linux or Windows?
They are very similar. However, Linux is cheaper.

##What were the results?

# "S" tiers
In this test, we did not use B tiers of app functions, as they are not reported as production ready by Microsoft. The "S1" tier is very basic.

##Summary: more cost-effectively tiers

##Is there a script that can help me do the tests by myself?
Yes, it is here 

