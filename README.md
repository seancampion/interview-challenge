# Technical Interview Challenge
---

Thank you for participating in the technical interview challenge! This challenge is designed to test your skill set for feature design and bug fixes in the following areas:

* Code quality
* User interface design
* Ability to understand existing code
* Communication (either in questions if they come up, comments, or commit messages)

## The Project

Your challenge involves a fairly simple application: A calculator. This calculator performs all of its operations server side and returns the results through an API layer within the application.

### Requirements to Run:
Visual Studio 2019 (Community)

### Commit Message Requirements
Your commit messages are your own and should be written in a way that you think is appropriate, but please include a reference to the feature, bug, or extra credit that is related to your commit message.

### Upon Completion of Project

If you have completed making all of your changes and have tested them, please upload your final branch of code into a GitLab repository under your account, and then email your interviewer a link to the repository.

## The Challenge

### Feature #1: Keyboard Functionality

Right now, the calculator requires the user to press the buttons in the user interface in order to perform mathematical operations.

We would like to add support so the user can use the numerical keypad on their keyboard instead of clicking buttons on the screen.

### Feature #2: Retaining the Last Total

If the user refreshes the screen, the last total value in the screen is wiped out.

We would like to add support so, upon a page refresh, the last total is still visible. This would require adding a new database column to the SessionData table in the database to store the last calculated value, then making a request for that value when the page is loaded.

### Bug #1: Button Increment Count Not Storing

We log every time a button is pressed in the user interface. We do not currently output this into the user interface, but have support for it in API calls. Currently though, this is purely used for reporting purposes.

A user has reported that the data in the database is empty -- all button counts are "zero". We need to identify why the value is not updating and correct it.

### Bug #2: Dividing By Zero Returns "Infinity"

A user reported an issue where, when they divide by zero, they were expecting a "divide by zero" error message to appear, but instead the application is returning "Infinity".

We need to identify why this is happening, and implement a correction so it properly returns the relevant message.

### Extra Credit #1: Find Areas of Improvement

There are likely one or more areas of the code base where things could be optimized, improved, or a potential bug could be exposed if certain steps aren't taken in the correct order.

Feel free to look around the code and make changes you think may improve the system.

### Extra Credit #2: Implement a New Framework (frontend or backend)

This application is fairly basic, using no special technologies other than what is needed for it to operate.

Look at implementing a new framework of your choice either in the frontend or backend of the system that provides advantages for future features that have yet to be determined (ex: adding Angular).