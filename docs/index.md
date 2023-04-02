# How many requests will my API support in production?
This is a question that has bugged IT professionals ever since.  
Two main variables (obviously) determine the answer:
- what hardware you'll be using
- the scalability of the software you'll be writing

Whereas the second factor is difficult to determine, you can work on the first, and try to know what are the upper limits of the first.

This site would like to give you some data to help taking these decisions: 
- _what pricing tier is needed to sustain a certain number of API calls?_
- _should I use a single powerful service, or more smaller services?_
- _is Linux better than Windows_?
- _what cloud provider is more cost-effective_?

This particular page focuses on these technologies:
- Azure Functions on App Service Plans (both Linux and Windows)
- .NET workloads

## What did we find with Azure Functions?
Nothing that we did not expect: more expensive Azure Functions guaranteed better performance.  
However, how better and how expensive suprised us in some cases.

## How we measured Azure Functions
This very repo hosts (in the /src folder) a .NET 7 isolated process project. 
That project uses three types of APIs to determine the upper limits of Azure Functions
- APIs that only handle in memory objects, without dependencies on other resources (the basic)
- APIs that on purpose waste some time before returing an answer
- (more realistic) APIs that read and write data from a Redis Cache and a SQL DB \[the result parsing of these is a WIP]

## What can you do with these results?
Even though your software and dependencies can be _very_ different from those we tested here, this exercise can give you an idea of the upper limit you will not be able to exceed even if your software is perfect. It's already something, isn't it? 

## The infrastructure / architecture we tested
We tested all of the Azure Function production-ready tiers available in West Europe (S\*, P\*V2, P\*V3) in both OSs available (Linux and Windows).
The client machine generating the load was a (costly) Ubuntu 22.04 VM.
The Azure functions were in the same virtual network of the VM via private endpoints.
Also the Azure Redis Cache and the SQL Database were in the same network, on different subnets. This is an architectural drawing of the solution: ![Architecture of the APIsault solution on Azure](/docs/assets/images/Architecture_ApiSault_Functions_on_Azure.drawio.png)

## The load tools we used
We used <a href="https://github.com/tsenart/vegeta">Vegeta</a>, a neat tool which can easily generate a big amount of concurrent calls. We used the version 12.8.3 as the latest did not seem to have been built for ARM64.

## What is better, Linux or Windows?
They are very similar, except for the P2 tier, where Windows is much better. However, Linux is cheaper. If your application is stateless, more Linux resources can give you better performance at lower prices.

## Now, some results

### "S" tiers
In this test, we did not use B tiers of app functions, as they are not reported as production ready by Microsoft. The "S1" tier is very basic.

## Summary: more cost-effectively tiers

