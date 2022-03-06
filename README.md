# SampleApp-SonarQube tets

# Analyze Your Code Using SonarQube, Docker and .NET Core

This app is an example app for learning how to use SonarQube on your projects. For more details please read [Analyze Your Code Using SonarQube, Docker and .NET Core](link_to_replace) to see a detailed instruction on how to do that.

**Prerequisites:**

- [Java 11](https://adoptopenjdk.net/)+
- [Docker](https://docs.docker.com/get-docker/)
- [.NET Core](https://dotnet.microsoft.com/download)
- [SonarScanner for .NET Core](https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.7.1.2311/sonar-scanner-msbuild-4.7.1.2311-netcoreapp2.0.zip)

**Table of Contents**

- [Getting Started](#getting-started)
- [Help](#help)
- [License](#license)

## Getting Started

Begin with running SonarQube on Docker:
```sh
docker run -d --name sonarqube -p 9000:9000 -p 9092:9092 sonarqube
```

**NOTE:** You'll be able to login with `admin/admin`. After first login, you will be promted to change the default credentials.

In order to run SonarScanner, run the following commands:

```sh
dotnet sonarscanner begin /k:"project-key" /d:sonar.login=admin /d:sonar.password=admin
dotnet build <path_to_solution.sln>
dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin
```

> **NOTE:** Remember to replace "path_to_solution" and "password" with correct ones for your example.

## Help

Please post any questions as comments on the [blog post](link_to_replace), or visit our [Okta Developer Forums](https://devforum.okta.com/). You can also ask them on [Stack Overflow with the `sonarqube` tag](https://stackoverflow.com/tags/sonarqube).

## License

Apache 2.0, see [LICENSE](LICENSE).
