provider "azurerm" "test" {
  
}

resource "azurerm_resource_group" "test" {
  name     = "rg-iddevtest"
  location = "Australia South East"
}