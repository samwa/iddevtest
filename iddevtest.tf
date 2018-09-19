provider "azurerm" "test" {
  
}

resource "azurerm_resource_group" "test" {
  name     = "rg-iddevtest"
  location = "Australia South East"
}

resource "azurerm_app_service_plan" "test" {
  name                = "asp-iddevtest"
  location            = "${azurerm_resource_group.test.location}"
  resource_group_name = "${azurerm_resource_group.test.name}"

  sku {
    tier = "Free"
    size = "F1"
  }
}