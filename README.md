# WCF Service Examples
## SELF HOST WCF TCP/IP SERVICE
This is a Microsoft WCF Service based tutorial which tackles the 
**Self Hosting** with **Fluent Configuration** (done programmatically).


## PROBLEM
### cannot be processed at the receiver, due to a ContractFilter mismatch at the EndpointDispatcher
#### Solution
[here](https://stackoverflow.com/questions/15244414/contractfilter-mismatch-at-the-endpointdispatcher/15247141)

Add behaviour configuration in <endpoint address /> tag
```
  <endpoint address="" binding="webHttpBinding" bindingConfiguration="https" contract="LinkService.ILinkService" behaviorConfiguration="web"/>
```
