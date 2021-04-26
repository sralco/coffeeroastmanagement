<h3>Coffee Roast Management</h3>

# About the project
Coffee Roast Management is a simple self-hosting platform for home coffee roasters. 
You can manage green bean stock as well as add and analyze roast logs.

This is the initial release with a basic set of features. However, there are a lot of features planned for future releases.

# Key features

- Manage contacts for green bean providers
- Green bean stock management
- Roast management 
  - Add roast profile (artisan json format)
  - Display roast profile
  - Add picture of the roast
- Runs on Raspberry Pi 2 (🎉)
- No secure connections (https) (😮)

# How to try it

The easiest way to try the program is to use the [Docker images](https://hub.docker.com/repository/docker/mb221/coffeeroastmanagement) provided on [docker.com](docker.com).

Copy the following contents in a file called `Dockerfile` and execute `docker-compose up`.
The coffee roast management application is available at [http://localhost:5000](http://localhost:5000). It should also be available at a non-loopback IP address.

```Dockerfile
version: '3'

services:
  server:
    image: mb221/coffeeroastmanagement:0.1.0
    depends_on:
      - postgres
    ports:
      - "5000:5000"
    environment:
      - CONNECTION_STRING=Host=postgres;Port=5432;Database=crm;Username=crm;Password=crm;
  postgres:
    image: postgres:13.2
    ports:
      - "5432:5432"
    container_name: postgres
    volumes:
      - pgdata:/var/lib/postgresql/data
      - pgconf:/etc/postgresql
      - pglog:/var/log/postgresql
    environment:
      - POSTGRES_DB=crm
      - POSTGRES_USER=crm
      - POSTGRES_PASSWORD=crm

volumes:
  pgdata:
    driver: local
  pgconf:
    driver: local
  pglog:
    driver: local
```
The `Dockerfile` pins the release to version `0.1.0`.

# Warning

This software is meant to run in a private network. There are no encrypted connections, there is no authentication and no authorization. Simply speaking, there is no security concept.

So, when you run the software ensure that it is not accessible from public networks.

# Development

In case you are intereseted, the program is written in C# .NET 5 Blazor (Webassembly) using Microsoft Visual Studio Community 2019. All data is stored in a PostreSQL database.

# Why?

I wanted to start home roasting and thought about storing green bean information, e.g., bean details, where did I buy it, how much did I buy, etc. And I wanted to store roast logs / profiles in a structured way, so I am able to query it and analyze the data.

I did not find a freely available program, which served this purpose. Therefore, I started to write one myself.

# License

This software is distributed under the MIT License, see `LICENSE` for details.