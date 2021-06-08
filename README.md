# BrewHelper

[![Build Status](https://dev.azure.com/BrewHelperMH/BrewHelper/_apis/build/status/BrewHelper%20test%20build?branchName=master)](https://dev.azure.com/BrewHelperMH/BrewHelper/_build/latest?definitionId=6&branchName=master)

BrewHelper aims to be an all in one solution to help the amateur home brewers with keeping track off all brewing data

## Development

BrewHelper consists 2 components the [backend](./BrewHelper/) written in .NET 5.0 and the [dashboard](./brewhelper-dashboard/) created using [react-admin](https://marmelab.com/react-admin/).

You can run BrewHelper for testing using the provided [docker-compose file](docker-compose.yml)

The [tests](./BrewHelper/BrewHelperTests/) require the development database that can be started using the [docker-compose-dev file](./Brewhelper/docker-compose-dev.yml).
