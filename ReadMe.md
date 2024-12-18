# Archetypes
A simple archetype to show how the concept can be used in future.

## How to use
- Create a new git repo in devops/git. **Don't** create a readme. **Do** create a git ignore for visual studio.
- Clone the new repo somewhere on your machine.
- Clone this repo or if you have it already, pull latest from master!.
- Open a powershell instance in the folder containing this repo. You need to access Archetype.ps1 in the next step.
- Edit the following command: 
- ```.\Archetype.ps1 "{Your new repo location cloned in step 2}" "{SolutionName}" "{api||worker}"```
- This should have created a new api or worker depending on the choice in arguement 3 and pushed the repo into git.
- Edit the ReadMe of your new repo.
- Update the repo on devops to not allow pushes directly to master, only allowed through PR's

## Command Arguements
- ```.\Archetype.ps1 "{Your new repo location cloned in step 2}" "{SolutionName}" "{api||worker}"```
- ```"{Your new repo location cloned in step 2}"``` The the top folder which contains the .gitignore
- ```"{SolutionName}"``` What you want the solution to be called
- ```"{api||worker}"``` If you want a worker then set this to "worker" or for an api to "api"