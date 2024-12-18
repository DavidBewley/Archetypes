#Input arguements
$destinationFolder=$args[0]
$solutionName=$args[1]
$projectType=$args[2]

if($projectType -eq "api"){
    Copy-Item -Path "SourceProjects\api\*" -Destination $destinationFolder -recurse -Force
}
elseif($projectType -eq "worker"){
    Copy-Item "SourceProjects\worker\*" -Destination $destinationFolder -recurse -Force
}
else{
    Write-Output "Please use either 'api' or 'worker' for the 3rd arguement. Check the readme for more help"
    Exit
}

#Rename the solution to the correct name
Rename-Item -Path "${destinationFolder}\ArchetypeConsoleApp.sln" -NewName "${destinationFolder}\${solutionName}.sln"

#Replace the {Solution.Name} in the ReadMe
(Get-Content "${destinationFolder}\ReadMe.md").Replace('{Solution.Name}', $solutionName) | Set-Content "${destinationFolder}\ReadMe.md"

#Commit to git
git -C "${destinationFolder}" add .
git -C "${destinationFolder}" commit -m 'Archetype creation intial commit'
git -C "${destinationFolder}" push