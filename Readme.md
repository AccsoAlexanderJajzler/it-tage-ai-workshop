# Workspace Structure

## Root Directory

- `Readme.md`: General information and instructions for the workspace.

## 01-task-langdock

### api-assistent
- `warnung.md`: Contains warnings or important notices related to the API assistant.

### doc-assistent
- `bund-dev/docs/`: Documentation files for the development bundle.
- `cocktails/`: Contains various cocktail recipes in different languages.
  - `cocktails_for_programers.md`: English version of the cocktail recipes.
  - `...`: Other language versions of the cocktail recipes.

## 02-task-chatgpt

### bash
- `00.sh`: Bash script file.
- `01.sh`: Bash script file.
- `02.sh`: Bash script file.
- `03.sh`: Bash script file.

### powershell
- `00.ps1`: PowerShell script file.
- `01.ps1`: PowerShell script file.
- `02.ps1`: PowerShell script file.
- `03.ps1`: PowerShell script file.
- `04.ps1`: PowerShell script file.
- `05.ps1`: PowerShell script file.
- `06.ps1`: PowerShell script file.
- `06.ps1`: PowerShell script file.

- `bash-guide.txt`: Guide for using Bash.
- `diagram.md`: Contains diagrams or related documentation.

## 03-task-github-copilot

- Directory for tasks related to GitHub Copilot.

### dotnet
- `assets/`: Contains assets like images or other resources.
- `docs/`: Documentation files for the .NET project.
- `global.json`: Configuration file for .NET SDK version.
- `Readme.md`: Information and instructions for the .NET project.
- `WeatherApp/`: Source code for the WeatherApp project.
  - `Services/OpenWeather/Client/IApiClient.cs`: Interface for the OpenWeather API client.
- `WeatherAppTests/`: Unit tests for the WeatherApp project.


## Images

![Cocktails for Programmers](https://github.com/cocktails-for-programmers/cocktails_for_programmers/raw/main/images/cocktails.png)
![GNU Bash Manual](https://www.gnu.org/software/bash/manual/images/bash-logo.png)
![Umweltbundesamt Air Data API](https://www.umweltbundesamt.de/sites/default/files/medien/384/bilder/uba-logo.png)

## External Links

- [Cocktails for Programmers](https://github.com/cocktails-for-programmers/cocktails_for_programmers)
- [GNU Bash Manual](https://www.gnu.org/software/bash/manual/)
- [Umweltbundesamt Air Data API](https://www.umweltbundesamt.de/api/air_data/v2)
- https://github.com/cocktails-for-programmers/cocktails_for_programmers
- https://www.gnu.org/software/bash/manual/
- www.umweltbundesamt.de/api/air_data/v2
- [Bash Scripte](https://github.com/ruanyf/simple-bash-scripts/)
- [Powershell Scripte](https://github.com/jrussellfreelance/powershell-scripts)
- https://survey.stackoverflow.co/
- http://mypinwall.de/files/Liste-deutscher-Erfinder-und-Entdecker.pdf

## Info

### Prompting

The input in AI chat systems is referred to as a "prompt." The quality of the results is influenced by how well the question is formulated. The art of "prompt engineering" includes the following tips:

| **Category**                       | **Description**                                                                                      | **Example**                                   |
|------------------------------------|-----------------------------------------------------------------------------------------------------|-----------------------------------------------|
| **Additional Information**         | Provide context such as programming language, library, tool, or environment.                        | "C#" for Microsoft-specific features         |
| **Conditions**                     | Specify what matters to you, such as compact code, minimal imports, security, efficiency, or recursion. | "Efficient code without recursion"           |
| **Formal Rules**                   | Set rules like maximum line length, variable and function naming conventions.                      | "Maximum line length: 80 characters"         |
| **Language**                       | Formulate your question in English whenever possible.                                              | "How to implement a binary search in Python?" |
| **Follow-up Questions**            | Ask follow-up questions and specify what is missing or incorrect in the response.                  | "Can you optimize the provided solution?"    |
| **Multiple Options**               | Request multiple solution proposals from the AI tool.                                               | "Provide three different ways to sort a list."|
| **Flow of Thought**                 | Ask the AI chatbot to take on the role of multiple experts to discuss a topic.                     | "Discuss the pros and cons of using microservices." |
| **Step-by-step Approach**          | Work step-by-step and ask for an outline first.                                                     | "Outline the steps to create a REST API."    |
| **New Session for Topic Change**   | Start a new session when changing topics or when dissatisfied with the previous results.            | "New session: How to set up a CI/CD pipeline?"|
| **Understand and Test Code**       | Test the generated code thoroughly and understand the underlying concepts.                         | "Run the provided code and verify its output."|
| **Caution with New or Exotic Topics** | Language models struggle with new techniques or niche IT topics.                                | "Explain the basics of quantum computing."   |
| **Colloquial Prompts**             | Short prompts work, but precise wording helps to better define the problem.                       | "How to reverse a string in Java?"           |
