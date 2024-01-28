targetScope = 'subscription'

@minLength(1)
@maxLength(64)
@description('Name of the environment eg. dev, prod')
param environmentName string

// tt
@minLength(1)
@description('Location for all resources')
param location string

param resourceGroupName string = ''

var abbrs = loadJsonContent('abbreviations.json')
var resourceToken = toLower(uniqueString(subscription().id, environmentName, location))
var tags = { environment: environmentName }

// Organize resources in a resource group
resource rg 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: !empty(resourceGroupName) ? resourceGroupName : '${abbrs.resourcesResourceGroups}${environmentName}'
  location: location
  tags: tags
}

module vNet 'br/mmbicepmoduleregistry.azurecr.io/virtual-network:1.0.35' = {
  name: vnet //'${uniqueString(deployment().name, 'uksouth')}-vnet'
  params: {
    name: '${abbrs.networkVirtualNetworks}-${resourceToken}'
    addressPrefixes: [ '10.0.0.0/16' ]
    location: location
    tags: tags
  }
}
