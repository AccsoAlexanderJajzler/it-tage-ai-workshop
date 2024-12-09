# Prompting

Die Eingabe bei KI-Chat-Systemen wird als »Prompt« bezeichnet. Die richtige Fragestellung beeinflusst die Qualität der Ergebnisse. Die Kunst des »Prompt Engineering« umfasst folgende Tipps:

| Kategorie                          | Beschreibung                                                                                     | Beispiel                                      |
|------------------------------------|-------------------------------------------------------------------------------------------------|-----------------------------------------------|
| **Zusatzinformationen**            | Geben Sie Kontextinformationen wie Programmiersprache, Bibliothek, Tool oder Umgebung an.        | »C#« für Microsoft-spezifische Besonderheiten |
| **Bedingungen**               | Geben Sie an, was Ihnen wichtig ist, z.B. kompakter Code, wenige Importe, Sicherheitskritik, Effizienz oder Rekursion. | »Effizienter Code ohne Rekursion«             |
| **Formale Regeln**                 | Legen Sie Regeln wie maximale Zeilenlänge, Variablen- und Funktionsnamen-Konventionen fest.      | »Maximale Zeilenlänge: 80 Zeichen«            |
| **Sprache**                        | Formulieren Sie Ihre Frage nach Möglichkeit in Englisch.                                         | »How to implement a binary search in Python?« |
| **Folgefragen**                    | Stellen Sie Folgefragen und geben Sie an, was an der Antwort nicht passt.                        | »Can you optimize the provided solution?«     |
| **Mehrere Optionen**               | Bitten Sie das KI-Tool um mehrere Lösungsvorschläge.                                             | »Provide three different ways to sort a list.«|
| **Gedankenfluss**                  | Bitten Sie den KI-Chatbot, sich in die Rolle mehrerer Experten zu versetzen und eine Frage zu diskutieren. | »Discuss the pros and cons of using microservices.« |
| **Schrittweises Arbeiten**         | Gehen Sie schrittweise vor und bitten Sie zuerst um eine Gliederung.                             | »Outline the steps to create a REST API.«     |
| **Neue Session bei Themenwechsel** | Starten Sie eine neue Session bei Themenwechsel oder Unzufriedenheit mit bisherigen Ergebnissen. | »New session: How to set up a CI/CD pipeline?«|
| **Code verstehen und testen**      | Testen Sie den generierten Code gründlich und arbeiten Sie sich in die zugrunde liegenden Konzepte ein. | »Run the provided code and verify its output.«|
| **Besondere Vorsicht bei neuen oder exotischen Themen** | Sprachmodelle haben Schwierigkeiten mit neuen Techniken oder IT-Randgebieten. | »Explain the basics of quantum computing.«    |
| **Umgangssprachliche Prompts**     | Kurze Prompts funktionieren, aber eine exakte Formulierung hilft, die Problemstellung besser zu verstehen. | »How to reverse a string in Java?«            |


## Context

## Frameworks
### [RTF - Role, Task, Format](prompting/rtf.md)
### [RODES - Role, Objective, Details, Example, Sense Check](prompting/rodes.md)
### [RISEN - Role, Instructions, Steps, End goal, Narrowing](prompting/risen.md)
