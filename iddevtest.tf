provider "azurerm" "test" {
  
}

resource "random_id" "server" {
  keepers = {
    azi_id = 1
  }

  byte_length = 8
}

resource "azurerm_resource_group" "test" {
  name     = "rg-iddevtest"
  location = "Australia South East"
}

resource "azurerm_sql_server" "test" {
  name                         = "ssr-iddevtest"
  resource_group_name          = "${azurerm_resource_group.test.name}"
  location                     = "${azurerm_resource_group.test.location}"
  version                      = "12.0"
  administrator_login          = "ssradmin"
  administrator_login_password = "Sup3rS3cr3t"
}

resource "azurerm_sql_database" "test" {
  name                = "sdb-iddevtest"
  resource_group_name = "${azurerm_resource_group.test.name}"
  location = "${azurerm_resource_group.test.location}"
  server_name = "${azurerm_sql_server.test.name}"
}

resource "azurerm_app_service_plan" "test" {
  name                = "asp-iddevtest"
  location            = "${azurerm_resource_group.test.location}"
  resource_group_name = "${azurerm_resource_group.test.name}"

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "test" {
  name                = "app-${random_id.server.hex}"
  location            = "${azurerm_resource_group.test.location}"
  resource_group_name = "${azurerm_resource_group.test.name}"
  app_service_plan_id = "${azurerm_app_service_plan.test.id}"

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }
  
  connection_string {
    name  = "Database"
    type  = "SQLServer"
    value = "Server=tcp:${azurerm_sql_server.test.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_sql_database.test.name};Persist Security Info=False;User ID=${azurerm_sql_server.test.administrator_login};Password=${azurerm_sql_server.test.administrator_login_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}

resource "azurerm_sql_firewall_rule" "test" {
  name                = "Home"
  resource_group_name = "${azurerm_resource_group.test.name}"
  server_name         = "${azurerm_sql_server.test.name}"
  start_ip_address    = "155.143.36.57"
  end_ip_address      = "155.143.36.57"
}