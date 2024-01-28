targetScope = 'subscription'

@minLength(1)
@maxLength(64)
@description('Name of the environment eg. dev, prod')
param environmentName string = 'dev'

// tt
@minLength(1)
@description('Location for all resources')
param location string

param resourceGroupName string = 'rg-mm-manual'

var abbrs = loadJsonContent('abbreviations.json')
//var resourceToken = toLower(uniqueString(subscription().id, environmentName, location))
var tags = { environment: environmentName }

// Organize resources in a resource group
resource rg 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: !empty(resourceGroupName) ? resourceGroupName : '${abbrs.resourcesResourceGroups}${environmentName}'
  location: location
  tags: tags
}
